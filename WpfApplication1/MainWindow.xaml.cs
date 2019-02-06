using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> employeeList = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            Employee CEO = new AdministrativeEmployee("Peter", "CEO",55000);
            Employee VP = new AdministrativeEmployee("Dobby", "VP",50000);
            Employee VP2 = new AdministrativeEmployee("George", "VP",50000);
            Employee prog1 = new NonAdministraticeEmployee("Slavo", "Prog",20000);
            Employee prog2 = new NonAdministraticeEmployee("Slavo2", "Prog",20000);
            Employee prog3 = new NonAdministraticeEmployee("Slavo3", "Prog",20000);
            Employee prog4 = new NonAdministraticeEmployee("Slavo4", "Prog",200);
            Employee prog5 = new NonAdministraticeEmployee("Slavo5", "Prog",400);

            employeeList.Add(CEO);
            employeeList.Add(VP);
            employeeList.Add(VP2);
            employeeList.Add(prog1);
            employeeList.Add(prog2);
            employeeList.Add(prog3);
            employeeList.Add(prog4);
            employeeList.Add(prog5);

            VP.addEmployee(prog1);
            VP.addEmployee(prog2);
            VP.addEmployee(prog3);
            VP2.addEmployee(prog4);
            VP2.addEmployee(prog5);

            CEO.addEmployee(VP);
            CEO.addEmployee(VP2);
            Console.Out.Write(CEO);
            trvMenu.Items.Add(CEO);
            this.DataContext = CEO;
        }

        private void setEmployee(object sender, MouseButtonEventArgs e)
        {
            var item = sender as TreeViewItem;
            if (item != null && item.IsSelected)
            {
                this.DataContext = item.DataContext;
            }
        }

        private void removeUser(object sender, RoutedEventArgs e)
        {

            Employee employee = (Employee)this.DataContext;
            this.DataContext = employee.boss;
            
            employee.boss.removeEmployee(employee);
            MessageBox.Show(String.Format("The Employee {0} has been Removed",employee.name));
            Console.Out.WriteLine("The Supperior has " + employee.boss.count);
            trvMenu.Items.Refresh();
            return;

        }
        private void calculateSalary(object sender, RoutedEventArgs e) {

            Employee employee = (Employee)this.DataContext;
            MessageBox.Show("The cost of the control span is " + employee.calculateSalarySpan());
        }

        private void addEmployee(object sender, RoutedEventArgs e){
            Window1 dlg = new Window1();
            dlg.Owner = this;
            dlg.ShowDialog();
            trvMenu.Items.Refresh();
        }





       }
}
