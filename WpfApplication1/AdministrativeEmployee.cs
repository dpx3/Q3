using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfApplication1
{
    class AdministrativeEmployee: Employee
    {
        
        public AdministrativeEmployee(String name, String role,int salary) {
            this.subbordinates = new ObservableCollection<Employee>();
            this.role = role;
            this.name = name;
            this.salary = salary;
        }

        public override bool isAdministrative()
        {
            return true;
        }

        public override void display() {
            if (subbordinates.Count > 0)
            {
                for (int i = 0; i < level; i++)
                {
                    Console.Out.Write("    ");
                }
                Console.Out.WriteLine(String.Format("Name: {0}, Role:{1} with subbordinates" ,name, role));
                foreach (Employee e in subbordinates)
                {
                    e.display();
                }
            }
            else {


                Console.Out.WriteLine(String.Format("Name: {0}, Role:{1} ", name, role));
            }
        }


        public override int removeEmployee(Employee emp)
        {
            int index = this.subbordinates.IndexOf(emp);
            this.subbordinates.Remove(emp);
            return index;
        }

        public override void replaceEmployee(Employee empToBeReplaced, Employee empToReplace)
        {
            int index = this.subbordinates.IndexOf(empToBeReplaced);
            this.subbordinates.Remove(empToBeReplaced);
            this.subbordinates.Insert(index, empToReplace);
        }


        public override int calculateSalarySpan()
        {
            {
                int salarySum = 0;
                salarySum += this.salary;
                foreach (Employee e in subbordinates)
                {
                    salarySum += e.calculateSalarySpan();

                }
                return salarySum;
            }
        }

        public ObservableCollection<Employee> getSubbordinates() {

            return this.subbordinates;
        }




    }
}
