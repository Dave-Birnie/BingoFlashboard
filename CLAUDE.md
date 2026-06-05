# BingoFlashboard — AI Assistant Guide

## What This Project Is

BingoFlashboard is a Windows desktop application for managing and displaying live bingo games. It runs as a multi-window WPF app: a caller's control panel, a full-screen flashboard display, a timer, a card verification screen, and a mini ball grid. Games can be broadcast in real time to remote players via a SignalR server.

---

## Tech Stack

- **Language:** C# (.NET 7.0, `net7.0-windows`)
- **UI framework:** WPF (Windows Presentation Foundation)
- **Platform:** Windows only (`WinExe` output type)
- **Key NuGet packages:**
  - `Microsoft.AspNetCore.SignalR.Client` — real-time game broadcasting
  - `Newtonsoft.Json` — JSON serialisation for startup config
  - `WpfAnimatedGif` — animated GIF support on the flashboard
  - `Extended.Wpf.Toolkit` — extended WPF controls
  - `MahApps.Metro.IconPacks` — icon set
  - `System.Drawing.Common` — image utilities

---

## Project Structure

```
BingoFlashboard/
├── App.xaml / App.xaml.cs        # Application entry point; holds ALL global static state
├── BingoFlashboard.csproj        # SDK-style project file, .NET 7.0-windows
├── BingoFlashboard.sln           # Solution file
├── AssemblyInfo.cs               # Assembly metadata
│
├── Model/                        # Plain data models (no business logic)
│   ├── Card.cs                   # Bingo card
│   ├── Cardset.cs                # Collection of cards
│   ├── Country.cs                # Country reference
│   ├── Error_Log.cs              # Error log entry
│   ├── Game.cs                   # A single bingo game definition
│   ├── GameColor.cs              # Color theme for a game
│   ├── Hall.cs                   # Bingo hall configuration
│   ├── Message_Log.cs            # Message log entry
│   ├── Pattern.cs                # Win pattern (e.g. line, blackout)
│   ├── Player.cs                 # Player record
│   ├── Program.cs                # Program/session configuration
│   ├── Province.cs               # Province reference
│   ├── Session.cs                # Game session
│   ├── Winner.cs                 # Winner record
│   └── FlashboardModels/         # Models specific to the flashboard display
│       ├── Broadcasting.cs       # SignalR broadcast payload
│       ├── CalledBalls.cs        # List of called balls
│       ├── CalledBingos.cs       # Bingo calls/wins
│       ├── CardNumbers.cs        # Card number grid
│       ├── HostingGame.cs        # State for the hosted game
│       └── PartialGame.cs        # Partial game state for transmission
│
├── View/                         # XAML windows and code-behind
│   ├── StartupWindow.xaml/.cs    # First window; hall/session/game selection
│   ├── CallerWindow.xaml/.cs     # Caller's control panel (main operational window)
│   ├── FlashboardWindow.xaml/.cs # Full-screen flashboard display for players
│   ├── TimerWindow.xaml/.cs      # Countdown/game timer
│   ├── MiniGrid.xaml/.cs         # Small called-balls grid overlay
│   ├── BingoCalledWindow.xaml/.cs # "Bingo!" announcement window
│   ├── VerificationPage.xaml/.cs # Card verification page
│   └── VerifyWindow.xaml/.cs     # Wrapper window for VerificationPage
│
├── ViewModel/                    # Presentation logic (MVVM)
│   ├── ViewModelBase.cs          # INotifyPropertyChanged base class
│   ├── CallerWindowViewModel.cs  # ViewModel for CallerWindow
│   └── FlashboardViewModel.cs    # ViewModel for FlashboardWindow (very large — ~260 KB)
│
├── Data/                         # Data access and loading utilities
│   ├── PopulateCards.cs          # Parses card data .txt files into Card objects
│   ├── LoadAllPatterns.cs        # Loads win patterns
│   ├── ServerConnection.cs       # SignalR client wrapper
│   ├── DataTransfer.cs           # Data transfer helpers
│   ├── CustomLabel.cs            # Custom label model
│   ├── StartupClass.cs           # Startup configuration POCO
│   ├── DabAll.txt                # Card dataset: Dab All (~2.7 MB)
│   ├── PerfectPaper.txt          # Card dataset: Perfect Paper (~2.0 MB)
│   ├── Reliable.txt              # Card dataset: Reliable (~0.5 MB)
│   └── UniMax.txt                # Card dataset: UniMax (~6.6 MB)
│
├── ResourceDictionary/           # Shared WPF styles and templates
│   ├── Colors.xaml               # Colour palette
│   ├── Buttons.xaml              # Button styles
│   ├── Labels.xaml               # Label styles
│   ├── ModernComboBox.xaml       # ComboBox style
│   ├── ModernTextBox.xaml        # TextBox style
│   ├── BasicRadioBtn.xaml        # RadioButton style
│   └── ErrorTemplate.xaml        # Validation error template
│
├── Images/                       # All image assets
│   ├── balls/                    # Ball images (1–75, B/I/N/G/O letter balls)
│   ├── logos/                    # Hall logos (Riverbank, Cambridge, Chances, etc.)
│   └── gif/                      # Animated GIFs and static images for the flashboard
│
├── DaveHall.txt                  # Hall configuration file (Dave's hall)
├── errorlog.txt                  # Runtime error log (written by App.WriteToErrorLog)
├── startupFile.txt               # Persisted startup config (JSON, written on exit)
├── TODO.txt                      # Active TODO items
└── Notes.txt                     # Developer notes
```

---

## Architecture: MVVM

This project follows the **Model-View-ViewModel (MVVM)** pattern:

- **Model** (`Model/`) — pure data classes with no logic; represent domain objects like `Hall`, `Game`, `Card`, `Pattern`, `Player`, `Session`, `Winner`.
- **ViewModel** (`ViewModel/`) — inherits `ViewModelBase` (which implements `INotifyPropertyChanged`); owns all presentation logic and state; binds to Views via WPF data binding.
- **View** (`View/`) — XAML defines the layout; code-behind (`.xaml.cs`) is kept thin and delegates to ViewModels where possible.

`FlashboardViewModel.cs` is the largest file (~260 KB) and handles the bulk of game logic, ball calling, SignalR communication, and display state.

---

## Global State Pattern

All application-wide singletons live as `public static` fields on `App` in `App.xaml.cs`:

```csharp
App.hall                  // Current hall
App.SelectedSession       // Active session
App.SelectedGame          // Active game
App.cardList              // Loaded cards
App.playerList            // Players
App.allPatterns           // All win patterns
App.flashboardViewModel   // FlashboardWindow's VM
App.callerWindowViewModel // CallerWindow's VM
App.server                // SignalR ServerConnection
App.startup               // Startup config (persisted to startupFile.txt)

// Window references
App.startupWindow
App.callerWindow
App.flashboardWindow
App.timerWindow
App.miniGrid
App.verificationWindow
```

**Important:** There are two shared `VerificationPage` instances (`SharedVerificationPage`, `SharedVerificationPage2`) created eagerly at startup rather than on demand.

---

## Window Lifecycle

1. Application starts → `StartupWindow` is shown
2. User selects hall, session, and game → `App.ShowCallerWindows()` is called
3. `ShowCallerWindows()` hides `StartupWindow` and shows `CallerWindow`, `FlashboardWindow`, and `TimerWindow` simultaneously
4. `MiniGrid` and `VerifyWindow` are shown/hidden on demand during a game
5. Exit via `App.Exit_Click()` prompts confirmation, kills SignalR connection if active, then shuts down

---

## Card Data Files

Card datasets are stored as large `.txt` files in `Data/`. They are parsed at startup by `PopulateCards.cs`. The files are copied to the output directory on build (`CopyToOutputDirectory: Always`).

| File | Description | Size |
|------|-------------|------|
| `DabAll.txt` | Dab-all card set | ~2.7 MB |
| `UniMax.txt` | UniMax card set | ~6.6 MB |
| `PerfectPaper.txt` | Perfect Paper set | ~2.0 MB |
| `Reliable.txt` | Reliable card set | ~0.5 MB |

---

## SignalR / Online Hosting

`Data/ServerConnection.cs` wraps the `HubConnection` for broadcasting game state to remote players. The caller can start/stop hosting via `CallerWindowViewModel`. The `HostingGame` model tracks hosting status. On exit, the connection is killed with `App.server.KillConnection()` and `CloseConnection()`.

---

## Persisted State

| File | Format | Purpose |
|------|--------|---------|
| `startupFile.txt` | JSON | Serialised `StartupClass`; remembers last-used hall/session/game settings across restarts |
| `DaveHall.txt` | Custom text format | Hall configuration loaded at startup |
| `errorlog.txt` | Plain text (append) | Runtime exceptions written by `App.WriteToErrorLog()` |

---

## Build & Run

**Prerequisites:** Visual Studio 2022 (or later) with .NET 7 Windows Desktop workload. This is Windows-only — WPF does not run on macOS/Linux.

```bash
# Restore packages and build
dotnet build BingoFlashboard.sln

# Run (Windows only)
dotnet run --project BingoFlashboard.csproj
```

Or open `BingoFlashboard.sln` in Visual Studio and press F5.

There are no automated tests in this project.

---

## ResourceDictionary / Styling

All shared WPF styles live in `ResourceDictionary/` and are merged into `App.xaml`. When adding new UI controls, look for an existing style in that directory before creating inline styles. Key files:

- `Colors.xaml` — defines the colour palette (reference these instead of hard-coding hex values)
- `Buttons.xaml` — all button variants
- `Labels.xaml` — label styles

---

## Active Work Items (TODO.txt)

Current open tasks for `CallerWindow`:

- Add `CallerWindowViewModel` to change labels for jackpot prizes and game types
- Search Card feature
- 4-Ball game type support
- Send timer info to `TimerWindow`
- Next Game / Previous Game buttons
- `Caller_Type` selection change → change labels for user

---

## Key Conventions

- **No test projects** — there is no test suite; validate changes by running the application.
- **Global state via `App`** — do not create new instance-level singletons; add to `App.xaml.cs` following the existing pattern.
- **MVVM binding** — keep code-behind thin; put logic in the ViewModel.
- **Error handling** — use `App.WriteToErrorLog(message)` for non-fatal runtime errors; use `MessageBox.Show(ex.Message + " NNN")` (with a numeric code) for errors shown to the user.
- **Nullable reference types** are enabled (`<Nullable>enable</Nullable>`) — use `?` annotations and null-checks appropriately.
- **Windows only** — do not attempt to use Linux/macOS APIs; the entire codebase assumes Windows GDI, WPF, and the Windows notification stack.
