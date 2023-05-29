using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace BingoFlashboard.View
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {

        #region classVariables
        //ViewModel.StartViewModel svm;
        public string filepath = "";
        #endregion

        public StartupWindow()
        {
            InitializeComponent();
        }

        private void StartSession_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    App.cardset = new List<Tuple<string, List<Cards>>>();
            //    //READ SESSION FILE
            //    string[] lines = System.IO.File.ReadAllLines(filepath);

            //    Sessions s = new Sessions();
            //    Game newGame = new Game();

            //    foreach (string l in lines)
            //    {
            //        string[] words;
            //        string[] str;

            //        switch (l)
            //        {
            //            case "//":
            //                {
            //                    newGame = new Game();
            //                    break;
            //                }
            //            case "ENDGAME":
            //                {
            //                    if (newGame.FontColor == "")
            //                    {
            //                        newGame.FontColor = "White";
            //                    }
            //                    s.Games.Add(newGame);
            //                    break;
            //                }
            //            case "ENDSESSION":
            //                {
            //                    break;
            //                }
            //        }

            //        if (l.Contains('"'))
            //        {
            //            words = l.Split(' ');
            //            str = l.Split('"');

            //            switch (words[0])
            //            {
            //                case "SESSIONNAME:":
            //                    {
            //                        s.SessionName = str[1];
            //                        break;
            //                    }
            //                case "BORDERCOLOR:":
            //                    {
            //                        newGame.BorderColor = str[1];
            //                        break;
            //                    }
            //                case "FONTCOLOR:":
            //                    {
            //                        newGame.FontColor = str[1];
            //                        break;
            //                    }
            //                case "GAMENAME:":
            //                    {
            //                        newGame.Name = str[1];
            //                        break;
            //                    }
            //                case "GAMETYPE:":
            //                    {
            //                        newGame.GameType = str[1];
            //                        break;
            //                    }
            //                case "PATTERN:":
            //                    {
            //                        newGame.Patterns = str[1];
            //                        break;
            //                    }
            //                case "CONDITION:":
            //                    {
            //                        newGame.Condition = str[1];
            //                        break;
            //                    }
            //                case "PRIZE:":
            //                    {
            //                        newGame.Prize = str[1];
            //                        break;
            //                    }
            //                case "JACKPOTPRIZE:":
            //                    {
            //                        newGame.JackpotPrize = str[1];
            //                        break;
            //                    }
            //                case "DESIGNATEDNUM:":
            //                    {
            //                        newGame.DesignatedNumber = str[1];
            //                        break;
            //                    }
            //                case "COMPORT:":
            //                    {
            //                        App.hall.Comport_ = str[1];
            //                        break;
            //                    }
            //                case "BINGOHALL:":
            //                    {
            //                        App.hall.Name_ = str[1];
            //                        break;
            //                    }
            //                case "CARDSET:":
            //                    {
            //                        //Adds just the name to the bingohall cardset
            //                        App.hall.CardsetsNames_.Add(str[1]);

            //                        //Adds new combobox item to the bingohall cardset
            //                        //ComboBoxItem item = new ComboBoxItem { Content = str[1] };
            //                        App.hall.AddToCardset(str[1]);
            //                        App.cardset.Add(new Tuple<string, List<Cards>>(str[1], new List<Cards>()));
            //                        break;
            //                    }
            //                case "FLASHBOARDMESSAGE:":
            //                    {
            //                        App.hall.Message_ = str[1];
            //                        break;
            //                    }
            //                case "ENABLEAUTOCALLER:":
            //                    {
            //                        if (str[1] == "true" || str[1] == "True" || str[1] == "TRUE")
            //                            App.hall.AutoCaller_ = true;
            //                        else
            //                        {
            //                            App.hall.AutoCaller_ = false;
            //                        }
            //                        break;
            //                    }
            //                case "PHONENUM:":
            //                    {
            //                        App.hall.Phone_ = str[1];
            //                        break;
            //                    }
            //            }
            //        }
            //    }

            //    App.session = s;

            //    if (App.hall.Comport_ == "")
            //        App.hall.Comport_ = "COM3";

            //    App.fbvm = new ViewModel.FlashboardViewModel();

            //    App.flashboardWindow = new FlashboardWindow();
            //    App.flashboardWindow.Top = 0;
            //    App.flashboardWindow.Left = 0;

            //    App.gameDataWindow = new GameData();
            //    App.gameDataWindow.PopulateCards();
            //    App.gameDataWindow.PopulateGameData();
            //    App.gameDataWindow.Show();
            //    App.verifyCardWindow.Show();

            //    //App.timerWindow.Show();

            //    App.flashboardWindow.Show();
            //    this.Hide();


            //    //App.jsonControls.GetAllJsonFileNames();

            //    //App.jsonControls.BingoHallToJson(App.hall);
            //    //App.jsonControls.ReadJsonFile(App.hall.name + ".json");

            //}
            //catch (Exception ex)
            //{
            //    string s = "Error Code #4: ";
            //    MessageBox.Show(s + ex.Message);

            //    using (StreamWriter sw = File.AppendText(App.errorlogPath))
            //    {
            //        DateTime dt = DateTime.Now;
            //        sw.WriteLine(dt.ToString() + " -- " + s + ex.Message);
            //    }
            //}
        }

        private void LoadSessionBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == true)
                {
                    filepath = openFileDialog.FileName;

                    string[] lines = System.IO.File.ReadAllLines(filepath);

                    string sessionTxt = @"//SESSION//";
                    if (lines[0] != sessionTxt)
                    {
                        MessageBox.Show("File not regonized. Not a recgonized Session");
                    }
                    else
                    {
                        // svm.FileName = openFileDialog.SafeFileName;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Error: File not regonized");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();

        }
    }
}
