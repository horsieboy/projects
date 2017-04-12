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

namespace KDZ_Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompetitionsRepository _competitionRepository;

        private AuthRepository _authRepository;

        public UserViewModel Auth { get; set; } = new UserViewModel();



        public MainWindow()
        {

            

            InitializeComponent();

            _authRepository = new AuthRepository();

            _competitionRepository = new CompetitionsRepository();

            this.Tournament_ListView.ItemsSource = _competitionRepository.GetCompetitions();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Auth == null || String.IsNullOrWhiteSpace(Auth.Login) || String.IsNullOrWhiteSpace(Auth.Password))
            {
                ErrorLabel.Content = "Ввдеите логин и парлоь";
                return;
            }
            if (_authRepository.Authenticate(Auth.Login, Auth.Password))
            {
                Auth.IsAuthorized = true;

            }
            else
            {
                ErrorLabel.Content = "Неверный Логин или Пароль";
                Auth.IsAuthorized = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Auth.IsAuthorized = false;
        }

        private void Tournament_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
