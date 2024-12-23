using AleksandarAngelovAngelov.Models;
using AleksandarAngelovAngelov.View;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AleksandarAngelovAngelov.Controller
{
    public class ManagePatientsInfoController
    {
        Display view;
        List<Patient> patients = new List<Patient>();

        public ManagePatientsInfoController()
        {
            
        }

        public ManagePatientsInfoController(string beggining)
        {
            patients = new List<Patient>();
            GetAllPatients();
            view = new Display();

        }

        public void GetAllPatients()
        {
            using(var reader = new StreamReader("infodoctor.txt"))
            {
                if(patients.Count>0) patients.Clear();

                while (!reader.EndOfStream)
                {
                    string [] line = reader.ReadLine().Split(' ');
                    if (line.Length != 1)
                    {
                        Patient patient = new Patient(line[0], line[1], line[2], line[3], line[4], int.Parse(line[5]));
                        patients.Add(patient);
                    }
                    else
                    {
                        break;
                    }
                }

            }
         
        }

        public List<Patient> ShowAllPatients()
        {
            GetAllPatients();
            return patients;
        }

        public void AddPatient(string[]line)
        {
          
            if (line.Length == 6)
            {
                Patient patient = new Patient(line[0], line[1], line[2], line[3], line[4], int.Parse(line[5]));
                if (this.patients != null)
                {



                    if (!this.patients.Where(x => x.Name == patient.Name && x.Familyname == patient.Familyname).Any())
                    {
                        using (StreamWriter writer = new StreamWriter("infodoctor.txt", true))
                        {
                            writer.WriteLine($"{patient.Name} {patient.Familyname} {patient.Dateofbirth} {patient.Healthinsurance.ToUpper()} {patient.Healthcondition} {patient.Numberofarrivals}");
                        }
                        GetAllPatients();
                    }
                    else
                    {
                        throw new Exception("Already exists!");
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter("infodoctor.txt", true))
                    {
                        writer.WriteLine($"{patient.Name} {patient.Familyname} {patient.Dateofbirth} {patient.Healthinsurance.ToUpper()} {patient.Healthcondition} {patient.Numberofarrivals}");
                    }
                    GetAllPatients();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public Patient SearchByName(string[]line)
        {
         
            Patient patient = new Patient(line[0], line[1]);
            if (this.patients.Where(x => x.Name == patient.Name && x.Familyname == patient.Familyname).Any())
            {
                return this.patients.Where(x => x.Name == patient.Name && x.Familyname == patient.Familyname).FirstOrDefault();
            }
            else return null;
                
        }

        public List<Patient> SearchByHealthCondition()
        {
          
            return this.patients.Where(x => x.Healthcondition != "Nonhosp").ToList();

        }

        public List<Patient> SearchByHealthInsurance(int ch)
        {
         
            if (ch==1)
            {
                return this.patients.Where(x => x.Healthinsurance == "YES").ToList();
            }
            else 
            {
                return this.patients.Where(x => x.Healthinsurance == "NO").ToList();
            }
            

        }
    }
}
