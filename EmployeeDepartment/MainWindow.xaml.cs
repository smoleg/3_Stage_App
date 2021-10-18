using Employee.Data;
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

namespace EmployeeDepartment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeDatabase employeeDatabase = new EmployeeDatabase();
        private DepartmentDatabase departmentDatabase = new DepartmentDatabase();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            departmentlistView.ItemsSource = departmentDatabase.DepartmentList;            
        }

        private void employeelistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
                employeeControl.Employee = ((Person)e.AddedItems[0]);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (employeelistView.SelectedItems.Count < 1)
                return;
            //employeeControl.UpdateEmployee();
            btnSave.IsEnabled = false;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (employeelistView.SelectedItems.Count < 1)
                return;
            if (MessageBox.Show("Вы действительно желаете удалить запись сотрудника?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                employeeDatabase.EmployeeList.Remove((Person)employeelistView.SelectedItems[0]);

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnSave.IsEnabled = true;
        }

        private void UpdateBinding()
        {
            employeelistView.ItemsSource = null;
            //departmentlistView.ItemsSource = null;
            employeelistView.ItemsSource = employeeDatabase.EmployeeList;
            //departmentlistView.ItemsSource = departmentDatabase.DepartmentList;
            //employeeControl.UpdateDeptsCB();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeEditor employeeEditor = new EmployeeEditor();
            if (employeeEditor.ShowDialog() == true)
            {
                employeeDatabase.EmployeeList.Add(employeeEditor.Employee);
                UpdateBinding();
            }
        }

        private void btnAddDept_Click(object sender, RoutedEventArgs e)
        {
            DepartmentEditor departmentEditor = new DepartmentEditor();
            if (departmentEditor.ShowDialog() == true)
            {
                //departmentlistView.Items.Add(departmentEditor.DeptName);
            }
        }
    }
}
