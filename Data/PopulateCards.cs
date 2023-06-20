using BingoFlashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Data
{
    public class PopulateCards
    {
        //public PopulateCards() {

        //    string[] lines;
        //    foreach (var cardSetName in App.cardset)
        //    {
        //        switch (cardSetName.Item1.ToString())
        //        {
        //            case "Dab All":
        //                {
        //                    App.cardList = new List<Card>();
        //                    //FOR PUBLISHING
        //                    lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + @"\Data\DabAll.txt");

        //                    //lines = System.IO.File.ReadAllLines(@"Flashboard;/Data/DabAll.txt");
        //                    //FOR TESTING
        //                    //lines = System.IO.File.ReadAllLines(@"../../../Data/DabAll.txt");

        //                    foreach (string s in lines)
        //                    {
        //                        Card c = new Card();
        //                        string[] ssize = s.Split(null);

        //                        //Add each data to card
        //                        c.B1_ = ssize[1];
        //                        c.B2_ = ssize[6];
        //                        c.B3_ = ssize[11];
        //                        c.B4_ = ssize[16];
        //                        c.B5_ = ssize[21];
        //                        c.I1_ = ssize[2];
        //                        c.I2_ = ssize[7];
        //                        c.I3_ = ssize[12];
        //                        c.I4_ = ssize[17];
        //                        c.I5_ = ssize[22];
        //                        c.N1_ = ssize[3];
        //                        c.N2_ = ssize[8];
        //                        c.N3_ = ssize[13];
        //                        c.N4_ = ssize[18];
        //                        c.N5_ = ssize[23];
        //                        c.G1_ = ssize[4];
        //                        c.G2_ = ssize[9];
        //                        c.G3_ = ssize[14];
        //                        c.G4_ = ssize[19];
        //                        c.G5_ = ssize[24];
        //                        c.O1_ = ssize[5];
        //                        c.O2_ = ssize[10];
        //                        c.O3_ = ssize[15];
        //                        c.O4_ = ssize[20];
        //                        c.O5_ = ssize[25];
        //                        c.CardNum_ = ssize[0];

        //                        App.cardList.Add(c);
        //                    }

        //                    Tuple<string, List<Card>> newCardSet = new Tuple<string, List<Card>>(cardSetName.Item1, App.cardList);
        //                    App.temp_cardset.Add(newCardSet);

        //                    break;
        //                }
        //            case "Perfect Paper":
        //                {
        //                    App.cardList = new List<Card>();

        //                    //FOR PUBLISHING

        //                    lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + @"\Data\PerfectPaper.txt");
        //                    //FOR TESTING
        //                    //lines = System.IO.File.ReadAllLines(@"../Data/PerfectPaper.txt");

        //                    foreach (string s in lines)
        //                    {
        //                        Card c = new Card();
        //                        List<string> ssize = new List<string>();

        //                        int chunkSize = 2;
        //                        int stringLength = s.Length;

        //                        for (int i = 0; i < stringLength; i += chunkSize)
        //                        {
        //                            if (i + chunkSize > stringLength)
        //                                chunkSize = stringLength - i;

        //                            ssize.Add(s.Substring(i, chunkSize));

        //                        }

        //                        string cn = ssize[25] + ssize[26] + ssize[27] + ssize[28];
        //                        string cardNum = cn.TrimStart(new char[] { '0' });

        //                        //Add each data to card
        //                        c.B1_ = ssize[0];
        //                        c.B2_ = ssize[1];
        //                        c.B3_ = ssize[2];
        //                        c.B4_ = ssize[3];
        //                        c.B5_ = ssize[4];
        //                        c.I1_ = ssize[5];
        //                        c.I2_ = ssize[6];
        //                        c.I3_ = ssize[7];
        //                        c.I4_ = ssize[8];
        //                        c.I5_ = ssize[9];
        //                        c.N1_ = ssize[10];
        //                        c.N2_ = ssize[11];
        //                        c.N3_ = ssize[12];
        //                        c.N4_ = ssize[13];
        //                        c.N5_ = ssize[14];
        //                        c.G1_ = ssize[15];
        //                        c.G2_ = ssize[16];
        //                        c.G3_ = ssize[17];
        //                        c.G4_ = ssize[18];
        //                        c.G5_ = ssize[19];
        //                        c.O1_ = ssize[20];
        //                        c.O2_ = ssize[21];
        //                        c.O3_ = ssize[22];
        //                        c.O4_ = ssize[23];
        //                        c.O5_ = ssize[24];
        //                        c.CardNum_= cardNum;

        //                        App.cardList.Add(c);
        //                        //App.cardDatabase.Add(c);
        //                    }

        //                    Tuple<string, List<Card>> newCardSet = new Tuple<string, List<Card>>(cardSetName.Item1, App.cardList);
        //                    App.temp_cardset.Add(newCardSet);

        //                    break;
        //                }
        //            case "Perfect Paper R":
        //                {
        //                    App.cardList = new List<Card>();
        //                    //FOR PUBLISHING
        //                    lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + @"\Data\Reliable.txt");


        //                    //lines = System.IO.File.ReadAllLines(@"Flashboard;Data/Reliable.txt");
        //                    //FOR TESTING
        //                    //lines = System.IO.File.ReadAllLines(@"../Data/Reliable.txt");

        //                    foreach (string s in lines)
        //                    {
        //                        Card c = new Card();
        //                        List<string> ssize = new List<string>();

        //                        int chunkSize = 2;
        //                        int stringLength = s.Length;

        //                        for (int i = 0; i < stringLength; i += chunkSize)
        //                        {
        //                            if (i + chunkSize > stringLength)
        //                                chunkSize = stringLength - i;

        //                            ssize.Add(s.Substring(i, chunkSize));

        //                        }

        //                        string cn = ssize[25] + ssize[26] + ssize[27] + ssize[28];
        //                        string cardNum = cn.TrimStart(new char[] { '0' });

        //                        //Add each data to card
        //                        c.B1_ = ssize[0];
        //                        c.B2_ = ssize[1];
        //                        c.B3_ = ssize[2];
        //                        c.B4_ = ssize[3];
        //                        c.B5_ = ssize[4];
        //                        c.I1_ = ssize[5];
        //                        c.I2_ = ssize[6];
        //                        c.I3_ = ssize[7];
        //                        c.I4_ = ssize[8];
        //                        c.I5_ = ssize[9];
        //                        c.N1_ = ssize[10];
        //                        c.N2_ = ssize[11];
        //                        c.N3_ = ssize[12];
        //                        c.N4_ = ssize[13];
        //                        c.N5_ = ssize[14];
        //                        c.G1_ = ssize[15];
        //                        c.G2_ = ssize[16];
        //                        c.G3_ = ssize[17];
        //                        c.G4_ = ssize[18];
        //                        c.G5_ = ssize[19];
        //                        c.O1_ = ssize[20];
        //                        c.O2_ = ssize[21];
        //                        c.O3_ = ssize[22];
        //                        c.O4_ = ssize[23];
        //                        c.O5_ = ssize[24];
        //                        c.CardNum_ = cardNum;

        //                        App.cardList.Add(c);
        //                        //App.cardDatabase.Add(c);
        //                    }

        //                    Tuple<string, List<Card>> newCardSet = new Tuple<string, List<Card>>(cardSetName.Item1, App.cardList);
        //                    App.temp_cardset.Add(newCardSet);

        //                    break;
        //                }
        //            default:
        //                {
        //                    App.cardList = new List<Card>();
        //                    //FOR PUBLISHING
        //                    lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + @"\Data\UniMax.txt");

        //                    //lines = System.IO.File.ReadAllLines(@"Flashboard;Data/UniMax.txt");
        //                    //FOR TESTING
        //                    //lines = System.IO.File.ReadAllLines(@"../../../UniMax.txt");

        //                    foreach (string s in lines)
        //                    {
        //                        Card c = new Card();
        //                        string[] ssize = s.Split(null);

        //                        //Add each data to card
        //                        c.B1_ = ssize[0];
        //                        c.B2_ = ssize[1];
        //                        c.B3_ = ssize[2];
        //                        c.B4_ = ssize[3];
        //                        c.B5_ = ssize[4];
        //                        c.I1_ = ssize[5];
        //                        c.I2_ = ssize[6];
        //                        c.I3_ = ssize[7];
        //                        c.I4_ = ssize[8];
        //                        c.I5_ = ssize[9];
        //                        c.N1_ = ssize[10];
        //                        c.N2_ = ssize[11];
        //                        c.N3_ = ssize[12];
        //                        c.N4_ = ssize[13];
        //                        c.N5_ = ssize[14];
        //                        c.G1_ = ssize[15];
        //                        c.G2_ = ssize[16];
        //                        c.G3_ = ssize[17];
        //                        c.G4_ = ssize[18];
        //                        c.G5_ = ssize[19];
        //                        c.O1_ = ssize[20];
        //                        c.O2_ = ssize[21];
        //                        c.O3_ = ssize[22];
        //                        c.O4_ = ssize[23];
        //                        c.O5_ = ssize[24];
        //                        c.CardNum_ = ssize[25];

        //                        App.cardList.Add(c);
        //                        //App.cardDatabase.Add(c);
        //                    }

        //                    Tuple<string, List<Card>> newCardSet = new Tuple<string, List<Card>>("UniMax", App.cardList);
        //                    App.temp_cardset.Add(newCardSet);
        //                    break;
        //                }
        //        }
        //    }
        //}
    }
}
