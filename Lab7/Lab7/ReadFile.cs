using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab7
{
    public class ReadFile
    {
        
        public static void ReadAction(string pathToFile, string checkWord) {
            StreamReader sr = new StreamReader(pathToFile);

            //Console.WriteLine(sr.ReadToEnd());

            //sr.BaseStream.Position = 0;
            //Console.WriteLine("----------------");

            string fileName = Path.GetFileName(pathToFile);

            int lineCount = File.ReadLines(pathToFile).Count(); 
            string line = "";
            int i = 0;

            int percentage = 0;
            int total = 0;
            while ((line = sr.ReadLine()) != null)
            {
                int count = new Regex(Regex.Escape(checkWord)).Matches(line).Count;
                //Console.WriteLine(i + " " + line + " " + count);
                i++;
                total = total + count;
                //percentage += lineCount / 100;
                percentage += 100 / lineCount;
                Console.WriteLine(/*pathToFile*/fileName + " - оброблено "+percentage+"%");
            }
            if (percentage != 100)
                Console.WriteLine(/*pathToFile*/fileName + " - оброблено " + 100 + "%");
            Console.WriteLine("File ("+fileName+") TOTAL: " + total);
            //Console.WriteLine("LineCount: " + lineCount);
            sr.Close();
        }
    }
}
