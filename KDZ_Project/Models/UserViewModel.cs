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
        private String _login;
        //переписать совйства на CompetitionViewModel
        private String _password;

        private bool _isauthorized;

       public String Login { get { return _login; } set { _login = value; OnPropertyChanged(); } }

        public String Password { get { return _password; } set { _password = value; OnPropertyChanged(); } }

        public bool IsAuthorized { get { return _isauthorized; } set { _isauthorized = value; OnPropertyChanged(); } }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
