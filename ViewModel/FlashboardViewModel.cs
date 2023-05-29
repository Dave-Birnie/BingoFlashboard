using Flashboard.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BingoFlashboard;
using System.Windows.Threading;

namespace BingoFlashboard.ViewModel
{
    public class FlashboardViewModel : ViewModelBase
    {
        private Visibility _jackpotSectionVisibility;
        public Visibility JackpotSectionVisibility
        {
            get
            {
                return _jackpotSectionVisibility;
            }
            set
            {
                _jackpotSectionVisibility = value;
                OnPropertyChanged(nameof(JackpotSectionVisibility));
            }
        }

        private Visibility _uPikEmVisibility;
        public Visibility UPikEmVisibility
        {
            get
            {
                return _uPikEmVisibility;
            }
            set
            {
                _uPikEmVisibility = value;
                OnPropertyChanged(nameof(UPikEmVisibility));
            }
        }

        #region Flashboard Setup

        private BitmapImage _lastBallImg = new BitmapImage(new Uri("\\Images\\" + "" + "Ball.png", UriKind.Relative));
        public BitmapImage LastBallImg
        {
            get
            {
                return _lastBallImg;
            }
            set
            {
                _lastBallImg = value;
                OnPropertyChanged(nameof(LastBallImg));
            }
        }

        private string _moneyBall = "";
        public string MoneyBall
        {
            get
            {
                return _moneyBall;
            }
            set
            {
                _moneyBall = value;
                OnPropertyChanged(nameof(MoneyBall));
            }
        }

        private string _designatedNumber = "0";
        public string DesignatedNumber
        {
            get
            {
                return _designatedNumber = "0";
            }
            set
            {
                _designatedNumber = value;
                OnPropertyChanged(nameof(DesignatedNumber));
            }
        }

        private string _gameName = "Game Name Goes Here";
        public string GameName
        {
            get
            {
                return _gameName;
            }
            set
            {
                _gameName = value;
                OnPropertyChanged(nameof(GameName));
            }
        }

        private string _patternName = "Pattern";
        public string PatternName
        {
            get
            {
                return _patternName;
            }
            set
            {
                _patternName = value;
                OnPropertyChanged(nameof(PatternName));
            }
        }

        private string _gameType = "";
        public string GameType
        {
            get
            {
                return _gameType;
            }
            set
            {
                _gameType = value;
                OnPropertyChanged(nameof(GameType));
            }
        }

        private string _prize = "";
        public string Prize
        {
            get
            {
                return _prize;
            }
            set
            {
                _prize = value;
                OnPropertyChanged(nameof(Prize));
            }
        }

        private string _jackpotPrize = "";
        public string JackpotPrize
        {
            get
            {
                return _jackpotPrize;
            }
            set
            {
                _jackpotPrize = value;
                OnPropertyChanged(nameof(JackpotPrize));
            }
        }

        private string _ballCount = "0";
        public string BallCount
        {
            get
            {
                return _ballCount;
            }
            set
            {
                _ballCount = value;
                OnPropertyChanged(nameof(BallCount));
            }
        }

        private Brush _borderColor = new SolidColorBrush(Colors.HotPink);
        public Brush BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                OnPropertyChanged(nameof(BorderColor));
            }
        }

        private Brush _fontColor = new SolidColorBrush(Colors.White);
        public Brush FontColor
        {
            get
            {
                return _fontColor;
            }
            set
            {
                _fontColor = value;
                OnPropertyChanged(nameof(FontColor));
            }
        }


        #region MINI PATTERN

        #region MiniB
        private SolidColorBrush _mini_B1 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_B1
        {
            get
            {
                return _mini_B1;
            }
            set
            {
                _mini_B1 = value;
                OnPropertyChanged(nameof(Mini_B1));
            }
        }


        private SolidColorBrush _mini_B2 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_B2
        {
            get
            {
                return _mini_B2;
            }
            set
            {
                _mini_B2 = value;
                OnPropertyChanged(nameof(Mini_B2));
            }
        }


        private SolidColorBrush _mini_B3 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_B3
        {
            get
            {
                return _mini_B3;
            }
            set
            {
                _mini_B3 = value;
                OnPropertyChanged(nameof(Mini_B3));
            }
        }


        private SolidColorBrush _mini_B4 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_B4
        {
            get
            {
                return _mini_B4;
            }
            set
            {
                _mini_B4 = value;
                OnPropertyChanged(nameof(Mini_B4));
            }
        }


        private SolidColorBrush _mini_B5 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_B5
        {
            get
            {
                return _mini_B5;
            }
            set
            {
                _mini_B5 = value;
                OnPropertyChanged(nameof(Mini_B5));
            }
        }
        #endregion MiniB

        #region MiniI
        private SolidColorBrush _mini_I1 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_I1
        {
            get
            {
                return _mini_I1;
            }
            set
            {
                _mini_I1 = value;
                OnPropertyChanged(nameof(Mini_I1));
            }
        }


        private SolidColorBrush _mini_I2 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_I2
        {
            get
            {
                return _mini_I2;
            }
            set
            {
                _mini_I2 = value;
                OnPropertyChanged(nameof(Mini_I2));
            }
        }


        private SolidColorBrush _mini_I3 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_I3
        {
            get
            {
                return _mini_I3;
            }
            set
            {
                _mini_I3 = value;
                OnPropertyChanged(nameof(Mini_I3));
            }
        }


        private SolidColorBrush _mini_I4 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_I4
        {
            get
            {
                return _mini_I4;
            }
            set
            {
                _mini_I4 = value;
                OnPropertyChanged(nameof(Mini_I4));
            }
        }


        private SolidColorBrush _mini_I5 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_I5
        {
            get
            {
                return _mini_I5;
            }
            set
            {
                _mini_I5 = value;
                OnPropertyChanged(nameof(Mini_I5));
            }
        }
        #endregion

        #region Mini N
        private SolidColorBrush _mini_N1 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_N1
        {
            get
            {
                return _mini_N1;
            }
            set
            {
                _mini_N1 = value;
                OnPropertyChanged(nameof(Mini_N1));
            }
        }


        private SolidColorBrush _mini_N2 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_N2
        {
            get
            {
                return _mini_N2;
            }
            set
            {
                _mini_N2 = value;
                OnPropertyChanged(nameof(Mini_N2));
            }
        }


        private SolidColorBrush _mini_N3 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_N3
        {
            get
            {
                return _mini_N3;
            }
            set
            {
                _mini_N3 = value;
                OnPropertyChanged(nameof(Mini_N3));
            }
        }


        private SolidColorBrush _mini_N4 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_N4
        {
            get
            {
                return _mini_N4;
            }
            set
            {
                _mini_N4 = value;
                OnPropertyChanged(nameof(Mini_N4));
            }
        }


        private SolidColorBrush _mini_N5 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_N5
        {
            get
            {
                return _mini_N5;
            }
            set
            {
                _mini_N5 = value;
                OnPropertyChanged(nameof(Mini_N5));
            }
        }
        #endregion Mini N

        #region Mini G
        private SolidColorBrush _mini_G1 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_G1
        {
            get
            {
                return _mini_G1;
            }
            set
            {
                _mini_G1 = value;
                OnPropertyChanged(nameof(Mini_G1));
            }
        }


        private SolidColorBrush _mini_G2 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_G2
        {
            get
            {
                return _mini_G2;
            }
            set
            {
                _mini_G2 = value;
                OnPropertyChanged(nameof(Mini_G2));
            }
        }


        private SolidColorBrush _mini_G3 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_G3
        {
            get
            {
                return _mini_G3;
            }
            set
            {
                _mini_G3 = value;
                OnPropertyChanged(nameof(Mini_G3));
            }
        }


        private SolidColorBrush _mini_G4 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_G4
        {
            get
            {
                return _mini_G4;
            }
            set
            {
                _mini_G4 = value;
                OnPropertyChanged(nameof(Mini_G4));
            }
        }


        private SolidColorBrush _mini_G5 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_G5
        {
            get
            {
                return _mini_G5;
            }
            set
            {
                _mini_G5 = value;
                OnPropertyChanged(nameof(Mini_G5));
            }
        }


        #endregion GiniG

        #region Mini O
        private SolidColorBrush _mini_O1 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_O1
        {
            get
            {
                return _mini_O1;
            }
            set
            {
                _mini_O1 = value;
                OnPropertyChanged(nameof(Mini_O1));
            }
        }


        private SolidColorBrush _mini_O2 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_O2
        {
            get
            {
                return _mini_O2;
            }
            set
            {
                _mini_O2 = value;
                OnPropertyChanged(nameof(Mini_O2));
            }
        }


        private SolidColorBrush _mini_O3 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_O3
        {
            get
            {
                return _mini_O3;
            }
            set
            {
                _mini_O3 = value;
                OnPropertyChanged(nameof(Mini_O3));
            }
        }


        private SolidColorBrush _mini_O4 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_O4
        {
            get
            {
                return _mini_O4;
            }
            set
            {
                _mini_O4 = value;
                OnPropertyChanged(nameof(Mini_O4));
            }
        }


        private SolidColorBrush _mini_O5 = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush Mini_O5
        {
            get
            {
                return _mini_O5;
            }
            set
            {
                _mini_O5 = value;
                OnPropertyChanged(nameof(Mini_O5));
            }
        }

        #endregion


        #endregion MINI PATTERN

        private Visibility _designatedNumVisibility = Visibility.Hidden;
        public Visibility DesignatedNumVisibility
        {
            get
            {
                return _designatedNumVisibility;
            }
            set
            {
                _designatedNumVisibility = value;
                OnPropertyChanged(nameof(DesignatedNumVisibility));
            }
        }

        private Visibility _moneyBallVisibility = Visibility.Hidden;
        public Visibility MoneyBallVisibility
        {
            get
            {
                return _moneyBallVisibility;
            }
            set
            {
                _moneyBallVisibility = value;
                OnPropertyChanged(nameof(MoneyBallVisibility));
            }
        }

        private Visibility _jackpotVisibility;
        public Visibility JackpotVisibility
        {
            get
            {
                return _jackpotVisibility;
            }
            set
            {
                _jackpotVisibility = value;
                OnPropertyChanged(nameof(JackpotVisibility));
            }
        }

        #endregion // END Flashboard

        #region HallInfo

        private string _hallName = App.hall.Name_;
        public string HallName
        {
            get
            {
                return _hallName;
            }
            set
            {
                _hallName = value;
                OnPropertyChanged(nameof(HallName));
            }
        }

        private string? _hallNumber = App.hall.Phone_;
        public string? HallNumber
        {
            get
            {
                return _hallNumber;
            }
            set
            {
                _hallNumber = value;
                OnPropertyChanged(nameof(HallNumber));
            }
        }

        private string? _hallFlashboardMessage = App.hall.Message_;
        public string? HallFlashboardMessage
        {
            get
            {
                return _hallFlashboardMessage;
            }
            set
            {
                _hallFlashboardMessage = value;
                OnPropertyChanged(nameof(HallFlashboardMessage));
            }
        }

        #endregion

        #region MainLabel States

        #region B's State
        private int _b1State = 0;
        public int B1State
        {
            get
            {
                return _b1State;
            }
            set
            {
                _b1State = value;
                OnPropertyChanged(nameof(B1State));
            }
        }

        private int _b2State = 0;
        public int B2State
        {
            get
            {
                return _b2State;
            }
            set
            {
                _b2State = value;
                OnPropertyChanged(nameof(B2State));
            }
        }

        private int _b3State = 0;
        public int B3State
        {
            get
            {
                return _b3State;
            }
            set
            {
                _b3State = value;
                OnPropertyChanged(nameof(B3State));
            }
        }

        private int _b4State = 0;
        public int B4State
        {
            get
            {
                return _b4State;
            }
            set
            {
                _b4State = value;
                OnPropertyChanged(nameof(B4State));
            }
        }

        private int _b5State = 0;
        public int B5State
        {
            get
            {
                return _b5State;
            }
            set
            {
                _b5State = value;
                OnPropertyChanged(nameof(B5State));
            }
        }

        private int _b6State = 0;
        public int B6State
        {
            get
            {
                return _b6State;
            }
            set
            {
                _b6State = value;
                OnPropertyChanged(nameof(B6State));
            }
        }

        private int _b7State = 0;
        public int B7State
        {
            get
            {
                return _b7State;
            }
            set
            {
                _b7State = value;
                OnPropertyChanged(nameof(B7State));
            }
        }

        private int _b8State = 0;
        public int B8State
        {
            get
            {
                return _b8State;
            }
            set
            {
                _b8State = value;
                OnPropertyChanged(nameof(B8State));
            }
        }

        private int _b9State = 0;
        public int B9State
        {
            get
            {
                return _b9State;
            }
            set
            {
                _b9State = value;
                OnPropertyChanged(nameof(B9State));
            }
        }


        private int _b10State = 0;
        public int B10State
        {
            get
            {
                return _b10State;
            }
            set
            {
                _b10State = value;
                OnPropertyChanged(nameof(B10State));
            }
        }

        private int _b11State = 0;
        public int B11State
        {
            get
            {
                return _b11State;
            }
            set
            {
                _b11State = value;
                OnPropertyChanged(nameof(B11State));
            }
        }

        private int _b12State = 0;
        public int B12State
        {
            get
            {
                return _b12State;
            }
            set
            {
                _b12State = value;
                OnPropertyChanged(nameof(B12State));
            }
        }

        private int _b13State = 0;
        public int B13State
        {
            get
            {
                return _b13State;
            }
            set
            {
                _b13State = value;
                OnPropertyChanged(nameof(B13State));
            }
        }

        private int _b14State = 0;
        public int B14State
        {
            get
            {
                return _b14State;
            }
            set
            {
                _b14State = value;
                OnPropertyChanged(nameof(B14State));
            }
        }

        private int _b15State = 0;
        public int B15State
        {
            get
            {
                return _b15State;
            }
            set
            {
                _b15State = value;
                OnPropertyChanged(nameof(B15State));
            }
        }
        #endregion B's State 

        #region I's State
        private int _i1State = 0;
        public int I1State
        {
            get
            {
                return _i1State;
            }
            set
            {
                _i1State = value;
                OnPropertyChanged(nameof(I1State));
            }
        }

        private int _i2State = 0;
        public int I2State
        {
            get
            {
                return _i2State;
            }
            set
            {
                _i2State = value;
                OnPropertyChanged(nameof(I2State));
            }
        }

        private int _i3State = 0;
        public int I3State
        {
            get
            {
                return _i3State;
            }
            set
            {
                _i3State = value;
                OnPropertyChanged(nameof(I3State));
            }
        }

        private int _i4State = 0;
        public int I4State
        {
            get
            {
                return _i4State;
            }
            set
            {
                _i4State = value;
                OnPropertyChanged(nameof(I4State));
            }
        }

        private int _i5State = 0;
        public int I5State
        {
            get
            {
                return _i5State;
            }
            set
            {
                _i5State = value;
                OnPropertyChanged(nameof(I5State));
            }
        }

        private int _i6State = 0;
        public int I6State
        {
            get
            {
                return _i6State;
            }
            set
            {
                _i6State = value;
                OnPropertyChanged(nameof(I6State));
            }
        }

        private int _i7State = 0;
        public int I7State
        {
            get
            {
                return _i7State;
            }
            set
            {
                _i7State = value;
                OnPropertyChanged(nameof(I7State));
            }
        }

        private int _i8State = 0;
        public int I8State
        {
            get
            {
                return _i8State;
            }
            set
            {
                _i8State = value;
                OnPropertyChanged(nameof(I8State));
            }
        }

        private int _i9State = 0;
        public int I9State
        {
            get
            {
                return _i9State;
            }
            set
            {
                _i9State = value;
                OnPropertyChanged(nameof(I9State));
            }
        }


        private int _i10State = 0;
        public int I10State
        {
            get
            {
                return _i10State;
            }
            set
            {
                _i10State = value;
                OnPropertyChanged(nameof(I10State));
            }
        }

        private int _i11State = 0;
        public int I11State
        {
            get
            {
                return _i11State;
            }
            set
            {
                _i11State = value;
                OnPropertyChanged(nameof(I11State));
            }
        }

        private int _i12State = 0;
        public int I12State
        {
            get
            {
                return _i12State;
            }
            set
            {
                _i12State = value;
                OnPropertyChanged(nameof(I12State));
            }
        }

        private int _i13State = 0;
        public int I13State
        {
            get
            {
                return _i13State;
            }
            set
            {
                _i13State = value;
                OnPropertyChanged(nameof(I13State));
            }
        }

        private int _i14State = 0;
        public int I14State
        {
            get
            {
                return _i14State;
            }
            set
            {
                _i14State = value;
                OnPropertyChanged(nameof(I14State));
            }
        }

        private int _i15State = 0;
        public int I15State
        {
            get
            {
                return _i15State;
            }
            set
            {
                _i15State = value;
                OnPropertyChanged(nameof(I15State));
            }
        }
        #endregion I's State

        #region N's State
        private int _n1State = 0;
        public int N1State
        {
            get
            {
                return _n1State;
            }
            set
            {
                _n1State = value;
                OnPropertyChanged(nameof(N1State));
            }
        }

        private int _n2State = 0;
        public int N2State
        {
            get
            {
                return _n2State;
            }
            set
            {
                _n2State = value;
                OnPropertyChanged(nameof(N2State));
            }
        }

        private int _n3State = 0;
        public int N3State
        {
            get
            {
                return _n3State;
            }
            set
            {
                _n3State = value;
                OnPropertyChanged(nameof(N3State));
            }
        }

        private int _n4State = 0;
        public int N4State
        {
            get
            {
                return _n4State;
            }
            set
            {
                _n4State = value;
                OnPropertyChanged(nameof(N4State));
            }
        }

        private int _n5State = 0;
        public int N5State
        {
            get
            {
                return _n5State;
            }
            set
            {
                _n5State = value;
                OnPropertyChanged(nameof(N5State));
            }
        }

        private int _n6State = 0;
        public int N6State
        {
            get
            {
                return _n6State;
            }
            set
            {
                _n6State = value;
                OnPropertyChanged(nameof(N6State));
            }
        }

        private int _n7State = 0;
        public int N7State
        {
            get
            {
                return _n7State;
            }
            set
            {
                _n7State = value;
                OnPropertyChanged(nameof(N7State));
            }
        }

        private int _n8State = 0;
        public int N8State
        {
            get
            {
                return _n8State;
            }
            set
            {
                _n8State = value;
                OnPropertyChanged(nameof(N8State));
            }
        }

        private int _n9State = 0;
        public int N9State
        {
            get
            {
                return _n9State;
            }
            set
            {
                _n9State = value;
                OnPropertyChanged(nameof(N9State));
            }
        }


        private int _n10State = 0;
        public int N10State
        {
            get
            {
                return _n10State;
            }
            set
            {
                _n10State = value;
                OnPropertyChanged(nameof(N10State));
            }
        }

        private int _n11State = 0;
        public int N11State
        {
            get
            {
                return _n11State;
            }
            set
            {
                _n11State = value;
                OnPropertyChanged(nameof(N11State));
            }
        }

        private int _n12State = 0;
        public int N12State
        {
            get
            {
                return _n12State;
            }
            set
            {
                _n12State = value;
                OnPropertyChanged(nameof(N12State));
            }
        }

        private int _n13State = 0;
        public int N13State
        {
            get
            {
                return _n13State;
            }
            set
            {
                _n13State = value;
                OnPropertyChanged(nameof(N13State));
            }
        }

        private int _n14State = 0;
        public int N14State
        {
            get
            {
                return _n14State;
            }
            set
            {
                _n14State = value;
                OnPropertyChanged(nameof(N14State));
            }
        }

        private int _n15State = 0;
        public int N15State
        {
            get
            {
                return _n15State;
            }
            set
            {
                _n15State = value;
                OnPropertyChanged(nameof(N15State));
            }
        }
        #endregion N's State 

        #region G's State
        private int _g1State = 0;
        public int G1State
        {
            get
            {
                return _g1State;
            }
            set
            {
                _g1State = value;
                OnPropertyChanged(nameof(G1State));
            }
        }

        private int _g2State = 0;
        public int G2State
        {
            get
            {
                return _g2State;
            }
            set
            {
                _g2State = value;
                OnPropertyChanged(nameof(G2State));
            }
        }

        private int _g3State = 0;
        public int G3State
        {
            get
            {
                return _g3State;
            }
            set
            {
                _g3State = value;
                OnPropertyChanged(nameof(G3State));
            }
        }

        private int _g4State = 0;
        public int G4State
        {
            get
            {
                return _g4State;
            }
            set
            {
                _g4State = value;
                OnPropertyChanged(nameof(G4State));
            }
        }

        private int _g5State = 0;
        public int G5State
        {
            get
            {
                return _g5State;
            }
            set
            {
                _g5State = value;
                OnPropertyChanged(nameof(G5State));
            }
        }

        private int _g6State = 0;
        public int G6State
        {
            get
            {
                return _g6State;
            }
            set
            {
                _g6State = value;
                OnPropertyChanged(nameof(G6State));
            }
        }

        private int _g7State = 0;
        public int G7State
        {
            get
            {
                return _g7State;
            }
            set
            {
                _g7State = value;
                OnPropertyChanged(nameof(G7State));
            }
        }

        private int _g8State = 0;
        public int G8State
        {
            get
            {
                return _g8State;
            }
            set
            {
                _g8State = value;
                OnPropertyChanged(nameof(G8State));
            }
        }

        private int _g9State = 0;
        public int G9State
        {
            get
            {
                return _g9State;
            }
            set
            {
                _g9State = value;
                OnPropertyChanged(nameof(G9State));
            }
        }


        private int _g10State = 0;
        public int G10State
        {
            get
            {
                return _g10State;
            }
            set
            {
                _g10State = value;
                OnPropertyChanged(nameof(G10State));
            }
        }

        private int _g11State = 0;
        public int G11State
        {
            get
            {
                return _g11State;
            }
            set
            {
                _g11State = value;
                OnPropertyChanged(nameof(G11State));
            }
        }

        private int _g12State = 0;
        public int G12State
        {
            get
            {
                return _g12State;
            }
            set
            {
                _g12State = value;
                OnPropertyChanged(nameof(G12State));
            }
        }

        private int _g13State = 0;
        public int G13State
        {
            get
            {
                return _g13State;
            }
            set
            {
                _g13State = value;
                OnPropertyChanged(nameof(G13State));
            }
        }

        private int _g14State = 0;
        public int G14State
        {
            get
            {
                return _g14State;
            }
            set
            {
                _g14State = value;
                OnPropertyChanged(nameof(G14State));
            }
        }

        private int _g15State = 0;
        public int G15State
        {
            get
            {
                return _g15State;
            }
            set
            {
                _g15State = value;
                OnPropertyChanged(nameof(G15State));
            }
        }
        #endregion G's State 

        #region O's State
        private int _o1State = 0;
        public int O1State
        {
            get
            {
                return _o1State;
            }
            set
            {
                _o1State = value;
                OnPropertyChanged(nameof(O1State));
            }
        }

        private int _o2State = 0;
        public int O2State
        {
            get
            {
                return _o2State;
            }
            set
            {
                _o2State = value;
                OnPropertyChanged(nameof(O2State));
            }
        }

        private int _o3State = 0;
        public int O3State
        {
            get
            {
                return _o3State;
            }
            set
            {
                _o3State = value;
                OnPropertyChanged(nameof(O3State));
            }
        }

        private int _o4State = 0;
        public int O4State
        {
            get
            {
                return _o4State;
            }
            set
            {
                _o4State = value;
                OnPropertyChanged(nameof(O4State));
            }
        }

        private int _o5State = 0;
        public int O5State
        {
            get
            {
                return _o5State;
            }
            set
            {
                _o5State = value;
                OnPropertyChanged(nameof(O5State));
            }
        }

        private int _o6State = 0;
        public int O6State
        {
            get
            {
                return _o6State;
            }
            set
            {
                _o6State = value;
                OnPropertyChanged(nameof(O6State));
            }
        }

        private int _o7State = 0;
        public int O7State
        {
            get
            {
                return _o7State;
            }
            set
            {
                _o7State = value;
                OnPropertyChanged(nameof(O7State));
            }
        }

        private int _o8State = 0;
        public int O8State
        {
            get
            {
                return _o8State;
            }
            set
            {
                _o8State = value;
                OnPropertyChanged(nameof(O8State));
            }
        }

        private int _o9State = 0;
        public int O9State
        {
            get
            {
                return _o9State;
            }
            set
            {
                _o9State = value;
                OnPropertyChanged(nameof(O9State));
            }
        }


        private int _o10State = 0;
        public int O10State
        {
            get
            {
                return _o10State;
            }
            set
            {
                _o10State = value;
                OnPropertyChanged(nameof(O10State));
            }
        }

        private int _o11State = 0;
        public int O11State
        {
            get
            {
                return _o11State;
            }
            set
            {
                _o11State = value;
                OnPropertyChanged(nameof(O11State));
            }
        }

        private int _o12State = 0;
        public int O12State
        {
            get
            {
                return _o12State;
            }
            set
            {
                _o12State = value;
                OnPropertyChanged(nameof(O12State));
            }
        }

        private int _o13State = 0;
        public int O13State
        {
            get
            {
                return _o13State;
            }
            set
            {
                _o13State = value;
                OnPropertyChanged(nameof(O13State));
            }
        }

        private int _o14State = 0;
        public int O14State
        {
            get
            {
                return _o14State;
            }
            set
            {
                _o14State = value;
                OnPropertyChanged(nameof(O14State));
            }
        }

        private int _o15State = 0;
        public int O15State
        {
            get
            {
                return _o15State;
            }
            set
            {
                _o15State = value;
                OnPropertyChanged(nameof(O15State));
            }
        }
        #endregion O's State 

        #region CalledBall
        List<CalledBalls> _lastcalled = new List<CalledBalls>();
        List<string> lastBallCalled = new List<string>();
        public async void UpdateFlashboardNumbers(string TypedBall)
        {
            try
            {
                Int32.TryParse(TypedBall, out int ballnum);

                if (ballnum >= 1 && ballnum <= 75)
                {
                    switch (ballnum)
                    {
                        #region B's
                        case 1:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B1State)
                                {
                                    case 0:
                                        {
                                            B1State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B1State", BallNum_ = 1 });
                                            lastBallCalled.Add("B1State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B1State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B1State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B1State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B1State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B1State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B1State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 2:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B2State)
                                {
                                    case 0:
                                        {
                                            B2State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B2State", BallNum_ = 2 });
                                            lastBallCalled.Add("B2State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B2State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B2State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B2State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B2State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B2State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B2State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 3:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B3State)
                                {
                                    case 0:
                                        {
                                            B3State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B3State", BallNum_ = 3 });
                                            lastBallCalled.Add("B3State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B3State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B3State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B3State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B3State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B3State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B3State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 4:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B4State)
                                {
                                    case 0:
                                        {
                                            B4State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B4State", BallNum_ = 4 });
                                            lastBallCalled.Add("B4State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B4State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B4State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B4State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B4State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B4State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B4State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 5:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B5State)
                                {
                                    case 0:
                                        {
                                            B5State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B5State", BallNum_ = 5 });
                                            lastBallCalled.Add("B5State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B5State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B5State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B5State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B5State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B5State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B5State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 6:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B6State)
                                {
                                    case 0:
                                        {
                                            B6State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B6State", BallNum_ = 6 });
                                            lastBallCalled.Add("B6State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B6State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B6State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B6State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B6State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B6State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B6State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 7:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B7State)
                                {
                                    case 0:
                                        {
                                            B7State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B7State", BallNum_ = 7 });
                                            lastBallCalled.Add("B7State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B7State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B7State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B7State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B7State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B7State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B7State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 8:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B8State)
                                {
                                    case 0:
                                        {
                                            B8State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B8State", BallNum_ = 8 });
                                            lastBallCalled.Add("B8State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B8State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B8State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B8State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B8State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B8State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B8State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 9:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B9State)
                                {
                                    case 0:
                                        {
                                            B9State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B9State", BallNum_ = 9 });
                                            lastBallCalled.Add("B9State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B9State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B9State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B9State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B9State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B9State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B9State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 10:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B10State)
                                {
                                    case 0:
                                        {
                                            B10State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B10State", BallNum_ = 10 });
                                            lastBallCalled.Add("B10State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B10State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B10State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B10State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B10State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B10State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B10State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 11:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B11State)
                                {
                                    case 0:
                                        {
                                            B11State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B11State", BallNum_ = 11 });
                                            lastBallCalled.Add("B11State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B11State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B11State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B11State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B11State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B11State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B11State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 12:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B12State)
                                {
                                    case 0:
                                        {
                                            B12State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B12State", BallNum_ = 12 });
                                            lastBallCalled.Add("B12State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B12State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B12State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B12State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B12State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B12State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B12State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 13:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B13State)
                                {
                                    case 0:
                                        {
                                            B13State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B13State", BallNum_ = 13 });
                                            lastBallCalled.Add("B13State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B13State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B13State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B13State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B13State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B13State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B13State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 14:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B14State)
                                {
                                    case 0:
                                        {
                                            B14State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B14State", BallNum_ = 14 });
                                            lastBallCalled.Add("B14State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B14State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B14State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B14State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B14State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B14State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B14State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 15:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (B15State)
                                {
                                    case 0:
                                        {
                                            B15State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "B15State", BallNum_ = 15 });
                                            lastBallCalled.Add("B15State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            B15State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B15State")
                                                    _lastcalled.Remove(ball);
                                            }
                                            lastBallCalled.Remove("B15State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            B15State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "B15State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("B15State");
                                            break;
                                        }
                                }
                                break;
                            }
                        #endregion B's    

                        #region I's
                        case 16:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I1State)
                                {
                                    case 0:
                                        {
                                            I1State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I1State", BallNum_ = 16 });
                                            lastBallCalled.Add("I1State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I1State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I1State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I1State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I1State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I1State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I1State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 17:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I2State)
                                {
                                    case 0:
                                        {
                                            I2State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I2State", BallNum_ = 17 });
                                            lastBallCalled.Add("I2State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I2State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I2State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I2State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I2State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I2State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I2State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 18:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I3State)
                                {
                                    case 0:
                                        {
                                            I3State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I3State", BallNum_ = 18 });
                                            lastBallCalled.Add("I3State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I3State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I3State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I3State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I3State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I3State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I3State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 19:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I4State)
                                {
                                    case 0:
                                        {
                                            I4State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I4State", BallNum_ = 19 });
                                            lastBallCalled.Add("I4State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I4State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I4State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I4State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I4State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I4State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I4State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 20:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I5State)
                                {
                                    case 0:
                                        {
                                            I5State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I5State", BallNum_ = 20 });
                                            lastBallCalled.Add("I5State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I5State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I5State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I5State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I5State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I5State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I5State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 21:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I6State)
                                {
                                    case 0:
                                        {
                                            I6State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I6State", BallNum_ = 21 });
                                            lastBallCalled.Add("I6State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I6State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I6State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I6State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I6State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I6State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I6State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 22:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I7State)
                                {
                                    case 0:
                                        {
                                            I7State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I7State", BallNum_ = 22 });
                                            lastBallCalled.Add("I7State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I7State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I7State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("I7State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I7State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I7State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I7State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 23:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I8State)
                                {
                                    case 0:
                                        {
                                            I8State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I8State", BallNum_ = 23 });
                                            lastBallCalled.Add("I8State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I8State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I8State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I8State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I8State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I8State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I8State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 24:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I9State)
                                {
                                    case 0:
                                        {
                                            I9State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I9State", BallNum_ = 24 });
                                            lastBallCalled.Add("I9State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I9State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I9State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I9State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I9State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I9State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I9State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 25:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I10State)
                                {
                                    case 0:
                                        {
                                            I10State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I10State", BallNum_ = 25 });
                                            lastBallCalled.Add("I10State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I10State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I10State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I10State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I10State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I10State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I10State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 26:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I11State)
                                {
                                    case 0:
                                        {
                                            I11State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I11State", BallNum_ = 26 });
                                            lastBallCalled.Add("I11State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I11State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I11State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I11State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I11State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I11State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I11State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 27:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I12State)
                                {
                                    case 0:
                                        {
                                            I12State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I12State", BallNum_ = 27 });
                                            lastBallCalled.Add("I12State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I12State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I12State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I12State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I12State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I12State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I12State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 28:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I13State)
                                {
                                    case 0:
                                        {
                                            I13State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I13State", BallNum_ = 28 });
                                            lastBallCalled.Add("I13State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I13State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I13State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("I13State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I13State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I13State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I13State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 29:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I14State)
                                {
                                    case 0:
                                        {
                                            I14State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I14State", BallNum_ = 29 });
                                            lastBallCalled.Add("I14State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I14State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I14State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I14State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I14State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I14State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I14State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 30:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (I15State)
                                {
                                    case 0:
                                        {
                                            I15State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "I15State", BallNum_ = 30 });
                                            lastBallCalled.Add("I15State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            I15State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I15State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("I15State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            I15State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "I15State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("I15State");
                                            break;
                                        }
                                }
                                break;
                            }
                        #endregion I's    

                        #region N's
                        case 31:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N1State)
                                {
                                    case 0:
                                        {
                                            N1State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N1State", BallNum_ = 31 });
                                            lastBallCalled.Add("N1State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N1State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N1State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N1State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N1State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N1State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N1State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 32:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N2State)
                                {
                                    case 0:
                                        {
                                            N2State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N2State", BallNum_ = 32 });

                                            lastBallCalled.Add("N2State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N2State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N2State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("N2State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N2State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N2State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("N2State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 33:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N3State)
                                {
                                    case 0:
                                        {
                                            N3State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N3State", BallNum_ = 33 });
                                            lastBallCalled.Add("N3State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N3State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N3State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("N3State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N3State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N3State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("N3State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 34:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N4State)
                                {
                                    case 0:
                                        {
                                            N4State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N4State", BallNum_ = 34 });
                                            lastBallCalled.Add("N4State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N4State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N4State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("N4State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N4State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N4State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N4State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 35:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N5State)
                                {
                                    case 0:
                                        {
                                            N5State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N5State", BallNum_ = 35 });
                                            lastBallCalled.Add("N5State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N5State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N5State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("N5State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N5State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N5State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("N5State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 36:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N6State)
                                {
                                    case 0:
                                        {
                                            N6State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N6State", BallNum_ = 36 });
                                            lastBallCalled.Add("N6State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N6State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N6State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N6State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N6State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N6State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N6State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 37:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N7State)
                                {
                                    case 0:
                                        {
                                            N7State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N7State", BallNum_ = 37 });
                                            lastBallCalled.Add("N7State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N7State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N7State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N7State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N7State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N7State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N7State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 38:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N8State)
                                {
                                    case 0:
                                        {
                                            N8State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N8State", BallNum_ = 38 });
                                            lastBallCalled.Add("N8State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N8State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N8State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N8State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N8State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N8State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N8State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 39:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N9State)
                                {
                                    case 0:
                                        {
                                            N9State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N9State", BallNum_ = 39 });
                                            lastBallCalled.Add("N9State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N9State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N9State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N9State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N9State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N9State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("N9State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 40:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N10State)
                                {
                                    case 0:
                                        {
                                            N10State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N10State", BallNum_ = 40 });
                                            lastBallCalled.Add("N10State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N10State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N10State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N10State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N10State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N10State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N10State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 41:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N11State)
                                {
                                    case 0:
                                        {
                                            N11State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N11State", BallNum_ = 41 });
                                            lastBallCalled.Add("N11State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N11State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N11State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N11State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N11State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N11State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("N11State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 42:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N12State)
                                {
                                    case 0:
                                        {
                                            N12State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N12State", BallNum_ = 42 });
                                            lastBallCalled.Add("N12State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N12State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N12State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N12State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N12State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N12State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N12State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 43:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N13State)
                                {
                                    case 0:
                                        {
                                            N13State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N13State", BallNum_ = 43 });
                                            lastBallCalled.Add("N13State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N13State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N13State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N13State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N13State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N13State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N13State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 44:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N14State)
                                {
                                    case 0:
                                        {
                                            N14State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N14State", BallNum_ = 44 });
                                            lastBallCalled.Add("N14State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N14State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N14State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("N14State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N14State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N14State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N14State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 45:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (N15State)
                                {
                                    case 0:
                                        {
                                            N15State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "N15State", BallNum_ = 45 });

                                            lastBallCalled.Add("N15State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            N15State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N15State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("N15State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            N15State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "N15State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("N15State");
                                            break;
                                        }
                                }
                                break;
                            }
                        #endregion N's    

                        #region G's
                        case 46:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G1State)
                                {
                                    case 0:
                                        {
                                            G1State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G1State", BallNum_ = 46 });
                                            lastBallCalled.Add("G1State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G1State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G1State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G1State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G1State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G1State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G1State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 47:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G2State)
                                {
                                    case 0:
                                        {
                                            G2State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G2State", BallNum_ = 47 });
                                            lastBallCalled.Add("G2State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G2State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G2State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G2State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G2State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G2State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G2State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 48:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G3State)
                                {
                                    case 0:
                                        {
                                            G3State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G3State", BallNum_ = 48 });
                                            lastBallCalled.Add("G3State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G3State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G3State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G3State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G3State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G3State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G3State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 49:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G4State)
                                {
                                    case 0:
                                        {
                                            G4State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G4State", BallNum_ = 49 });
                                            lastBallCalled.Add("G4State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G4State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G4State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G4State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G4State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G4State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G4State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 50:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G5State)
                                {
                                    case 0:
                                        {
                                            G5State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G5State", BallNum_ = 50 });
                                            lastBallCalled.Add("G5State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G5State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G5State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G5State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G5State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G5State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G5State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 51:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G6State)
                                {
                                    case 0:
                                        {
                                            G6State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G6State", BallNum_ = 51 });
                                            lastBallCalled.Add("G6State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G6State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G6State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G6State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G6State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G6State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G6State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 52:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G7State)
                                {
                                    case 0:
                                        {
                                            G7State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G7State", BallNum_ = 52 });
                                            lastBallCalled.Add("G7State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G7State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G7State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("G7State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G7State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G7State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G7State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 53:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G8State)
                                {
                                    case 0:
                                        {
                                            G8State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G8State", BallNum_ = 53 });
                                            lastBallCalled.Add("G8State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G8State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G8State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G8State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G8State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G8State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G8State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 54:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G9State)
                                {
                                    case 0:
                                        {
                                            G9State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G9State", BallNum_ = 54 });
                                            lastBallCalled.Add("G9State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G9State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G9State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G9State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G9State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G9State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G9State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 55:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G10State)
                                {
                                    case 0:
                                        {
                                            G10State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G10State", BallNum_ = 55 });
                                            lastBallCalled.Add("G10State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G10State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G10State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G10State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G10State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G10State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G10State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 56:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G11State)
                                {
                                    case 0:
                                        {
                                            G11State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G11State", BallNum_ = 56 });
                                            lastBallCalled.Add("G11State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G11State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G11State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G11State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G11State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G11State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G11State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 57:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G12State)
                                {
                                    case 0:
                                        {
                                            G12State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G12State", BallNum_ = 57 });
                                            lastBallCalled.Add("G12State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G12State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G12State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G12State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G12State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G12State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G12State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 58:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G13State)
                                {
                                    case 0:
                                        {
                                            G13State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G13State", BallNum_ = 58 });
                                            lastBallCalled.Add("G13State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G13State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G13State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G13State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G13State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G13State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G13State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 59:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G14State)
                                {
                                    case 0:
                                        {
                                            G14State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G14State", BallNum_ = 59 });
                                            lastBallCalled.Add("G14State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G14State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G14State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G14State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G14State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G14State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G14State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 60:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (G15State)
                                {
                                    case 0:
                                        {
                                            G15State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "G15State", BallNum_ = 60 });
                                            lastBallCalled.Add("G15State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            G15State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G15State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("G15State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            G15State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "G15State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("G15State");
                                            break;
                                        }
                                }
                                break;
                            }
                        #endregion G's    

                        #region O's
                        case 61:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O1State)
                                {
                                    case 0:
                                        {
                                            O1State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O1State", BallNum_ = 61 });
                                            lastBallCalled.Add("O1State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O1State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O1State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O1State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O1State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O1State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O1State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 62:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O2State)
                                {
                                    case 0:
                                        {
                                            O2State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O2State", BallNum_ = 62 });
                                            lastBallCalled.Add("O2State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O2State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O2State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("O2State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O2State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O2State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("O2State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 63:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O3State)
                                {
                                    case 0:
                                        {
                                            O3State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O3State", BallNum_ = 63 });
                                            lastBallCalled.Add("O3State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O3State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O3State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O3State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O3State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O3State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O3State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 64:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O4State)
                                {
                                    case 0:
                                        {
                                            O4State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O4State", BallNum_ = 64 });
                                            lastBallCalled.Add("O4State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O4State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O4State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O4State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O4State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O4State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O4State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 65:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O5State)
                                {
                                    case 0:
                                        {
                                            O5State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O5State", BallNum_ = 65 });
                                            lastBallCalled.Add("O5State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O5State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O5State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O5State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O5State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O5State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O5State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 66:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O6State)
                                {
                                    case 0:
                                        {
                                            O6State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O6State", BallNum_ = 66 });
                                            lastBallCalled.Add("O6State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O6State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O6State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O6State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O6State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O6State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O6State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 67:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O7State)
                                {
                                    case 0:
                                        {
                                            O7State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O7State", BallNum_ = 67 });
                                            lastBallCalled.Add("O7State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O7State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O7State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("O7State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O7State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O7State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("O7State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 68:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O8State)
                                {
                                    case 0:
                                        {
                                            O8State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O8State", BallNum_ = 68 });
                                            lastBallCalled.Add("O8State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O8State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O8State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O8State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O8State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O8State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O8State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 69:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O9State)
                                {
                                    case 0:
                                        {
                                            O9State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O9State", BallNum_ = 69 });
                                            lastBallCalled.Add("O9State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O9State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O9State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O9State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O9State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O9State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O9State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 70:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O10State)
                                {
                                    case 0:
                                        {
                                            O10State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O10State", BallNum_ = 70 });
                                            lastBallCalled.Add("O10State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O10State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O10State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }

                                            lastBallCalled.Remove("O10State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O10State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O10State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O10State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 71:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O11State)
                                {
                                    case 0:
                                        {
                                            O11State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O11State", BallNum_ = 71 });
                                            lastBallCalled.Add("O11State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O11State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O11State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O11State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O11State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O11State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O11State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 72:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O12State)
                                {
                                    case 0:
                                        {
                                            O12State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O12State", BallNum_ = 72 });
                                            lastBallCalled.Add("O12State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O12State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O12State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O12State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O12State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O12State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O12State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 73:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O13State)
                                {
                                    case 0:
                                        {
                                            O13State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O13State", BallNum_ = 73 });
                                            lastBallCalled.Add("O13State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O13State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O13State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O13State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O13State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O13State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O13State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 74:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O14State)
                                {
                                    case 0:
                                        {
                                            O14State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O14State", BallNum_ = 74 });
                                            lastBallCalled.Add("O14State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O14State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O14State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O14State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O14State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O14State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O14State");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 75:
                            {
                                //state of the ball 0 = off, 1= on, 2 = animated;
                                switch (O15State)
                                {
                                    case 0:
                                        {
                                            O15State = 2;
                                            if (lastBallCalled.Count >= 1)
                                                await ChangeLastBallState();
                                            _lastcalled.Add(new CalledBalls { CalledBallState_ = "O15State", BallNum_ = 75 });
                                            lastBallCalled.Add("O15State");
                                            break;
                                        }
                                    case 1:
                                        {
                                            O15State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O15State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O15State");
                                            break;
                                        }
                                    case 2:
                                        {
                                            O15State = 0;
                                            foreach (CalledBalls ball in _lastcalled)
                                            {
                                                if (ball.CalledBallState_ == "O15State")
                                                {
                                                    _lastcalled.Remove(ball);
                                                    break;
                                                }
                                            }
                                            lastBallCalled.Remove("O15State");
                                            break;
                                        }
                                }
                                break;
                            }
                            #endregion O's    
                    }

                    // App.flashboardLabels;
                };
            }//End Try
            catch (Exception ex)
            {
                string s = "Error #FB1 - Error calling ball " + TypedBall + ". ErrorMessage: " + ex.Message;

                MessageBox.Show(s);

                using (StreamWriter sw = File.AppendText(App.errorlogPath))
                {
                    DateTime dt = DateTime.Now;
                    sw.WriteLine(dt.ToString() + " -- " + s);
                }
            }
        }

        private Task ChangeLastBallState()
        {
            string temp = lastBallCalled[lastBallCalled.Count - 1];

            switch (temp)
            {
                case "B1State":
                    {
                        B1State = 1;
                        break;
                    }
                case "B2State":
                    {
                        B2State = 1;
                        break;
                    }
                case "B3State":
                    {
                        B3State = 1;
                        break;
                    }
                case "B4State":
                    {
                        B4State = 1;
                        break;
                    }
                case "B5State":
                    {
                        B5State = 1;
                        break;
                    }
                case "B6State":
                    {
                        B6State = 1;
                        break;
                    }
                case "B7State":
                    {
                        B7State = 1;
                        break;
                    }
                case "B8State":
                    {
                        B8State = 1;
                        break;
                    }
                case "B9State":
                    {
                        B9State = 1;
                        break;
                    }
                case "B10State":
                    {
                        B10State = 1;
                        break;
                    }
                case "B11State":
                    {
                        B11State = 1;
                        break;
                    }
                case "B12State":
                    {
                        B12State = 1;
                        break;
                    }
                case "B13State":
                    {
                        B13State = 1;
                        break;
                    }
                case "B14State":
                    {
                        B14State = 1;
                        break;
                    }
                case "B15State":
                    {
                        B15State = 1;
                        break;
                    }

                case "I1State":
                    {
                        I1State = 1;
                        break;
                    }
                case "I2State":
                    {
                        I2State = 1;
                        break;
                    }
                case "I3State":
                    {
                        I3State = 1;
                        break;
                    }
                case "I4State":
                    {
                        I4State = 1;
                        break;
                    }
                case "I5State":
                    {
                        I5State = 1;
                        break;
                    }
                case "I6State":
                    {
                        I6State = 1;
                        break;
                    }
                case "I7State":
                    {
                        I7State = 1;
                        break;
                    }
                case "I8State":
                    {
                        I8State = 1;
                        break;
                    }
                case "I9State":
                    {
                        I9State = 1;
                        break;
                    }
                case "I10State":
                    {
                        I10State = 1;
                        break;
                    }
                case "I11State":
                    {
                        I11State = 1;
                        break;
                    }
                case "I12State":
                    {
                        I12State = 1;
                        break;
                    }
                case "I13State":
                    {
                        I13State = 1;
                        break;
                    }
                case "I14State":
                    {
                        I14State = 1;
                        break;
                    }
                case "I15State":
                    {
                        I15State = 1;
                        break;
                    }
                case "N1State":
                    {
                        N1State = 1;
                        break;
                    }
                case "N2State":
                    {
                        N2State = 1;
                        break;
                    }
                case "N3State":
                    {
                        N3State = 1;
                        break;
                    }
                case "N4State":
                    {
                        N4State = 1;
                        break;
                    }
                case "N5State":
                    {
                        N5State = 1;
                        break;
                    }
                case "N6State":
                    {
                        N6State = 1;
                        break;
                    }
                case "N7State":
                    {
                        N7State = 1;
                        break;
                    }
                case "N8State":
                    {
                        N8State = 1;
                        break;
                    }
                case "N9State":
                    {
                        N9State = 1;
                        break;
                    }
                case "N10State":
                    {
                        N10State = 1;
                        break;
                    }
                case "N11State":
                    {
                        N11State = 1;
                        break;
                    }
                case "N12State":
                    {
                        N12State = 1;
                        break;
                    }
                case "N13State":
                    {
                        N13State = 1;
                        break;
                    }
                case "N14State":
                    {
                        N14State = 1;
                        break;
                    }
                case "N15State":
                    {
                        N15State = 1;
                        break;
                    }

                case "G1State":
                    {
                        G1State = 1;
                        break;
                    }
                case "G2State":
                    {
                        G2State = 1;
                        break;
                    }
                case "G3State":
                    {
                        G3State = 1;
                        break;
                    }
                case "G4State":
                    {
                        G4State = 1;
                        break;
                    }
                case "G5State":
                    {
                        G5State = 1;
                        break;
                    }
                case "G6State":
                    {
                        G6State = 1;
                        break;
                    }
                case "G7State":
                    {
                        G7State = 1;
                        break;
                    }
                case "G8State":
                    {
                        G8State = 1;
                        break;
                    }
                case "G9State":
                    {
                        G9State = 1;
                        break;
                    }
                case "G10State":
                    {
                        G10State = 1;
                        break;
                    }
                case "G11State":
                    {
                        G11State = 1;
                        break;
                    }
                case "G12State":
                    {
                        G12State = 1;
                        break;
                    }
                case "G13State":
                    {
                        G13State = 1;
                        break;
                    }
                case "G14State":
                    {
                        G14State = 1;
                        break;
                    }
                case "G15State":
                    {
                        G15State = 1;
                        break;
                    }
                case "O1State":
                    {
                        O1State = 1;
                        break;
                    }
                case "O2State":
                    {
                        O2State = 1;
                        break;
                    }
                case "O3State":
                    {
                        O3State = 1;
                        break;
                    }
                case "O4State":
                    {
                        O4State = 1;
                        break;
                    }
                case "O5State":
                    {
                        O5State = 1;
                        break;
                    }
                case "O6State":
                    {
                        O6State = 1;
                        break;
                    }
                case "O7State":
                    {
                        O7State = 1;
                        break;
                    }
                case "O8State":
                    {
                        O8State = 1;
                        break;
                    }
                case "O9State":
                    {
                        O9State = 1;
                        break;
                    }
                case "O10State":
                    {
                        O10State = 1;
                        break;
                    }
                case "O11State":
                    {
                        O11State = 1;
                        break;
                    }
                case "O12State":
                    {
                        O12State = 1;
                        break;
                    }
                case "O13State":
                    {
                        O13State = 1;
                        break;
                    }
                case "O14State":
                    {
                        O14State = 1;
                        break;
                    }
                case "O15State":
                    {
                        O15State = 1;
                        break;
                    }
            }

            return Task.CompletedTask;
        }

        #region Verify Card

        #region CardNum

        private string _vcardnum = "";
        public string VCardnum
        {
            get
            {
                return _vcardnum;
            }
            set
            {
                _vcardnum = value;
                OnPropertyChanged(nameof(VCardnum));
            }
        }

        #endregion

        #region B Bindings

        private string _vcontentB1 = "1";
        public string VContentB1
        {
            get
            {
                return _vcontentB1;
            }
            set
            {
                _vcontentB1 = value;
                OnPropertyChanged(nameof(VContentB1));
            }
        }

        private string _vb1State = "";
        public string VB1State
        {
            get
            {
                return _vb1State;
            }
            set
            {
                _vb1State = value;
                OnPropertyChanged(nameof(VB1State));
            }
        }

        private string _vcontentB2 = "2";
        public string VContentB2
        {
            get
            {
                return _vcontentB2;
            }
            set
            {
                _vcontentB2 = value;
                OnPropertyChanged(nameof(VContentB2));
            }
        }
        private string _vb2State = "";

        public string VB2State
        {
            get
            {
                return _vb2State;
            }
            set
            {
                _vb2State = value;
                OnPropertyChanged(nameof(VB2State));
            }
        }

        private string _vcontentB3 = "3";
        public string VContentB3
        {
            get
            {
                return _vcontentB3;
            }
            set
            {
                _vcontentB3 = value;
                OnPropertyChanged(nameof(VContentB3));
            }
        }

        private string _vb3State = "";
        public string VB3State
        {
            get
            {
                return _vb3State;
            }
            set
            {
                _vb3State = value;
                OnPropertyChanged(nameof(VB3State));
            }
        }

        private string _vcontentB4 = "4";
        public string VContentB4
        {
            get
            {
                return _vcontentB4;
            }
            set
            {
                _vcontentB4 = value;
                OnPropertyChanged(nameof(VContentB4));
            }
        }

        private string _vb4State = "";

        public string VB4State
        {
            get
            {
                return _vb4State;
            }
            set
            {
                _vb4State = value;
                OnPropertyChanged(nameof(VB4State));
            }
        }

        private string _vcontentB5 = "5";
        public string VContentB5
        {
            get
            {
                return _vcontentB5;
            }
            set
            {
                _vcontentB5 = value;
                OnPropertyChanged(nameof(VContentB5));
            }
        }


        private string _vb5State = "";

        public string VB5State
        {
            get
            {
                return _vb5State;
            }
            set
            {
                _vb5State = value;
                OnPropertyChanged(nameof(VB5State));
            }
        }

        #endregion B Bindings 

        #region I Bindings

        private string _vcontentI1 = "16";
        public string VContentI1
        {
            get
            {
                return _vcontentI1;
            }
            set
            {
                _vcontentI1 = value;
                OnPropertyChanged(nameof(VContentI1));
            }
        }


        private string _vi1State = "";
        public string VI1State
        {
            get
            {
                return _vi1State;
            }
            set
            {
                _vi1State = value;
                OnPropertyChanged(nameof(VI1State));
            }
        }


        private string _vcontentI2 = "17";
        public string VContentI2
        {
            get
            {
                return _vcontentI2;
            }
            set
            {
                _vcontentI2 = value;
                OnPropertyChanged(nameof(VContentI2));
            }
        }

        private string _vi2State = "";
        public string VI2State
        {
            get
            {
                return _vi2State;
            }
            set
            {
                _vi2State = value;
                OnPropertyChanged(nameof(VI2State));
            }
        }

        private string _vcontentI3 = "18";
        public string VContentI3
        {
            get
            {
                return _vcontentI3;
            }
            set
            {
                _vcontentI3 = value;
                OnPropertyChanged(nameof(VContentI3));
            }
        }


        private string _vi3State = "";
        public string VI3State
        {
            get
            {
                return _vi3State;
            }
            set
            {
                _vi3State = value;
                OnPropertyChanged(nameof(VI3State));
            }
        }

        private string _vcontentI4 = "19";
        public string VContentI4
        {
            get
            {
                return _vcontentI4;
            }
            set
            {
                _vcontentI4 = value;
                OnPropertyChanged(nameof(VContentI4));
            }
        }


        private string _vi4State = "";
        public string VI4State
        {
            get
            {
                return _vi4State;
            }
            set
            {
                _vi4State = value;
                OnPropertyChanged(nameof(VI4State));
            }
        }

        private string _vcontentI5 = "20";
        public string VContentI5
        {
            get
            {
                return _vcontentI5;
            }
            set
            {
                _vcontentI5 = value;
                OnPropertyChanged(nameof(VContentI5));
            }
        }

        private string _vi5State = "";
        public string VI5State
        {
            get
            {
                return _vi5State;
            }
            set
            {
                _vi5State = value;
                OnPropertyChanged(nameof(VI5State));
            }
        }

        #endregion I Bindings

        #region N Bindings

        private string _vcontentN1 = "31";
        public string VContentN1
        {
            get
            {
                return _vcontentN1;
            }
            set
            {
                _vcontentN1 = value;
                OnPropertyChanged(nameof(VContentN1));
            }
        }

        private string _vn1State = "";
        public string VN1State
        {
            get
            {
                return _vn1State;
            }
            set
            {
                _vn1State = value;
                OnPropertyChanged(nameof(VN1State));
            }
        }

        private string _vcontentN2 = "32";
        public string VContentN2
        {
            get
            {
                return _vcontentN2;
            }
            set
            {
                _vcontentN2 = value;
                OnPropertyChanged(nameof(VContentN2));
            }
        }

        private string _vn2State = "";
        public string VN2State
        {
            get
            {
                return _vn2State;
            }
            set
            {
                _vn2State = value;
                OnPropertyChanged(nameof(VN2State));
            }
        }

        private string _vcontentN4 = "34";
        public string VContentN4
        {
            get
            {
                return _vcontentN4;
            }
            set
            {
                _vcontentN4 = value;
                OnPropertyChanged(nameof(VContentN4));
            }
        }
        private string _vn4State = "";
        public string VN4State
        {
            get
            {
                return _vn4State;
            }
            set
            {
                _vn4State = value;
                OnPropertyChanged(nameof(VN4State));
            }
        }

        private string _vcontentN5 = "35";
        public string VContentN5
        {
            get
            {
                return _vcontentN5;
            }
            set
            {
                _vcontentN5 = value;
                OnPropertyChanged(nameof(VContentN5));
            }
        }
        private string _vn5State = "";
        public string VN5State
        {
            get
            {
                return _vn5State;
            }
            set
            {
                _vn5State = value;
                OnPropertyChanged(nameof(VN5State));
            }
        }
        #endregion N Bindings

        #region G Bindings

        private string _vcontentG1 = "46";
        public string VContentG1
        {
            get
            {
                return _vcontentG1;
            }
            set
            {
                _vcontentG1 = value;
                OnPropertyChanged(nameof(VContentG1));
            }
        }

        private string _vg1State = "";
        public string VG1State
        {
            get
            {
                return _vg1State;
            }
            set
            {
                _vg1State = value;
                OnPropertyChanged(nameof(VG1State));
            }
        }


        private string _vcontentG2 = "47";
        public string VContentG2
        {
            get
            {
                return _vcontentG2;
            }
            set
            {
                _vcontentG2 = value;
                OnPropertyChanged(nameof(VContentG2));
            }
        }

        private string _vg2State = "";
        public string VG2State
        {
            get
            {
                return _vg2State;
            }
            set
            {
                _vg2State = value;
                OnPropertyChanged(nameof(VG2State));
            }
        }

        private string _vcontentG3 = "48";
        public string VContentG3
        {
            get
            {
                return _vcontentG3;
            }
            set
            {
                _vcontentG3 = value;
                OnPropertyChanged(nameof(VContentG3));
            }
        }

        private string _vg3State = "";
        public string VG3State
        {
            get
            {
                return _vg3State;
            }
            set
            {
                _vg3State = value;
                OnPropertyChanged(nameof(VG3State));
            }
        }

        private string _vcontentG4 = "49";
        public string VContentG4
        {
            get
            {
                return _vcontentG4;
            }
            set
            {
                _vcontentG4 = value;
                OnPropertyChanged(nameof(VContentG4));
            }
        }

        private string _vg4State = "";
        public string VG4State
        {
            get
            {
                return _vg4State;
            }
            set
            {
                _vg4State = value;
                OnPropertyChanged(nameof(VG4State));
            }
        }

        private string _vcontentG5 = "50";
        public string VContentG5
        {
            get
            {
                return _vcontentG5;
            }
            set
            {
                _vcontentG5 = value;
                OnPropertyChanged(nameof(VContentG5));
            }
        }

        private string _vg5State = "";
        public string VG5State
        {
            get
            {
                return _vg5State;
            }
            set
            {
                _vg5State = value;
                OnPropertyChanged(nameof(VG5State));
            }
        }

        #endregion G Bindings

        #region O Bindings

        private string _vcontentO1 = "66";
        public string VContentO1
        {
            get
            {
                return _vcontentO1;
            }
            set
            {
                _vcontentO1 = value;
                OnPropertyChanged(nameof(VContentO1));
            }
        }

        private string _vo1State = "";
        public string VO1State
        {
            get
            {
                return _vo1State;
            }
            set
            {
                _vo1State = value;
                OnPropertyChanged(nameof(VO1State));
            }
        }

        private string _vcontentO2 = "67";
        public string VContentO2
        {
            get
            {
                return _vcontentO2;
            }
            set
            {
                _vcontentO2 = value;
                OnPropertyChanged(nameof(VContentO2));
            }
        }
        private string _vo2State = "";
        public string VO2State
        {
            get
            {
                return _vo2State;
            }
            set
            {
                _vo2State = value;
                OnPropertyChanged(nameof(VO2State));
            }
        }

        private string _vcontentO3 = "68";
        public string VContentO3
        {
            get
            {
                return _vcontentO3;
            }
            set
            {
                _vcontentO3 = value;
                OnPropertyChanged(nameof(VContentO3));
            }
        }

        private string _vo3State = "";
        public string VO3State
        {
            get
            {
                return _vo3State;
            }
            set
            {
                _vo3State = value;
                OnPropertyChanged(nameof(VO3State));
            }
        }

        private string _vcontentO4 = "69";
        public string VContentO4
        {
            get
            {
                return _vcontentO4;
            }
            set
            {
                _vcontentO4 = value;
                OnPropertyChanged(nameof(VContentO4));
            }
        }

        private string _vo4State = "";
        public string VO4State
        {
            get
            {
                return _vo4State;
            }
            set
            {
                _vo4State = value;
                OnPropertyChanged(nameof(VO4State));
            }
        }

        private string _vcontentO5 = "70";
        public string VContentO5
        {
            get
            {
                return _vcontentO5;
            }
            set
            {
                _vcontentO5 = value;
                OnPropertyChanged(nameof(VContentO5));
            }
        }

        private string _vo5State = "";
        public string VO5State
        {
            get
            {
                return _vo5State;
            }
            set
            {
                _vo5State = value;
                OnPropertyChanged(nameof(VO5State));
            }
        }
        #endregion O Bindings

        public void ColorVerify()
        {

        }

        #endregion



        public void ResetBoard()
        {
            B1State = 0;
            B2State = 0;
            B3State = 0;
            B4State = 0;
            B5State = 0;
            B6State = 0;
            B7State = 0;
            B8State = 0;
            B9State = 0;
            B10State = 0;
            B11State = 0;
            B12State = 0;
            B13State = 0;
            B14State = 0;
            B15State = 0;

            I1State = 0;
            I2State = 0;
            I3State = 0;
            I4State = 0;
            I5State = 0;
            I6State = 0;
            I7State = 0;
            I8State = 0;
            I9State = 0;
            I10State = 0;
            I11State = 0;
            I12State = 0;
            I13State = 0;
            I14State = 0;
            I15State = 0;

            N1State = 0;
            N2State = 0;
            N3State = 0;
            N4State = 0;
            N5State = 0;
            N6State = 0;
            N7State = 0;
            N8State = 0;
            N9State = 0;
            N10State = 0;
            N11State = 0;
            N12State = 0;
            N13State = 0;
            N14State = 0;
            N15State = 0;

            G1State = 0;
            G2State = 0;
            G3State = 0;
            G4State = 0;
            G5State = 0;
            G6State = 0;
            G7State = 0;
            G8State = 0;
            G9State = 0;
            G10State = 0;
            G11State = 0;
            G12State = 0;
            G13State = 0;
            G14State = 0;
            G15State = 0;

            O1State = 0;
            O2State = 0;
            O3State = 0;
            O4State = 0;
            O5State = 0;
            O6State = 0;
            O7State = 0;
            O8State = 0;
            O9State = 0;
            O10State = 0;
            O11State = 0;
            O12State = 0;
            O13State = 0;
            O14State = 0;
            O15State = 0;

            lastBallCalled = new List<string>();
        }

        #endregion

        #endregion MainLabel States

        #region FourBallSection

        private Visibility _fourBallSectionVisibility = Visibility.Hidden;
        public Visibility FourBallSectionVisibility
        {
            get
            {
                return _fourBallSectionVisibility;
            }
            set
            {
                _fourBallSectionVisibility = value;
                OnPropertyChanged(nameof(FourBallSectionVisibility));
            }
        }

        private string _fourBallLbl = "";
        public string FourBallLbl
        {
            get
            {
                return _fourBallLbl;
            }
            set
            {
                _fourBallLbl = value;
                OnPropertyChanged(nameof(FourBallLbl));
            }
        }

        private string _fourBallPrize = "";
        public string FourBallPrize
        {
            get
            {
                return _fourBallPrize;
            }
            set
            {
                _fourBallPrize = value;
                OnPropertyChanged(nameof(FourBallPrize));
            }
        }

        #endregion

    }
}
