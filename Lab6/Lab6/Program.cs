using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        public static Result Couple(Human human1, Human human2)
        {
            Result result = new Result();
            string child = "";

            bool book = false;

            bool h1like = false;
            bool h2like = false;
            foreach(CoupleAttribute h1 in human1.partOfPair())
            {
                foreach(CoupleAttribute h2 in human2.partOfPair()) {
                    //Console.WriteLine(human2.GetType().Name);
                    //Console.WriteLine(human1.GetType().Name);
                    if ( (h1.Pair == human2.GetType().Name) && (h2.Pair == human1.GetType().Name )) { 
                        if (h1.Probability >= 0.5) { 
                            h1like = true;
                            child = h1.ChildType;
                        }
                        if (h2.Probability >= 0.5)
                            h2like = true;
                    }
                }
            }

            SortedSet<string> bookSet = new SortedSet<string>();
            bookSet.Add("Botan");
            bookSet.Add("SmartGirl");

            if (bookSet.Contains(human1.GetType().Name) && bookSet.Contains(human2.GetType().Name)) {
                /*System.Reflection.PropertyInfo pInfo;
                Type type = typeof(Book);
                pInfo = type.GetProperty("Name");
                string name = (string)pInfo.GetValue(human2);*/
                string name = "Book";
                
                result.ClassType = "Book";
                result.Name = "Book";
                result.Like = false;
                return result;
            }
            else { 
                if ((h1like == true) && (h2like == true))
                {
                /*foreach (CoupleAttribute h2 in human2.partOfPair()) {
                    child = h2.ChildType;
                }*/

                //System.Reflection.FieldInfo r = typeof(Human).GetField("Name");
                //System.Reflection.MemberInfo;
                //System.Reflection.MethodInfo mInfo;
                //mInfo = typeof(Human).GetMethod("Name");

                //System.Reflection.ParameterInfo[] parameters = mInfo.GetParameters();
                //object classInstance = Activator.CreateInstance(Human, null);

                //string name = mInfo.Invoke(Human );
                //string name = r.GetValue();


                    System.Reflection.PropertyInfo pInfo;
                    Type type = typeof(Human);
                    pInfo = type.GetProperty("Name");
                    string name = (string)pInfo.GetValue(human2);

                    string ChildType = child;
                    type = Type.GetType("Lab6."+ChildType); 
                    var obj = Activator.CreateInstance(type);


                    string GirlName = (string)pInfo.GetValue(human1);
                    pInfo = type.GetProperty("Name");
                    pInfo.SetValue(obj, GirlName);

                    SortedSet<string> male = new SortedSet<string>();
                    male.Add("Student");
                    male.Add("Botan");
    
                    string fathersName;
                    if (male.Contains(ChildType))
                    {
                        if (name[name.Length - 1] == 'о') {
                            fathersName = name + "вич";
                        }
                        else { 
                            fathersName = name + "ович";
                        }
                    }
                    else {
                        if (name[name.Length - 1] == 'о')
                        {
                             name = name.Remove(name.Length - 1);
                             fathersName = name + "івна";
                        }
                        else if (name[name.Length - 1] == 'й')
                        {
                             name = name.Remove(name.Length - 1);
                             fathersName = name + "ївна";
                        }
                         else
                         {
                            fathersName = name + "івна";
                         }
                     }

                //---------------Surname--------------------
                     pInfo = type.GetProperty("Surname");
                     string fatherSurname = (string)pInfo.GetValue(human2);
                //----------------------------------------

                    if (!male.Contains(ChildType)) {
                        if (fatherSurname.Contains("ий")) {
                            fatherSurname = fatherSurname.Remove(fatherSurname.Length - 2);
                            fatherSurname = fatherSurname + "а";
                        }
                    }

                    pInfo = type.GetProperty("Surname");
                    pInfo.SetValue(obj, fatherSurname);

                    pInfo = type.GetProperty("FathersName");
                    pInfo.SetValue(obj, fathersName);

                    
                    result.Name = GirlName;
                    result.ClassType = ChildType;
                    result.Like = true;
                    return result;
                    //return GirlName;
                }
                else
                {
                    child = "";
                }

                
                result.Name = "None";
                result.ClassType = "None";
                result.Like = false;
                return result;
            }
            
        }




        static void Main(string[] args)
        {
            //Girl Юлія = new Girl("Юлія", "Топільська", "Степанівна");
            //Student Юрій = new Student("Юрій", "Криничанський", "Вадимович");
            /*SmartGirl Юлія = new SmartGirl("Юлія", "Топільська", "Степанівна");
            Botan Юрій = new Botan("Юрій", "Криничанський", "Вадимович");*/
            //Result res = Couple(Юлія, Юрій);
            //Console.WriteLine(res.ToString());

            DateTime today = DateTime.Now;
            if (today.DayOfWeek == DayOfWeek.Sunday)
            {
                Environment.Exit(0);
            }
            


            System.IO.StreamReader objReader = new System.IO.StreamReader("D:\\STUDY\\Course 4 University\\NET\\Lab6\\Lab6\\Lab6\\men.txt");
            string menLine = "";
            List<string> menList = new List<string>();
            while (menLine != null) {
                menLine = objReader.ReadLine();
                if (menLine != null)
                    menList.Add(menLine);
            }
            objReader.Close();


            objReader = new System.IO.StreamReader("D:\\STUDY\\Course 4 University\\NET\\Lab6\\Lab6\\Lab6\\women.txt");
            string womenLine = "";
            List<string> womenList = new List<string>();
            while (womenLine != null)
            {
                womenLine = objReader.ReadLine();
                if (womenLine != null)
                    womenList.Add(womenLine);
            }
            objReader.Close();


            List<string> WomenClasses = new List<string>();
            WomenClasses.Add("Girl");
            WomenClasses.Add("SmartGirl");
            WomenClasses.Add("PrettyGirl");

            List<string> MenClasses = new List<string>();
            MenClasses.Add("Student");
            MenClasses.Add("Botan");

            foreach (string strMan in menList) {
                foreach (string strWoman in womenList) {
                    string [] strmanMas = strMan.Split(' ');
                    string[] strwomanMas = strWoman.Split(' ');

                    Random mrand = new Random();
                    int m = mrand.Next(0, 2);
                    //int m = 1;
                    //Console.WriteLine("m = "+m);

                    Random wrand = new Random();
                    int w = wrand.Next(0, 3);
                    //int w = 2;
                    //Console.WriteLine("w = " + w);


                    Type type = Type.GetType("Lab6." + MenClasses[m]);
                    var Man = Activator.CreateInstance(type);

                    System.Reflection.PropertyInfo pInfo;
                    type = typeof(Human);
                    pInfo = type.GetProperty("Name");
                    pInfo.SetValue(Man, strmanMas[0]);

                    pInfo = type.GetProperty("Surname");
                    pInfo.SetValue(Man, strmanMas[1]);

                    pInfo = type.GetProperty("FathersName");
                    pInfo.SetValue(Man, strmanMas[2]);


                    type = Type.GetType("Lab6." + WomenClasses[w]);
                    var Woman = Activator.CreateInstance(type);

                    
                    type = typeof(Human);
                    pInfo = type.GetProperty("Name");
                    pInfo.SetValue(Woman, strwomanMas[0]);

                    pInfo = type.GetProperty("Surname");
                    pInfo.SetValue(Woman, strwomanMas[1]);

                    pInfo = type.GetProperty("FathersName");
                    pInfo.SetValue(Woman, strwomanMas[2]);

                    Result res = Couple((Human)Woman, (Human)Man);
                    Console.WriteLine("Woman : " + Woman.ToString());
                    Console.WriteLine("Man : " + Man.ToString());
                    Console.WriteLine(res.ToString()+"\n\n\n");

                    
                    Console.WriteLine("Press Enter to continue or Q (F10) to exit\n");
                    //if ( (Console.ReadKey(true).Key == ConsoleKey.Q) || (Console.ReadKey(true).Key == ConsoleKey.F10) )
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if ((key == ConsoleKey.Q) || (key == ConsoleKey.F10))
                        Environment.Exit(0);
                    else
                        continue;

                    
                }
            }

            Console.ReadLine();
        }
    }
}
