using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data
{
    public class Person : INotifyPropertyChanged, ICloneable
    {
        private int _ID;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _firstname;
        private string _lastName;
        private string _secondName;
        private int _salary;
        private Department _department = Department.None;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string FirstName
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                NotifyPropertyChanged();
            }
        }

        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                NotifyPropertyChanged();
            }
        }

        public string SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                NotifyPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyPropertyChanged();
            }
        }

        public Department Department
        {
            get { return _department; }
            set
            {
                _department = value;
                NotifyPropertyChanged();
            }
        }

        public int Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
                NotifyPropertyChanged();
            }
        }

        public Person() { }

        public Person(string FN, string SN, string LN, Department dep, int Inc)
        {
            FirstName = FN;
            SecondName = SN;
            LastName = LN;
            Department = dep;
            Salary = Inc;
        }
    }
}
