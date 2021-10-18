using Employee.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Employee.Controls
{
    /// <summary>
    /// Interaction logic for EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl, INotifyPropertyChanged

    {

        private Person _employee;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Person Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Department> depList = new ObservableCollection<Department>();

        public EmployeeControl()
        {
            InitializeComponent();
            depList.Add(Department.HR);
            depList.Add(Department.IT);
            depList.Add(Department.RnD);
            depList.Add(Department.None);
            depList.Add(Department.Sales);
            depList.Add(Department.Transport);
            //UpdateDeptsCB();
        }

        //public void SetEmployee(Person person)
        //{
        //    this.employee = person;

        //    tbFN.Text = employee.FirstName;
        //    tbLN.Text = employee.LastName;
        //    tbSN.Text = employee.SecondName;
        //    tbSal.Text = employee.Salary.ToString();
        //    cbDept.SelectedItem = employee.Department;
        //}

        //public void UpdateEmployee()
        //{
        //    employee.FirstName = tbFN.Text;
        //    employee.LastName = tbLN.Text;
        //    employee.SecondName = tbSN.Text;
        //    employee.Salary = Convert.ToInt32(tbSal.Text);
        //    employee.Department = (Department)cbDept.SelectedItem;
        //}

        //public void SetToDefault()
        //{
        //    tbFN.Text = string.Empty;
        //    tbLN.Text = string.Empty;
        //    tbSN.Text = string.Empty;
        //    tbSal.Text = string.Empty;
        //    cbDept.SelectedItem = null;
        //}

        //public void UpdateDeptsCB()
        //{
        //    cbDept.ItemsSource = Enum.GetValues(typeof(Department)).Cast<Department>();
        //}
    }
}
