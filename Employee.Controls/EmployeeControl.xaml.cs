using EmpDep.Communication.EmpDepService;
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
        public ObservableCollection<Department> depList { get; set; } = new ObservableCollection<Department>();

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

        public EmployeeControl()
        {
            InitializeComponent();
            DataContext = this;
            FilldepList();
        }

        private void FilldepList()
        {
            depList.Add(Department.HR);
            depList.Add(Department.IT);
            depList.Add(Department.RnD);
            depList.Add(Department.None);
            depList.Add(Department.Sales);
            depList.Add(Department.Transport);
            depList.Add(Department.Production);
            depList.Add(Department.Storage);
            depList.Add(Department.Managment);
            depList.Add(Department.Security);
        }
    }
}
