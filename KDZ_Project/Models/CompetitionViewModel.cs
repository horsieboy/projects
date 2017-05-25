using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Project.Models
{
    public class CompetitionViewModel:INotifyPropertyChanged
    {
        private IEnumerable<UserViewModel2> _users;

        private int _contestants;

        private String _name;

        private DateTime _dateStart;

        private int _maxUsersCount;

        private double _prize;

        private DateTime? _isEnded;

        private bool _isCanceled;

        private DateTime? _dateCanceled;

        private bool _isStarted;

        private String _place;
        private string _discipline;

        private int _id;

        public string Status { get
            {
                if (IsStarted)
                    return 1.ToString();
                if (IsCanceled)
                    return 3.ToString();
                return 2.ToString();
            } }


        public IEnumerable<UserViewModel2> Users { get { return _users; } set { _users = value; OnPropertyChanged(); } }


        public int Contestants { get { return _contestants; } set { _contestants = value; OnPropertyChanged(); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public DateTime DateStart { get { return _dateStart; } set { _dateStart = value; OnPropertyChanged(); } }
        public int MaxUsersCount { get { return _maxUsersCount; } set { _maxUsersCount = value; OnPropertyChanged(); } }
        public double Prize { get { return _prize; } set { _prize = value; OnPropertyChanged(); } }
        public DateTime? DateEnded { get { return _isEnded; } set { _isEnded = value; OnPropertyChanged(); } }
        public bool IsCanceled { get { return _isCanceled; } set { _isCanceled = value; OnPropertyChanged(); } }
        public DateTime? DateCanceled { get { return _dateCanceled; } set { _dateCanceled = value; OnPropertyChanged(); } }
        public bool IsStarted { get { return _isStarted; } set { _isStarted = value; OnPropertyChanged(); } }

        public string Place { get { return _place; } set { _place = value; OnPropertyChanged(); } }
        public string Discipline { get { return _discipline; } set { _discipline = value; OnPropertyChanged(); } }

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(); } }
        public string Creator { get; set; }
        public int CreatorId { get; set; }

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
