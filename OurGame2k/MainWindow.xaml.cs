using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace OurGame2k
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginViewModel _viewModel = new();
        public MainWindow()
        {
            InitializeComponent();

            Binding bNick = new Binding(nameof(User.Nick))
            {
                Source = _viewModel.CurrentUser
            };
            TbNick.SetBinding(TextBox.TextProperty, bNick);

            Binding bName = new Binding(nameof(User.Name))
            {
                Source = _viewModel.CurrentUser
            };
            TbName.SetBinding(TextBox.TextProperty, bName);

            Binding bBirth = new Binding(nameof(User.Birth))
            {
                Source = _viewModel.CurrentUser
            };
            DpBirth.SetBinding(DatePicker.SelectedDateProperty, bBirth);

            BtnLogin.Command = _viewModel.LoginCommand;

            BtnDel.Command = _viewModel.RemoveCommand;
        }
    }
}