using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class NonAdministraticeEmployee : Employee
    {
        public NonAdministraticeEmployee(String name, String role,int salary) {

            this.name=name;
            this.role=role;
            this.salary = salary;
        }

        public override int removeEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }
        public override bool isAdministrative()
        {
            return false;
        }

        public override void replaceEmployee(Employee empToBeReplaced, Employee empToReplace)
        {
            throw new NotImplementedException();
        }
        public override void display()
        {
            for (int i = 0; i < this.level; i++)
            {
                Console.Out.Write("    ");
            }
            Console.Out.WriteLine(String.Format("Name: {0}, Role:{1}", this.name,this.role));
        }


        public override int calculateSalarySpan()
        {
            return this.salary;
        }

    }
}
