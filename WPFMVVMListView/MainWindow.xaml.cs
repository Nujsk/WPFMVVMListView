using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFMVVMListView.Models;
using WPFMVVMListView.VM;

namespace WPFMVVMListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HobbyViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new HobbyViewModel();
            DataContext = viewModel;
            Loaded += viewModel.HobbiesView_Loaded;
        }
    }
}