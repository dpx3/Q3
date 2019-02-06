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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void addEmployee(object sender, RoutedEventArgs e)
        {
            Employee supperior = (Employee)this.Owner.DataContext;
            try
            {
                int.Parse(this.salary.Text);
            }
            catch {
                MessageBox.Show("Please Enter numeric salary value");
                return;
            }
            if (supperior.isAdministrative())
            {

                Employee newEmployee = new NonAdministraticeEmployee(this.name.Text, this.role.Text, int.Parse(this.salary.Text));
          
                supperior.addEmployee(newEmployee);

                Console.WriteLine("Employee has " + supperior.count);
            }
            else {

                Employee newSupperior = new NonAdministraticeEmployee(supperior.name, supperior.role, supperior.salary);
                newSupperior.boss = supperior.boss;
                supperior.boss.replaceEmployee(supperior,newSupperior);
                Employee newEmployee = new NonAdministraticeEmployee(this.name.Text, this.role.Text, int.Parse(this.salary.Text));
                newSupperior.addEmployee(newEmployee);

                Console.WriteLine("Employee has " + newSupperior.count);
            }

            this.Close();
        }
    }
}
