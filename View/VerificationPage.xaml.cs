﻿using BingoFlashboard.Model.FlashboardModels;
using BingoFlashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace BingoFlashboard.View
{
    /// <summary>
    /// Interaction logic for VerificationPage.xaml
    /// </summary>
    public partial class VerificationPage : Page
    {
        public static List<Tuple<string, List<Card>>> temp_cardset = new();
        public static List<Card> cardList = new();
        public static Card selectedCard = new();
        private static List<CardNumbers> cardNums = new();
        

        public VerificationPage()
        {
            InitializeComponent();

            //PopuateCards();
        }

        public VerificationPage(int fontSize)
        {
            InitializeComponent();

            //CHANGE FONTSIZE FOR ALL LABELS
            B1.FontSize = fontSize;
            B2.FontSize = fontSize;
            B3.FontSize = fontSize;
            B4.FontSize = fontSize;
            B5.FontSize = fontSize;
            I1.FontSize = fontSize;
            I2.FontSize = fontSize;
            I3.FontSize = fontSize;
            I4.FontSize = fontSize;
            I5.FontSize = fontSize;
            N1.FontSize = fontSize;
            N2.FontSize = fontSize;
            N3.FontSize = 22;
            N4.FontSize = fontSize;
            N5.FontSize = fontSize;
            G1.FontSize = fontSize;
            G2.FontSize = fontSize;
            G3.FontSize = fontSize;
            G4.FontSize = fontSize;
            G5.FontSize = fontSize;
            O1.FontSize = fontSize;
            O2.FontSize = fontSize;
            O3.FontSize = fontSize;
            O4.FontSize = fontSize;
            O5.FontSize = fontSize;
        }
        
        public void VerifyCard()
        {
            string? s = "";

            foreach (var v in temp_cardset)
            {
                if (v.Item1 == s)
                {
                    cardList = v.Item2;
                    break;
                }
            }
        }

        public void PopuateCards()
        {
            string[] lines;
            if(App.SelectedSession is not null && App.SelectedSession.Program_ is not null && App.SelectedSession.Program_.Cardsets_ is not null)
            foreach (Cardset cs in App.SelectedSession.Program_.Cardsets_)
                {
                    if (cs.Set_Name_ == "DabAll" || cs.Set_Name_ == "Dab All" || cs.Set_Name_ == "DabAll.txt")
                    {
                        cardList = new List<Card>();
                        //FOR PUBLISHING
                        lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + @"\Data\DabAll.txt");

                        //lines = System.IO.File.ReadAllLines(@"Flashboard;/Data/DabAll.txt");
                        //FOR TESTING
                        //lines = System.IO.File.ReadAllLines(@"../../../Data/DabAll.txt");

                        foreach (string s in lines)
                        {
                            Card c = new Card();
                            string[] ssize = s.Split(null);

                            //Add each data to card
                            c.B1_ = ssize[1];
                            c.B2_ = ssize[6];
                            c.B3_ = ssize[11];
                            c.B4_ = ssize[16];
                            c.B5_ = ssize[21];
                            c.I1_ = ssize[2];
                            c.I2_ = ssize[7];
                            c.I3_ = ssize[12];
                            c.I4_ = ssize[17];
                            c.I5_ = ssize[22];
                            c.N1_ = ssize[3];
                            c.N2_ = ssize[8];
                            c.N3_ = ssize[13];
                            c.N4_ = ssize[18];
                            c.N5_ = ssize[23];
                            c.G1_ = ssize[4];
                            c.G2_ = ssize[9];
                            c.G3_ = ssize[14];
                            c.G4_ = ssize[19];
                            c.G5_ = ssize[24];
                            c.O1_ = ssize[5];
                            c.O2_ = ssize[10];
                            c.O3_ = ssize[15];
                            c.O4_ = ssize[20];
                            c.O5_ = ssize[25];
                            c.CardNum_ = ssize[0];

                            cardList.Add(c);
                        }

                        Tuple<string, List<Card>> newCardSet = new Tuple<string, List<Card>>("DabAll", cardList);
                        temp_cardset.Add(newCardSet);
                    } // END IF = DABALL
                    else if (cs.Set_Name_ == "Perfect Paper")
                    {

                        cardList = new List<Card>();

                        //FOR PUBLISHING

                        lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + @"\Data\PerfectPaper.txt");
                        //FOR TESTING
                        //lines = System.IO.File.ReadAllLines(@"../Data/PerfectPaper.txt");

                        foreach (string s in lines)
                        {
                            Card c = new Card();
                            List<string> ssize = new List<string>();

                            int chunkSize = 2;
                            int stringLength = s.Length;

                            for (int i = 0; i < stringLength; i += chunkSize)
                            {
                                if (i + chunkSize > stringLength)
                                    chunkSize = stringLength - i;

                                ssize.Add(s.Substring(i, chunkSize));

                            }

                            string cn = ssize[25] + ssize[26] + ssize[27] + ssize[28];
                            string cardNum = cn.TrimStart(new char[] { '0' });

                            //Add each data to card
                            c.B1_ = ssize[0];
                            c.B2_ = ssize[1];
                            c.B3_ = ssize[2];
                            c.B4_ = ssize[3];
                            c.B5_ = ssize[4];
                            c.I1_ = ssize[5];
                            c.I2_ = ssize[6];
                            c.I3_ = ssize[7];
                            c.I4_ = ssize[8];
                            c.I5_ = ssize[9];
                            c.N1_ = ssize[10];
                            c.N2_ = ssize[11];
                            c.N3_ = ssize[12];
                            c.N4_ = ssize[13];
                            c.N5_ = ssize[14];
                            c.G1_ = ssize[15];
                            c.G2_ = ssize[16];
                            c.G3_ = ssize[17];
                            c.G4_ = ssize[18];
                            c.G5_ = ssize[19];
                            c.O1_ = ssize[20];
                            c.O2_ = ssize[21];
                            c.O3_ = ssize[22];
                            c.O4_ = ssize[23];
                            c.O5_ = ssize[24];
                            c.CardNum_ = cardNum;

                            cardList.Add(c);
                            //App.cardDatabase.Add(c);
                        }

                        Tuple<string, List<Card>> newCardSet = new Tuple<string, List<Card>>("PerfectPaper", cardList);
                        temp_cardset.Add(newCardSet);
                    }// END IF PERFECT PAPER
                    else if (cs.Set_Name_ == "Perfect Paper R")
                    {
                        cardList = new List<Card>();
                        //FOR PUBLISHING
                        lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + @"\Data\Reliable.txt");


                        //lines = System.IO.File.ReadAllLines(@"Flashboard;Data/Reliable.txt");
                        //FOR TESTING
                        //lines = System.IO.File.ReadAllLines(@"../Data/Reliable.txt");

                        foreach (string s in lines)
                        {
                            Card c = new Card();
                            List<string> ssize = new List<string>();

                            int chunkSize = 2;
                            int stringLength = s.Length;

                            for (int i = 0; i < stringLength; i += chunkSize)
                            {
                                if (i + chunkSize > stringLength)
                                    chunkSize = stringLength - i;

                                ssize.Add(s.Substring(i, chunkSize));

                            }

                            string cn = ssize[25] + ssize[26] + ssize[27] + ssize[28];
                            string cardNum = cn.TrimStart(new char[] { '0' });

                            //Add each data to card
                            c.B1_ = ssize[0];
                            c.B2_ = ssize[1];
                            c.B3_ = ssize[2];
                            c.B4_ = ssize[3];
                            c.B5_ = ssize[4];
                            c.I1_ = ssize[5];
                            c.I2_ = ssize[6];
                            c.I3_ = ssize[7];
                            c.I4_ = ssize[8];
                            c.I5_ = ssize[9];
                            c.N1_ = ssize[10];
                            c.N2_ = ssize[11];
                            c.N3_ = ssize[12];
                            c.N4_ = ssize[13];
                            c.N5_ = ssize[14];
                            c.G1_ = ssize[15];
                            c.G2_ = ssize[16];
                            c.G3_ = ssize[17];
                            c.G4_ = ssize[18];
                            c.G5_ = ssize[19];
                            c.O1_ = ssize[20];
                            c.O2_ = ssize[21];
                            c.O3_ = ssize[22];
                            c.O4_ = ssize[23];
                            c.O5_ = ssize[24];
                            c.CardNum_ = cardNum;

                            cardList.Add(c);
                            //App.cardDatabase.Add(c);
                        }

                        Tuple<string, List<Card>> newCardSet = new Tuple<string, List<Card>>("PerfectPaperR", cardList);
                        temp_cardset.Add(newCardSet);
                    }// END IF PERFECT PAPER R
                    else
                    {
                        cardList = new List<Card>();
                        //FOR PUBLISHING
                        lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + @"\Data\UniMax.txt");

                        //lines = System.IO.File.ReadAllLines(@"Flashboard;Data/UniMax.txt");
                        //FOR TESTING
                        //lines = System.IO.File.ReadAllLines(@"../../../UniMax.txt");

                        foreach (string s in lines)
                        {
                            Card c = new Card();
                            string[] ssize = s.Split(null);

                            //Add each data to card
                            c.B1_ = ssize[0];
                            c.B2_ = ssize[1];
                            c.B3_ = ssize[2];
                            c.B4_ = ssize[3];
                            c.B5_ = ssize[4];
                            c.I1_ = ssize[5];
                            c.I2_ = ssize[6];
                            c.I3_ = ssize[7];
                            c.I4_ = ssize[8];
                            c.I5_ = ssize[9];
                            c.N1_ = ssize[10];
                            c.N2_ = ssize[11];
                            c.N3_ = ssize[12];
                            c.N4_ = ssize[13];
                            c.N5_ = ssize[14];
                            c.G1_ = ssize[15];
                            c.G2_ = ssize[16];
                            c.G3_ = ssize[17];
                            c.G4_ = ssize[18];
                            c.G5_ = ssize[19];
                            c.O1_ = ssize[20];
                            c.O2_ = ssize[21];
                            c.O3_ = ssize[22];
                            c.O4_ = ssize[23];
                            c.O5_ = ssize[24];
                            c.CardNum_ = ssize[25];

                            cardList.Add(c);
                            //App.cardDatabase.Add(c);
                        }

                        Tuple<string, List<Card>> newCardSet = new Tuple<string, List<Card>>("UniMax", cardList);
                        temp_cardset.Add(newCardSet);
                    }


                }
        }

        //public void SelectCard(string cardNum)
        //{
        //    foreach (Card card in cardList)
        //    {
        //        if (card.CardNum_ == cardNum)
        //        {
        //            selectedCard = card;
        //            break;
        //        }
        //    }
        //    LoadCard();
        //}

        public Task SelectCard(string cardNum, string cardset)
        {
            bool found = false;
            foreach (Tuple<string, List<Card>> set in temp_cardset)
            {
                if (String.Equals(set.Item1, cardset, StringComparison.OrdinalIgnoreCase))
                {
                    foreach (Card card in set.Item2)
                    {
                        if (card.CardNum_ == cardNum)
                        {
                            found = true;
                            selectedCard = card;
                            break;
                        }
                    }
                }
            }
            if(found)
            LoadCard();
            return Task.CompletedTask;
        }

        public void LoadCard()
        {
            CardNumbers num = new CardNumbers();
            cardNums = new();

            if (selectedCard is not null && selectedCard.CardNum_ is not "")
            {
                if (App.callerWindowViewModel is not null)
                {
                    App.callerWindowViewModel.CardNum_ = selectedCard.CardNum_;
                }
                B1.Content = selectedCard.B1_;
                num.Name = "B1";
                num.Value = selectedCard.B1_;
                cardNums.Add(num);

                B2.Content = selectedCard.B2_;
                num = new CardNumbers();
                num.Name = "B2";
                num.Value = selectedCard.B2_;
                cardNums.Add(num);

                B3.Content = selectedCard.B3_;
                num = new CardNumbers();
                num.Name = "B3";
                num.Value = selectedCard.B3_;
                cardNums.Add(num);

                B4.Content = selectedCard.B4_;
                num = new CardNumbers();
                num.Name = "B4";
                num.Value = selectedCard.B4_;
                cardNums.Add(num);

                B5.Content = selectedCard.B5_;
                num = new CardNumbers();
                num.Name = "B5";
                num.Value = selectedCard.B5_;
                cardNums.Add(num);

                I1.Content = selectedCard.I1_;
                num = new CardNumbers();
                num.Name = "I1";
                num.Value = selectedCard.I1_;
                cardNums.Add(num);

                I2.Content = selectedCard.I2_;
                num = new CardNumbers();
                num.Name = "I2";
                num.Value = selectedCard.I2_;
                cardNums.Add(num);

                I3.Content = selectedCard.I3_;
                num = new CardNumbers();
                num.Name = "I3";
                num.Value = selectedCard.I3_;
                cardNums.Add(num);

                I4.Content = selectedCard.I4_;
                num = new CardNumbers();
                num.Name = "I4";
                num.Value = selectedCard.I4_;
                cardNums.Add(num);

                I5.Content = selectedCard.I5_;
                num = new CardNumbers();
                num.Name = "I5";
                num.Value = selectedCard.I5_;
                cardNums.Add(num);

                N1.Content = selectedCard.N1_;
                num = new CardNumbers();
                num.Name = "N1";
                num.Value = selectedCard.N1_;
                cardNums.Add(num);

                N2.Content = selectedCard.N2_;
                num = new CardNumbers();
                num.Name = "N2";
                num.Value = selectedCard.N2_;
                cardNums.Add(num);

                N3.Content = selectedCard.CardNum_;
                num = new CardNumbers();
                num.Name = "N3";
                num.Value = selectedCard.CardNum_;
                num.Called = true;
                cardNums.Add(num);

                N4.Content = selectedCard.N4_;
                num = new CardNumbers();
                num.Name = "N4";
                num.Value = selectedCard.N4_;
                cardNums.Add(num);

                N5.Content = selectedCard.N5_;
                num = new CardNumbers();
                num.Name = "N5";
                num.Value = selectedCard.N5_;
                cardNums.Add(num);

                G1.Content = selectedCard.G1_;
                num = new CardNumbers();
                num.Name = "G1";
                num.Value = selectedCard.G1_;
                cardNums.Add(num);

                G2.Content = selectedCard.G2_;
                num = new CardNumbers();
                num.Name = "G2";
                num.Value = selectedCard.G2_;
                cardNums.Add(num);

                G3.Content = selectedCard.G3_;
                num = new CardNumbers();
                num.Name = "G3";
                num.Value = selectedCard.G3_;
                cardNums.Add(num);

                G4.Content = selectedCard.G4_;
                num = new CardNumbers();
                num.Name = "G4";
                num.Value = selectedCard.G4_;
                cardNums.Add(num);

                G5.Content = selectedCard.G5_;
                num = new CardNumbers();
                num.Name = "G5";
                num.Value = selectedCard.G5_;
                cardNums.Add(num);

                O1.Content = selectedCard.O1_;
                num = new CardNumbers();
                num.Name = "O1";
                num.Value = selectedCard.O1_;
                cardNums.Add(num);

                O2.Content = selectedCard.O2_;
                num = new CardNumbers();
                num.Name = "O2";
                num.Value = selectedCard.O2_;
                cardNums.Add(num);

                O3.Content = selectedCard.O3_;
                num = new CardNumbers();
                num.Name = "O3";
                num.Value = selectedCard.O3_;
                cardNums.Add(num);

                O4.Content = selectedCard.O4_;
                num = new CardNumbers();
                num.Name = "O4";
                num.Value = selectedCard.O4_;
                cardNums.Add(num);

                O5.Content = selectedCard.O5_;
                num = new CardNumbers();
                num.Name = "O5";
                num.Value = selectedCard.O5_;
                cardNums.Add(num);
            }
        }

        public void HighlightCard(List<string> calls)
        {
            // Create an array or list of all your labels
            Label[] allLabels = { B1, B2, B3, B4, B5, I1, I2, I3, I4, I5,
                          N1, N2, N3, N4, N5, G1, G2, G3, G4, G5,
                          O1, O2, O3, O4, O5 };

            string lastCall = App.Calls.LastOrDefault();


            // Iterate through each label
            foreach (var label in allLabels)
            {
                // Check if the label's content is in the calls list
                if (calls.Contains(label.Content.ToString()))
                {
                    // Further check if it is the last or default call
                    label.Background = new SolidColorBrush(label.Content.ToString() == lastCall
                        ? Colors.DodgerBlue
                        : Colors.DarkGoldenrod);
                }
                else
                {
                    label.Background = new SolidColorBrush(Colors.LightGray);
                }
            }
        }

        public bool CheckWinner()
        {
            bool success = false;
            string lastCalled = "";
            foreach (CardNumbers num in cardNums)
            {
                if (App.Calls.Contains(num.Value.ToString()) || num.Called)
                { 
                    num.Called = true;

                    if (num.Value.ToString() == App.Calls.LastOrDefault())
                    {
                        lastCalled = num.Name.ToString(); // Save to TempString
                    }
                }
                else
                    num.Called = false;
            }



            List<string> tempList = new();
            foreach (CardNumbers num in cardNums)
            {
                if (num.Called)
                    tempList.Add(num.Name.ToString());
            }

            if (App.SelectedGame is not null && App.SelectedGame.Pattern_ is not null && App.SelectedGame.Pattern_.Pattern_ is not null)
            {
                foreach (var pattern in App.SelectedGame.Pattern_.Pattern_)
                {
                    bool patternMatch = true;

                    foreach (string p in pattern)
                    {
                        if (!tempList.Contains(p))
                        {
                            patternMatch = false;
                            break;
                        }
                    }

                    if (patternMatch)
                    {
                        //TODO Add pattern to winner list
                        success = true;
                        List<string> successfulPattern = pattern;
                        ColorWinner(pattern, lastCalled);

                    }
                }
            }
            return success;
        }

        public async Task<bool> CheckMobileWinner(string cardNum, string cardset)
        {
            await SelectCard(cardNum, "UniMax");
            //await SelectCard(cardNum, cardset);
            bool success = false;

            foreach (CardNumbers num in cardNums)
            {
                if (App.Calls.Contains(num.Value.ToString()) || num.Called)
                    num.Called = true;

                else
                    num.Called = false;
            }

            List<string> tempList = new();
            foreach (CardNumbers num in cardNums)
            {
                if (num.Called)
                    tempList.Add(num.Name.ToString());
            }

            if (App.SelectedGame is not null && App.SelectedGame.Pattern_ is not null && App.SelectedGame.Pattern_.Pattern_ is not null)
            {
                foreach (var pattern in App.SelectedGame.Pattern_.Pattern_)
                {
                    bool patternMatch = true;

                    foreach (string p in pattern)
                    {
                        if (!tempList.Contains(p))
                        {
                            patternMatch = false;
                            break;
                        }
                    }

                    if (patternMatch)
                    {
                        success = true;
                        List<string> successfulPattern = pattern;
                    }
                }
            }
            return success;
        }


        private void ColorWinner(List<string> list, string lastCalled)
        {
            SolidColorBrush lastCalledColor = new SolidColorBrush(Colors.DodgerBlue); // or any other color you prefer

            // Define the standard color for other labels
            SolidColorBrush standardColor = new SolidColorBrush(Colors.DarkGreen);

            // A helper action to set the background color of a label
            Action<Label, string> setColor = (label, labelName) =>
            {
                if (list.Contains(labelName))
                {
                    label.Background = labelName == lastCalled ? lastCalledColor : standardColor;
                }
            };

            // Set colors for each label
            setColor(B1, "B1");
            setColor(B2, "B2");
            setColor(B3, "B3");
            setColor(B4, "B4");
            setColor(B5, "B5");
            setColor(I1, "I1");
            setColor(I2, "I2");
            setColor(I3, "I3");
            setColor(I4, "I4");
            setColor(I5, "I5");
            setColor(N1, "N1");
            setColor(N2, "N2");
            setColor(N3, "N3");
            setColor(N4, "N4");
            setColor(N5, "N5");
            setColor(G1, "G1");
            setColor(G2, "G2");
            setColor(G3, "G3");
            setColor(G4, "G4");
            setColor(G5, "G5");
            setColor(O1, "O1");
            setColor(O2, "O2");
            setColor(O3, "O3");
            setColor(O4, "O4");
            setColor(O5, "O5");
        }
    }
}
