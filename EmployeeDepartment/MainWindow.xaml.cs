using Employee.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Person> EmpList { get; set; }
        public ObservableCollection<Department> DepList { get; set; }
        public Person SelectedEmp { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            EmpList = employeeDatabase.EmployeeList;
            DepList = departmentDatabase.DepartmentList;
        }

        private void employeelistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
                employeeControl.Employee = (Person)SelectedEmp.Clone();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (employeeListView.SelectedItems.Count < 1)
                return;

            if (employeeDatabase.Update(employeeControl.Employee) > 0)
            {
                EmpList[EmpList.IndexOf(SelectedEmp)] = employeeControl.Employee;
                MessageBox.Show("Запись успешно обновлена", "Обновление записи", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedEmp == null)
                return;
            if (MessageBox.Show("Вы действительно желаете удалить запись сотрудника?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (employeeDatabase.Remove(SelectedEmp) > 0)
                {
                    employeeDatabase.EmployeeList.Remove(SelectedEmp);
                    MessageBox.Show("Запись успешно удалена", "Удаление записи", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeEditor employeeEditor = new EmployeeEditor();
            if (employeeEditor.ShowDialog() == true)
            {
                if (employeeDatabase.AddToDatabase(employeeEditor.Employee) > 0)
                {                    
                    MessageBox.Show("Запись успешно добавлена", "Добавление записи", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
