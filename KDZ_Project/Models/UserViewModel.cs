using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Project.Models
{
    
   public  class UserViewModel:INotifyPropertyChanged
    {
        private IEnumerable<CompetitionViewModel2> _competitions = new List<CompetitionViewModel2>();

        private string _name;

        private string _regdate;

        private string _status;

        private String _login;
       
        private String _password;

        private bool _isauthorized;

        public int UserId { get; set; }

       public String Login { get { return _login; } set { _login = value; OnPropertyChanged(); } }

        public String Password { get { return _password; } set { _password = value; OnPropertyChanged(); } }

        public IEnumerable<CompetitionViewModel2> Competitions { get { return _competitions; } set { _competitions = value; OnPropertyChanged(); } }

        public bool IsAuthorized { get { return _isauthorized; } set { _isauthorized = value; OnPropertyChanged(); } }

        public String Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }

        public String RegDate { get { return _regdate; } set { _regdate = value; OnPropertyChanged(); } }

        public String Status { get { return _status; } set { _status = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Reset()
        {
            Login = Password = Name = RegDate = Status = "";

            IsAuthorized = false;

            Competitions = new List<CompetitionViewModel2>();
        }
    }
}
