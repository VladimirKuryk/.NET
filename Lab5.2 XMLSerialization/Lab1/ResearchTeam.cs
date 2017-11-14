using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lab2
{
    [Serializable]
    [XmlRoot("ResearchTeam")]
    public class ResearchTeam : Team, /*INameAndCopy,*/ IComparer<ResearchTeam>
    {
        
        public string investigationName;
        
        public TimeFrame duration;

        
        [XmlArray("participants") ,XmlArrayItem(typeof(Person), ElementName = "Person")]
        public List<Person> participants;
        
        [XmlArray("publicationList"), XmlArrayItem(typeof(Paper), ElementName = "Paper")]
        public List<Paper> publicationList;
        
        public ResearchTeam(string invName, TimeFrame time) {
            investigationName = invName;
            duration = time;
            participants = new List<Person>();
            publicationList = new List<Paper>();
        }
        
        public ResearchTeam() {
            investigationName = "invName";
            duration = TimeFrame.Long;
            participants = new List<Person>();
            publicationList = new List<Paper>();
        }
        [XmlIgnore]
        public string InvestigationName {
            get => investigationName;
            set => investigationName = value;
        }

        [XmlIgnore]
        public TimeFrame InvDuration {
            get => duration;
            set => duration = value;
        }
        [XmlIgnore]
        public List<Paper> PublicationList {
            get => publicationList;
            set => publicationList = value;
        }
        [XmlIgnore]
        public List<Person> Participants
        {
            get => participants;
            set => participants = value;
        }
        [XmlIgnore]
        public Paper LastPublication {
            get {

                //publicationList.OrderByDescending(x => x.publicationDate).FirstOrDefault();

                Paper lastPublication = null;
                if (publicationList != null)
                {
                    lastPublication = publicationList[0];

                    for (int i = 0; i < publicationList.Count; i++)
                    {
                        if (publicationList[i].publicationDate > lastPublication.publicationDate)
                            lastPublication = publicationList[i];
                    }
                }

                return lastPublication;
            }
        }


        
        public void AddPapers(params Paper[] papers) {
            int len;


            len = papers.Length;
            for (int i = 0; i < len; i++)
            {
                publicationList.Add(papers[i]);
            }

        }

        
        public void AddPartisipants(params Person[] people)
        {
            int len;


            len = people.Length;

            for (int i = 0; i < len; i++)
            {
                participants.Add(people[i]);
            }

        }
        
        public override string ToString()
        {

            
            StringBuilder sbParticipants = new StringBuilder();
            if (participants != null) {
               
                for (int i = 0; i < participants.Count; i++)
                {
                    sbParticipants.Append(i + 1 + ": " + participants[i].ToString() + "\n");
                }
            }

            StringBuilder sbPublications = new StringBuilder();
            
            if (publicationList != null) {
               
                for (int i = 0; i < publicationList.Count; i++) {
                    sbPublications.Append(i + 1 + ": " + publicationList[i].ToString() + " \n");                   
                }
            }
            return "InvestigationName: " + investigationName + "; Duration: " + duration.ToString() + "\n Publications: \n" + sbPublications.ToString() + "\n Participants : \n" + sbParticipants.ToString();
         }
        
        public virtual string ToShortString() {
            return "InvestigationName: " + investigationName + "; Duration: " + duration.ToString() + ".";
        }
        
        public override object DeepCopy()
        {
            ResearchTeam copy = (ResearchTeam)this.MemberwiseClone();

            copy.investigationName = String.Copy(investigationName);
            copy.duration = this.duration;

            
            copy.participants = participants.Select(person => new Person(person.Name, person.Surname, person.Birthday)).ToList<Person>();
            copy.publicationList = publicationList.Select(paper => new Paper(paper.publicationName, paper.author, paper.publicationDate)).ToList<Paper>();


            return copy;
        }
        [XmlIgnore]
        public Team SimilarWithBase {
            get {
                Team obj;
                //obj = (Team)base.GetDeepCopy(this);
                obj = (Team)base.DeepCopy();
                
                return obj;
            }

            set {
                base.Name = value.Name;
                OrganizationName = value.OrganizationName;
                RegNumber = value.RegNumber;
            }
        }

        
        public override object GetDeepCopy(object DeepCopy)
        {
            return this.DeepCopy();
        }

        /*public string Name {
            get {
                return investigationName;
            }
            set {
                investigationName = value;
            }
        }*/
        
        public IEnumerable<Person> ParticipantsWoutPublications(){
            
            if (publicationList != null) {
                foreach (Person i in participants) {
                    bool cond = false;
                    foreach (Paper j in publicationList) {
                        if (i.Equals(j.author))
                            cond = true;
                    }
                    if (cond == false)
                        yield return i;
                }
            }
        }
        
        public IEnumerable<Paper> LastNYearsPublications(int n) {
            DateTime current = DateTime.Now;
            int currentYear = current.Year;
            
            foreach (Paper j in publicationList) {
                if (j.publicationDate.Year > currentYear - n) {
                    yield return j;
                }
            }
        }

        // ----------------Additional Tasks-----------------
        
        public IEnumerable<Person> ParticipantsWithPublications()
        {           
            if (publicationList != null)
            {
                foreach (Person i in participants)
                {
                    bool cond = false;
                    foreach (Paper j in publicationList)
                    {
                        if (i.Equals(j.author))
                        {
                            cond = true;
                            break;
                        }                           
                    }
                    if (cond == true)
                        yield return i;
                }
            }
        }

        
        public IEnumerable<Person> PublicationsMoreThanOne()
        {
            if (publicationList != null)
            {
                foreach (Person i in participants)
                {
                    bool cond = false; int count = 0;
                    foreach (Paper j in publicationList)
                    {
                        if (i.Equals(j.author))
                        {
                            cond = true;
                            count++; 
                        }
                    }
                    if (cond == true && count > 1)
                        yield return i;
                }
            }
        }

        
        public IEnumerable<Paper> LastYearPublications()
        {
            DateTime current = DateTime.Now;
            int currentYear = current.Year;

            foreach (Paper j in publicationList)
            {
                if (j.publicationDate.Year > currentYear - 1)
                {
                    yield return j;
                }
            }
        }
        
        int IComparer<ResearchTeam>.Compare(ResearchTeam x, ResearchTeam y)
        {
            return x.InvestigationName.CompareTo(y.InvestigationName);
        }
        
        public T DeepCopy<T>() {
            using (var ms = new MemoryStream()) {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }          
        }
        
        public bool Save(string filename) {
            if (this == null)
                return false;
            try
            {
                /*XmlDocument xmlDocument = new XmlDocument();

                 XmlSerializer serializer = new XmlSerializer(this.GetType());
                 using (MemoryStream stream = new MemoryStream())
                 {
                     serializer.Serialize(stream, this);
                     stream.Position = 0;
                     xmlDocument.Load(stream);
                     xmlDocument.Save(filename);
                     stream.Close();
                 }*/
                /*FileStream s = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
               BinaryFormatter B = new BinaryFormatter();
               B.Serialize(s, this);
               s.Close();*/
                FileStream fs = new FileStream(filename, FileMode.Create);
                XmlSerializer s = new XmlSerializer(typeof(ResearchTeam));
                s.Serialize(fs, this);
                fs.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        public bool Load(string filename) {
            if (string.IsNullOrEmpty(filename)) {
                return false;
            }

            ResearchTeam objOut = default(ResearchTeam);

            try
            {
                /* XmlDocument xmlDocument = new XmlDocument();
                 xmlDocument.Load(filename);

                 string xmlString = xmlDocument.OuterXml;

                 using (StringReader read = new StringReader(xmlString))
                 {
                     Type outType = typeof(ResearchTeam);

                     XmlSerializer serializer = new XmlSerializer(outType);
                     using (XmlReader reader = new XmlTextReader(read))
                     {
                         objOut = (ResearchTeam)serializer.Deserialize(reader);
                         reader.Close();
                         this.OrganizationName = String.Copy(objOut.OrganizationName);
                         this.RegNumber = objOut.RegNumber;
                         this.InvestigationName = String.Copy(objOut.InvestigationName);
                         this.InvDuration = objOut.InvDuration;
                         this.Participants = objOut.Participants.Select(person => new Person(person.Name, person.Surname, person.Birthday)).ToList<Person>();
                         this.PublicationList = objOut.PublicationList.Select(paper => new Paper(paper.publicationName, paper.author, paper.publicationDate)).ToList<Paper>();
                     }
                     read.Close();
                 }*/
                /*FileStream Fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter F = new BinaryFormatter();
                objOut = (ResearchTeam)F.Deserialize(Fs);
                Fs.Close();*/

                /*OrganizationName = objOut.OrganizationName;
                RegNumber = objOut.RegNumber;

                this.InvestigationName =  objOut.InvestigationName;
                this.InvDuration = objOut.InvDuration;
                this.Participants = objOut.Participants;
                this.PublicationList = objOut.PublicationList;*/
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
                XmlSerializer s = new XmlSerializer(typeof(ResearchTeam));

                ResearchTeam rt = (ResearchTeam)s.Deserialize(fs);
                InvestigationName = rt.InvestigationName;
                InvDuration = rt.InvDuration;
                Participants = rt.Participants;
                PublicationList = rt.PublicationList;
                fs.Close();

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool AddFromConsole() {
            
            //publicationList
            Console.WriteLine("String Format For This Type of List: \n publicationName ; name, surname, day.month.year ; day.month.year ;");
            string row = Console.ReadLine();

            try
            {
                string[] rowMas = row.Split(';');

                string[] publicationdateMas = rowMas[2].Split('.');

                string publicationName = rowMas[0];

                //------------------author------------------------------
                string[] authorMas = rowMas[1].Split(',');
                string[] birthday = authorMas[2].Split('.');
                Person author = new Person(authorMas[0], authorMas[1], new DateTime( Int32.Parse(birthday[2]), Int32.Parse(birthday[1]), Int32.Parse(birthday[0]) ));
                //------------------------------------------------------

                DateTime publicationDate = new DateTime(Int32.Parse(publicationdateMas[2]), Int32.Parse(publicationdateMas[1]), Int32.Parse(publicationdateMas[0]));

                Paper paper = new Paper(publicationName, author, publicationDate);

                publicationList.Add(paper);

            }
             catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
            return true;
        }

        public static bool Save<T>(string filename, T obj) {
            if (obj == null)
                return false;

            try
            {
                /*XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, obj);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(filename);
                    stream.Close();
                }*/
                /* FileStream s = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
                 BinaryFormatter B = new BinaryFormatter();
                 B.Serialize(s, obj);
                 s.Close();*/
                FileStream fs = new FileStream(filename, FileMode.Create);
                XmlSerializer s = new XmlSerializer(typeof(T));
                s.Serialize(fs, obj);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        public static T Load<T>(string filename, T obj)
        {
            if (string.IsNullOrEmpty(filename))
                return default(T);

            //T obj = default(T);
            //obj = default(T);
            try
            {
                /*XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filename);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        obj = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }
                    read.Close();
                }*/
                /*FileStream Fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter F = new BinaryFormatter();
                obj = (T)F.Deserialize(Fs);*/

                /*this.InvestigationName = objOut.InvestigationName;
                this.InvDuration = objOut.InvDuration;
                this.Participants = objOut.Participants;
                this.PublicationList = objOut.PublicationList;*/
                /*Fs.Close();*/
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
                XmlSerializer s = new XmlSerializer(typeof(T));

                T rt = (T)s.Deserialize(fs);
                obj = rt;
                /*ResearchTeam rt = (ResearchTeam)s.Deserialize(fs);
                obj.InvestigationName = rt.InvestigationName;
                obj.InvDuration = rt.InvDuration;
                obj.Participants = rt.Participants;
                obj.PublicationList = rt.PublicationList;*/
                fs.Close();
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);             
            }
            return obj;
        }

    }
}
