using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfApplication1
{
    abstract class Employee
    {
        public ObservableCollection<Employee> subbordinates { get; set; }
        public String name { get; set; }
        public String role { get; set; }
        public int level { get; set; }

        public int salary { get; set; }
        public Employee boss { get; set; }
        public int count {
            get {
                int counterSum = 0;
                foreach (Employee e in subbordinates) {
                    counterSum += e.count;

                }
                counterSum += subbordinates.Count;
                return counterSum;
            } }
        public Employee() {
            this.subbordinates = new ObservableCollection<Employee>();
        }
        public abstract void display();
        public abstract bool isAdministrative();
        public abstract int removeEmployee(Employee emp);


        public abstract void replaceEmployee(Employee empToBeReplaced, Employee empToReplace);

        public void addEmployee(Employee emp) {
            emp.level=this.level + 1;
            try
            {
                this.subbordinates.Add(emp);
                emp.boss = this;
            }
            catch(Exception e) {
                Console.Out.Write(e.StackTrace);
            }
        }
        public abstract int calculateSalarySpan();
    }
}
