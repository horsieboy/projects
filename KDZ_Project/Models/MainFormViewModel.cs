using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Project.Models
{

    

    public class MainFormViewModel: INotifyPropertyChanged
    {
        private bool _canApply;

        private string _search;

        private bool _isedit;

        private bool _IsCreator;

        private CompetitionViewModel _competition ;

        private bool _IsCompetitionSelectd;

        public string Search { get { return _search; } set { _search = value; OnPropertyChanged(); } }

        public bool IsCompetitionSelected { get { return _IsCompetitionSelectd; } set { _IsCompetitionSelectd = value;  OnPropertyChanged(); } }

        public bool IsCreator { get { return _IsCreator; } set { _IsCreator = value; OnPropertyChanged(); } }

        public bool CanApply { get { return _canApply;  } set { _canApply = value; OnPropertyChanged(); } }

        public CompetitionViewModel Competition { get { return _competition; } set { _competition = value; OnPropertyChanged(); } }

        public bool IsEdit { get { return _isedit; } set { _isedit = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
