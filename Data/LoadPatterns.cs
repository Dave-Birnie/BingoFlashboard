using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Global_Models_Library.Flashboard_Models;
using Newtonsoft.Json;

namespace BingoFlashboard.Data
{
    public class LoadPatterns
    {
        //DEMO
        //string fileName = @"C:\Temp\PatternsTest.txt";
        string fileName = Environment.CurrentDirectory + @"\Data\PatternsTest.txt";
        public List<Pattern> patternList;


        public LoadPatterns()
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);

                List<Pattern>? patternList = JsonConvert.DeserializeObject<List<Pattern>>(json);
                if (patternList != null)
                    App.allPatterns = patternList.ToList();
            }
        }


        public void SavePatterns()
        {
            string json = JsonConvert.SerializeObject(App.allPatterns);
            File.WriteAllText(fileName, json);   
        }
    }
}
