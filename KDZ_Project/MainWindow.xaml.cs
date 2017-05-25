using KDZ_Project.Context;
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
using System.Data.Entity;
using KDZ_Project.Models;
using KDZ_Project.Repositiories;
using System.Windows.Threading;
using KDZ_Project.Entities;

namespace KDZ_Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainFormViewModel Main { get; set; } = new MainFormViewModel();

        private CompetitionsRepository _competitionRepository;

        private AuthRepository _authRepository;

        public UserViewModel Auth { get; set; } = new UserViewModel();

        
        public MainWindow()
        {
            InitializeComponent();

            _authRepository = new AuthRepository();

            _competitionRepository = new CompetitionsRepository();

            this.Tournament_ListView.ItemsSource = _competitionRepository.GetCompetitions();
            this.Disciplines.ItemsSource = _competitionRepository.GetDisciplines();
            this.Places.ItemsSource = _competitionRepository.GetPlaces();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "";

            int UserId = 0;

            if (Auth == null || String.IsNullOrWhiteSpace(Auth.Login) || String.IsNullOrWhiteSpace(Auth.Password))
            {
                ErrorLabel.Content = "Ввдеите логин и парлоь";
                return;
            }
            if (_authRepository.Authenticate(Auth.Login, Auth.Password, out UserId))
            {
                Auth.IsAuthorized = true;

                Auth.UserId = UserId;

                var User = _authRepository.GetUser(UserId);

                Auth.Name = User.UserInfo.FullName;

                Auth.RegDate = User.RegDate.ToString("dd.MM.yyyy HH:mm:ss");

                password.Clear();

                if (Main.IsCompetitionSelected && Main.Competition.CreatorId == Auth.UserId)

                    Main.IsCreator = true;

                Auth.Competitions = _competitionRepository.GetUserCompetitions(Auth.UserId);
            }
            else
            {
                ErrorLabel.Content = "Неверный Логин или Пароль";

                Auth.IsAuthorized = false;
            }

           

        }

        private void Register(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "";

            if (Auth == null || String.IsNullOrWhiteSpace(Auth.Login) || String.IsNullOrWhiteSpace(Auth.Password))
            {
                ErrorLabel.Content = "Ввдеите логин и парлоь";

                return;
            }
            if (!_authRepository.Check(Auth.Login))
            {
                ErrorLabel.Content = "Такой пользователь уже существует";

                return;
            }

            Auth.IsAuthorized = true;

           var user =  _authRepository.Create(Auth.Login, Auth.Password);

            Auth.UserId = user.Id;

            password.Clear();

            Auth.Competitions = _competitionRepository.GetUserCompetitions( Auth.UserId);

            if (Main.IsCompetitionSelected && Main.Competition.CreatorId == Auth.UserId)

                Main.IsCreator = true;
        }

        private void Tournament_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tournament_ListView.SelectedIndex == -1 || Tournament_ListView.SelectedItem == null)
                return;

            var item = Tournament_ListView.SelectedItem as CompetitionViewModel;

            Main.Competition = item;

            if (Auth.IsAuthorized && item.CreatorId == Auth.UserId)

            Main.IsCreator = true;
            
            Main.IsCompetitionSelected = true;

            Cancel_Button.IsEnabled = true;

            Contestants.DataContext = _competitionRepository.GetCompetitionUsers(Main.Competition.Id);
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Main.IsEdit = false;

            Auth.Reset();

            Main.IsCreator = false;

            
        }

        private void SaveCompetition(object sender, RoutedEventArgs e)
        {
            dynamic discId = ((dynamic)this.Disciplines.SelectedItem).Id;
            dynamic placeId = ((dynamic)this.Disciplines.SelectedItem).Id;

            _competitionRepository.Update(Main.Competition, discId, placeId);

            Cancel(sender, e);

            Tournament_ListView.ItemsSource = _competitionRepository.GetCompetitions();

            Tournament_ListView.UpdateLayout();
        }

        private void RemoveCompetition(object sender, RoutedEventArgs e)
        {

            _competitionRepository.Remove(Main.Competition.Id);

            Tournament_ListView.ItemsSource = _competitionRepository.GetCompetitions();

            Tournament_ListView.UpdateLayout();

            Main.IsCompetitionSelected = false;

            Main.Competition = null;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Main.IsCompetitionSelected = false;

            Main.Competition = null;

            

            Tournament_ListView.SelectedIndex = -1;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Main.IsEdit = !Main.IsEdit;
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Auth.Password = password.Password;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.Tournament_ListView.ItemsSource = _competitionRepository.GetCompetitions(search.Text);
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            if (!Auth.IsAuthorized)
                return;

            if (_competitionRepository.CanApply(Main.Competition.Id, Auth.UserId))
            {
                Main.CanApply = _competitionRepository.Apply(Main.Competition.Id, Auth.UserId);
            }
            else
            {
                Main.CanApply = _competitionRepository.Dismiss(Main.Competition.Id, Auth.UserId);
            }

            Main.Competition.Users = _competitionRepository.GetCompetitionUsers(Main.Competition.Id);

            Auth.Competitions = _competitionRepository.GetUserCompetitions(Auth.UserId);
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            Main.Competition = new CompetitionViewModel { CreatorId = Auth.UserId };
            Main.IsEdit = true;
            Main.IsCompetitionSelected = true;
            Main.IsCreator = true;
        }

    }
}
