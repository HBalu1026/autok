using Microsoft.Win32;
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

namespace autokWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Auto> autok = new List<Auto>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BetoltButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                autok = Auto.BeolvasFajlbol(openFileDialog.FileName);
                DataGrid.ItemsSource = autok;
            }
        }

        private void KeresButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxMárkák.Items.Clear();
            if (int.TryParse(TextBoxGyártásiÉv.Text, out int keresettÉv))
            {
                var szűrtAutók = autok.Where(a => a.GyártásiÉv == keresettÉv);
                foreach (var auto in szűrtAutók)
                {
                    ListBoxMárkák.Items.Add($"{auto.Márka} {auto.Modell}");
                }
            }
            else
            {
                MessageBox.Show("Érvényes gyártási évet adjon meg!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void KilepesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan ki szeretne lépni?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}