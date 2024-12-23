using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AleksandarAngelovAngelov.Models
{
    public class Human
    {
        private string name;
        private int numberofarrivals;
        private string familyname;
        private string dateofbirth;

        public string Name
        {
            set {
                this.name = value;
                }
            get { return name; }
        }

        public int Numberofarrivals
        {
            set { this.numberofarrivals = value; }
            get
            {
                return numberofarrivals;
            }
        }
        public string Familyname
        {
            set
            {
                this.familyname = value;
            }
            get { return familyname; }
        }

        public string Dateofbirth
        {
            set {  this.dateofbirth = value; }
            get { return dateofbirth; }             
        }

        public Human(string name,int numberofarrivals, string familyname, string dateofbirth)
        {
            this.Numberofarrivals = numberofarrivals;
            this.Name = name;
            this.Familyname = familyname;
            this.Dateofbirth = dateofbirth;
        }

        public Human(string name, string familyname)
        {
            this.Name = name;
            this.Familyname = familyname;
        }
    }
}
