using BingoFlashboard.Model;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BingoFlashboard.Data
{
    public class LoadAllPatterns
    {
        string fileName = @"C:\Temp\Patterns.txt";
        internal List<Pattern>? patternList;

        public LoadAllPatterns()
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);

                List<Pattern>? patternList = JsonConvert.DeserializeObject<List<Pattern>>(json);
                if (patternList != null)
                {
                    List<Pattern> temp = patternList.ToList();
                    List<Pattern> SortedList = temp.OrderBy(o => o.Pattern_Name_).ToList();
                    App.allPatterns = SortedList;
                }
            }
        }
    }
}
