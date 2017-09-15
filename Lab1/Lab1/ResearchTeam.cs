using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class ResearchTeam
    {
        private string investigationName;
        private string organization;
        private int regNumber;
        private TimeFrame duration;
        private Paper[] publicationList;

        public ResearchTeam(string invName, string orgName, int number, TimeFrame time) {
            investigationName = invName;
            organization = orgName;
            regNumber = number;
            duration = time;
        }

        public ResearchTeam() {
            investigationName = "invName";
            organization = "orgName";
            regNumber = 0;
            //duration = new TimeFrame();
            duration = TimeFrame.Long;
            publicationList = new Paper[1];
            publicationList[0] = new Paper();
        }

        public string InvestigationName{
            get => investigationName;
            set => investigationName = value;
        }

        public string OrganizationName {
            get => organization;
            set => organization = value;
        }

        public int RegNumber {
            get => regNumber;
            set => regNumber = value;
        }

        public TimeFrame InvDuration {
            get => duration;
            set => duration = value;
        }

        public Paper[] PublicationList {
            get => publicationList;
            set => publicationList = value;
        }

        public Paper LastPublication {
            get {
            
                Paper lastPublication = null;
                if (publicationList != null)
                {
                    lastPublication = publicationList[0];

                    for (int i = 0; i < publicationList.Length; i++)
                    {
                        if (publicationList[i].publicationDate > lastPublication.publicationDate)
                            lastPublication = publicationList[i];
                    }
                }
                

                return lastPublication;
            }
        }

        //Indexer
        public bool this[TimeFrame time] {
            get {
                if (time.Equals(this.duration))
                    return true;
                else
                    return false;
            }
        }

        public void AddPapers(Paper[] papers) {
            int len;

            
            if (publicationList == null) len = 0;
            else len = publicationList.Length;

            Paper[] saveList = new Paper[len];


            for (int i = 0; i < saveList.Length; i++)
            {
                publicationList[i] = saveList[i];
            }

            publicationList = new Paper[len + papers.Length];

            


            for (int i = len/* - 1*/; i < len + papers.Length; i++) {
                publicationList[i] = papers[i - len]; 
            }
        }

        public override string ToString()
        {
            string list = "";
            if (publicationList != null) { 
                for (int i = 0; i < publicationList.Length; i++) {
                    list = list +(i+1)+": "+ publicationList[i].ToString() + "; \n"; 
                }
            }
            return "InvestigationName: "+investigationName + "; Organization: " + organization + "; RegNumber: " + regNumber + "; Duration: " + duration.ToString() + "\n Publications: \n" + list;
        }

        public virtual string ToShortString() {
            return "InvestigationName: " + investigationName + "; Organization: " + organization + "; RegNumber: " + regNumber + "; Duration: " + duration.ToString() + ".";
        }
    }
}
