using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace AleksandarAngelovAngelov.Models
{
    public class Patient:Human
    {
        private string healthinsurance;
        private string healthcondition;

        public string Healthcondition
        { 
            get { return healthcondition; } 
            set { this.healthcondition = value; } 
        }

        public string Healthinsurance
        { 
            get { return healthinsurance; } 
            set {
                if (value.ToLower() == "yes" || value.ToLower() == "no")
                {
                    healthinsurance = value;
                }
                else
                {
                    throw new ArgumentException("Only yes or no can be answers!");
                }
            } 
        }

        public Patient(string name,string familyname,string dateofbirth,string healthinsurance,string healthcondition, int numberofarrivals) :base(name,numberofarrivals,familyname,dateofbirth)
        {
            this.Numberofarrivals = numberofarrivals;
            this.Name = name;
            this.Familyname = familyname;
            this.Dateofbirth = dateofbirth;
            this.Healthinsurance = healthinsurance;
            this.Healthcondition = healthcondition;
        }

        public Patient(string name, string familyname):base(name,familyname)
        {
           this.Name=name;
           this.Familyname=familyname;
        }
        public override string ToString()
        {
            return $"{this.Name} {this.Familyname} {this.Dateofbirth} {this.Healthinsurance} {this.Healthcondition} {this.Numberofarrivals}"; 
        }
    }
}
