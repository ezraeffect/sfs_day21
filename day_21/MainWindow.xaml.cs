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

namespace day_21
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window    
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_ID.Text) || string.IsNullOrWhiteSpace(textBox_PW.Text))
            {
                MessageBox.Show("아이디와 비밀번호를 모두 입력해주세요.", "경고", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show($"로그인 시도 : {textBox_ID.Text} / {textBox_PW.Text}","로그인 정보",MessageBoxButton.OK, MessageBoxImage.Information);
            }
                
        }
    }
}