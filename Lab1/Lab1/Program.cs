using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public enum TimeFrame { Year, TwoYears, Long }

    class Program
    {

        static void Main(string[] args)
        {
            
            Console.WriteLine("Vvedit rozmirnist' cherez , abo ;");
            string LenLine = Console.ReadLine();

            string [] LineMas = null;

            for (int i = 0; i < LenLine.Length; i++) {
                if (LenLine[i] == ',')
                {
                    LineMas = LenLine.Split(',');
                }
                else if (LenLine[i] == ';')
                {
                    LineMas = LenLine.Split(';');
                }
            }

            int nRows = Int32.Parse(LineMas[0].Trim());
            int nColumns = Int32.Parse(LineMas[1].Trim());

            
            Paper[] arr1 = new Paper[nColumns];

            

            for (int i = 0; i < arr1.Length; i++) {
                arr1[i] = new Paper();
            }

            int StartInt1 = Environment.TickCount;

            for (int i = 0; i < arr1.Length; i++) {
                arr1[i].publicationName = "Publication " + (i + 1);
                arr1[i].author = new Person("David", "Hunt",new DateTime(1975,3,9));

                //Console.WriteLine(i+" ");
            }

            int EndInt1 = Environment.TickCount;

            int diff = EndInt1 - StartInt1;

            Console.WriteLine("First Time in ms: " + diff);
            

            //----------------------------------------

            Paper[,] arr2 = new Paper[nRows, nColumns];

            for (int i = 0; i < nRows; i++) {
                for (int j = 0; j < nColumns; j++) {
                    arr2[i, j] = new Paper();
                }
            }


            int Start2 = Environment.TickCount;

            for (int i = 0; i < nRows; i++) {
                for (int j = 0; j < nColumns; j++) {
                    arr2[i, j].publicationName = "Publication " + 2 * (i + 1);
                    arr2[i, j].author = new Person("George", "Fox", new DateTime(1987, 4, 4));
                }
            }

            int End2 = Environment.TickCount;

            diff = End2 - Start2;

            Console.WriteLine("Second Time in ms: " + diff);
            //-----------------------------------------
            Paper[][] arr3 = new Paper[nRows][];
            for (int i = 0; i < nRows; i++) {
                arr3[i] = new Paper[i + 1];    
            }

            for (int i = 0; i < nRows; i++) {
                for (int j = 0; j < arr3[i].Length; j++) {
                    arr3[i][j] = new Paper();
                }
            }

            int StartInt3 = Environment.TickCount;

            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < arr3[i].Length; j++)
                {
                    arr3[i][j].publicationName = "Publication " + (i + 1) * 3;
                    arr3[i][j].author = new Person("Stewart", "Young", new DateTime(1991,10,25));
                }                
            }

            int EndInt3 = Environment.TickCount;

            diff = EndInt3 - StartInt3;

            Console.WriteLine("Third Time in ms: " + diff);

            


            ResearchTeam rt = new ResearchTeam("GroupOrange","Orange",57039,TimeFrame.TwoYears);

            Console.WriteLine("\nResearch Group GroupOrange INFO: " + rt.ToShortString());

            Console.WriteLine("\n\nIndexer demonstration:\n");

            Console.WriteLine("Long: " + rt[TimeFrame.Long]);

            Console.WriteLine("Two Years: " + rt[TimeFrame.TwoYears]);

            Console.WriteLine("Year: " + rt[TimeFrame.Year]);



            Console.WriteLine("\n\nGroupOrange INFO: " + rt.ToString());


            Paper[] papers = new Paper[2];
            
            papers[0] = new Paper("Part I: Note1", new Person("James", "Smith", new DateTime(1985,5,1)),new DateTime(2001,8,25));
            papers[1] = new Paper("Part XI: Extended", new Person("Edwin","Weet",new DateTime(1976,2,7)),new DateTime(1996,3,14));

            rt.AddPapers(papers);

            Console.WriteLine("\n\nGroupOrange Added New Papers: \n" + rt.ToString());

            Console.WriteLine("Last Publication: \n");
            Console.WriteLine(rt.LastPublication.ToString());


            Console.ReadKey();
        }
    }
}
