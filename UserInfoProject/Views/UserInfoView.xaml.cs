using System.Windows.Controls;
using FilozopLab03.UserInfoProject.ViewModels;
using System;

namespace FilozopLab03.UserInfoProject.Views
{
    /// <summary>
    /// Interaction logic for UserDataView.xaml
    /// </summary>
    public partial class UserInfoView : UserControl
    {
        private readonly UserInfoViewModel _userInfoViewModel;
        public UserInfoView()
        {
            InitializeComponent();
            _userInfoViewModel = new UserInfoViewModel();
            DataContext = _userInfoViewModel;
        }
    }
}