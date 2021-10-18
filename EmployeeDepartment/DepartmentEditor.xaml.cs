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

namespace EmployeeDepartment
{
    /// <summary>
    /// Interaction logic for DepartmentEditor.xaml
    /// </summary>
    public partial class DepartmentEditor : Window
    {
        public string DeptName { get; set; }

        public DepartmentEditor()
        {
            InitializeComponent();
        }
        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DeptName = deptControl.GetName();
            DialogResult = true;
        }
    }
}
