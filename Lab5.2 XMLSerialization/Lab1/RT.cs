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
    public class RT : Team
    {
        
        public string investigationName;
        
        public TimeFrame duration;

        
        [XmlArray("participants") ,XmlArrayItem(typeof(Person), ElementName = "Person")]
        public List<Person> participants;
        
        [XmlArray("publicationList"), XmlArrayItem(typeof(Paper), ElementName = "Paper")]
        public List<Paper> publicationList;

        public RT(string invName, TimeFrame time) {
            investigationName = invName;
            duration = time;
            participants = new List<Person>();
            publicationList = new List<Paper>();
        }

        public RT() {
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

    }
}
