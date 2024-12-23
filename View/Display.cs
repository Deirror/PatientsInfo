using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AleksandarAngelovAngelov.Controller;
using System.Runtime.Remoting.Messaging;
using AleksandarAngelovAngelov.Models;

namespace AleksandarAngelovAngelov.View
{
    public class Display
    {

        public string Name { get; set; }
        public string Familyname { get; set; }
        public string Healthinsurance { get; set; }
        public string Healthcondition { get; set; }




        private ManagePatientsInfoController controller=new ManagePatientsInfoController();
        public Display()
        {
            int exitoption = 0;
            do
            {
                Console.WriteLine("-_-_-_-_-_-_-Menu-_-_-_-_-_-_-");
                Console.WriteLine("All Available Options:");
                Console.WriteLine("1.Show all patients");
                Console.WriteLine("2.Search patient by name");
                Console.WriteLine("3.Search hospitalized patients");
                Console.WriteLine("4.Search for healthinsured people or people without health insurance");
                Console.WriteLine("5.Add new patient");
                Console.WriteLine("6.Exit program");

                Console.Write("Write your choice: ");
                int choice=int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            List<Patient> patients = controller.ShowAllPatients();

                            if (patients.Count==0)
                            {
                                Console.Write("There aren't currently any patients!\nPress anything to continue");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                foreach(var el in patients)
                                {
                                    Console.WriteLine($"{el.Name} {el.Familyname} {el.Numberofarrivals} {el.Dateofbirth}");
                                }
                                                               
                                break;
                            }
                 
                        }
                    case 2:
                        {
                            Console.WriteLine("Write name and family name:");
                            string[]line=Console.ReadLine().Split(' ');
                            Patient patient = controller.SearchByName(line);

                            if(patient != null)
                            {
                                Console.WriteLine(patient.ToString());
                            }
                            else
                            {
                                Console.Write("Not found!\nPress anything to continue");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 3:
                        {
                            List<Patient> patients = controller.SearchByHealthCondition();

                            if(patients.Count==0)
                            {
                                Console.Write("There aren't currently anyone who is hospitalized!\nPress anything to continue");
                                Console.ReadKey();
                            }
                            else
                            {
                                foreach(var el in patients)
                                {
                                    Console.WriteLine(el.ToString());
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Options: ");
                            Console.WriteLine("1.Has health insurance");
                            Console.WriteLine("2.Doesn't have health insurance");
                            Console.Write("Choice: ");
                            int ch = int.Parse(Console.ReadLine());
                            List<Patient> patients = controller.SearchByHealthInsurance(ch);


                            if(patients.Count==0)
                            {
                                Console.Write("Not Found!\nPress anything to continue");
                                Console.ReadKey();
                            }
                            else
                            {
                                foreach (var el in patients)
                                {
                                    Console.WriteLine(el.ToString());
                                }
                            }
                            break;
                        }
                    case 5:
                        {
                            string[] line = Console.ReadLine().Split(' ');
                        
                            try
                            {
                                controller.AddPatient(line);
                                Console.Write("Successfully added!\nPress anything to continue");
                                Console.ReadKey();
                                break;
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.Write("You must write name,familyname,dateofbirth,if they are health insured,if they are hospitalized\nPress anything to continue");
                                Console.ReadKey();
                                break;
                            }

                            catch (FormatException)
                            {
                                Console.Write("Not correct format!\nPress anything to continue");
                                Console.ReadKey();
                                break;
                            }
                            catch(Exception e)
                            {
                                Console.Write(e.Message+"\nPress anything to continue");
                                Console.ReadKey();
                                break;
                            }
                           

                            }
                    case 6:
                        {
                            exitoption = 6;
                            break;
                        }

                }

                Console.WriteLine();

            } while (exitoption != 6);
        }
    }
}
