using BingoFlashboard.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BingoFlashboard.View
{
    /// <summary>
    /// Interaction logic for MiniGrid.xaml
    /// </summary>
    public partial class MiniGrid : Page
    {
        private CancellationTokenSource? animationCancellationTokenSource;
        string fileName = @".\patterns.txt";

        public MiniGrid()
        {
            InitializeComponent();
            //App.miniGrid = this;
            LoadPatterns();
        }


        public async void StartAnimation(Pattern p)
        {
            await StopAnimation();

            List<List<string>> patterns = new();
            if (p.Pattern_ is not null)
                patterns = p.Pattern_;

            else
            {
                //if (App.patternList_ is not null)
                //{
                //    foreach (Pattern pat in App.patternList_)
                //    {
                //        if (pat.Pattern_Name_ == p.Pattern_Name_)
                //        {
                //            if (p.Pattern_ is null)
                //            {
                //                if (pat.Pattern_ is not null)
                //                {
                //                    p = pat;
                //                    patterns = pat.Pattern_;
                //                    break;
                //                }
                //            }
                //        }
                //    }
                //}
            }

            if (animationCancellationTokenSource != null && !animationCancellationTokenSource.IsCancellationRequested)
            {
                // Animation is already running, so return
                return;
            }
            animationCancellationTokenSource = new CancellationTokenSource();

            if (p.Rotating_)
            {
                await Task.Run(async () =>
                {
                    while (!animationCancellationTokenSource.Token.IsCancellationRequested)
                    {
                        foreach (List<string> pat in patterns)
                        {
                            ClearBackground();

                            foreach (string s in pat)
                            {
                                // Set the background color for each square
                                SetSquareBackgroundColor(s);
                            }

                            await Task.Delay(1000);

                            // Check cancellation token after delay
                            if (animationCancellationTokenSource.Token.IsCancellationRequested)
                                break;
                        }
                    }
                }, animationCancellationTokenSource.Token);
            }
            else
            {
                ClearBackground();
                if (patterns is not null && patterns.Count is not 0)
                {
                    foreach (string s in patterns[0])
                    {
                        // Set the background color for each square
                        SetSquareBackgroundColor(s);
                    }
                }
            }
        }

        public async Task<Task> StopAnimation()
        {
            // Cancel the animation if it is running
            if (animationCancellationTokenSource != null)
            {
                animationCancellationTokenSource.Cancel();
                await Task.Delay(1600);
                animationCancellationTokenSource.Dispose();
                animationCancellationTokenSource = null;
            }
            return Task.CompletedTask;
        }

        private void SetSquareBackgroundColor(string squareName)
        {
            // Update the background color of the specified square
            Dispatcher.Invoke(() =>
            {
                switch (squareName)
                {
                    case "B1":
                        {
                            B1.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "B2":
                        {
                            B2.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "B3":
                        {
                            B3.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "B4":
                        {
                            B4.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "B5":
                        {
                            B5.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "I1":
                        {
                            I1.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "I2":
                        {
                            I2.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "I3":
                        {
                            I3.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "I4":
                        {
                            I4.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "I5":
                        {
                            I5.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "N1":
                        {
                            N1.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "N2":
                        {
                            N2.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "N3":
                        {
                            N3.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "N4":
                        {
                            N4.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "N5":
                        {
                            N5.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "G1":
                        {
                            G1.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "G2":
                        {
                            G2.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "G3":
                        {
                            G3.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "G4":
                        {
                            G4.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "G5":
                        {
                            G5.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "O1":
                        {
                            O1.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "O2":
                        {
                            O2.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "O3":
                        {
                            O3.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "O4":
                        {
                            O4.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                    case "O5":
                        {
                            O5.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                            break;
                        }
                }
            });
        }

        public void LoadPatterns()
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                //      App.patternList_ = JsonConvert.DeserializeObject<List<Pattern>>(json);
            }
        }

        private void ClearBackground()
        {
            Dispatcher.Invoke(() =>
            {
                B1.Background = new SolidColorBrush(Colors.White);
                B2.Background = new SolidColorBrush(Colors.White);
                B3.Background = new SolidColorBrush(Colors.White);
                B4.Background = new SolidColorBrush(Colors.White);
                B5.Background = new SolidColorBrush(Colors.White);
                I1.Background = new SolidColorBrush(Colors.White);
                I2.Background = new SolidColorBrush(Colors.White);
                I3.Background = new SolidColorBrush(Colors.White);
                I4.Background = new SolidColorBrush(Colors.White);
                I5.Background = new SolidColorBrush(Colors.White);
                N1.Background = new SolidColorBrush(Colors.White);
                N2.Background = new SolidColorBrush(Colors.White);
                N3.Background = new SolidColorBrush(Colors.White);
                N4.Background = new SolidColorBrush(Colors.White);
                N5.Background = new SolidColorBrush(Colors.White);
                G1.Background = new SolidColorBrush(Colors.White);
                G2.Background = new SolidColorBrush(Colors.White);
                G3.Background = new SolidColorBrush(Colors.White);
                G4.Background = new SolidColorBrush(Colors.White);
                G5.Background = new SolidColorBrush(Colors.White);
                O1.Background = new SolidColorBrush(Colors.White);
                O2.Background = new SolidColorBrush(Colors.White);
                O3.Background = new SolidColorBrush(Colors.White);
                O4.Background = new SolidColorBrush(Colors.White);
                O5.Background = new SolidColorBrush(Colors.White);
            });
        }
    }
}
