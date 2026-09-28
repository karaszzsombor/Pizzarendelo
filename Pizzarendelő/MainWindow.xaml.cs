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

namespace Pizzarendelő
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> pizzak = new List<string> {"Margherita", "Sonkás", "Hawaii", "Gombás", "Négy sajtos", "Magyaros"};
        public MainWindow()
        {
            InitializeComponent();

            pizza_list.ItemsSource = pizzak;

        }

        private void add_btn(object sender, RoutedEventArgs e)
        {
            string new_pizza = pizza_textbox.Text;
            if(pizzak.Contains(new_pizza))
            {
                MessageBox.Show("Ez a pizza már eleme a listának", "Hibaüzenet", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (new_pizza == "")
            {
                MessageBox.Show("Valamit írj bele a dobozba.","Hibaüzenet",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                pizzak.Add(new_pizza);
                pizza_list.ItemsSource = null;
                pizza_list.ItemsSource = pizzak;

            }
        }
    }
}