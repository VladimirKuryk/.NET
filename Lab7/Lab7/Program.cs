using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {

        static void Main(string[] args)
        {
            //string pathToFile = @"D:\STUDY\Course 4 University\NET\Lab7\Lab7\TextFiles\f1.txt";
            //string checkWord = "hey";

            //ReadFile.ReadAction(pathToFile, "hey");

            /*AddThread t1 = new AddThread(pathToFile, "hey");
            Console.WriteLine("First Res");

            AddThread t2 = new AddThread(pathToFile, "hey");
            Console.WriteLine("Second Res");*/
            Console.WriteLine("Write down word for searching: ");
            string checkWord = Console.ReadLine();
            string pathToDirectory = "D:\\STUDY\\Course 4 University\\NET\\Lab7\\Lab7\\TextFiles";

            var txtFiles = Directory.EnumerateFiles(pathToDirectory, "*.txt");
            foreach (string currentFile in txtFiles) {
                AddThread t1 = new AddThread(currentFile, checkWord);   
            }

            Console.ReadLine();
        }
    }
}
