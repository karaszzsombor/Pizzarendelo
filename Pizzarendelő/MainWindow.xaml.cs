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

        List<string> rendelesek = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

            pizza_list.ItemsSource = pizzak;

        }

        private void PizzaHozzad()
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
                pizza_textbox.Text = "";
                Keyboard.ClearFocus();
            }

        }




        private void add_btn(object sender, RoutedEventArgs e)
        {
            PizzaHozzad();
        }
        private void pizza_textbox_keydown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                PizzaHozzad();
            }
        }




        private void PizzaTorol()
        {
            string kivalasztott = pizza_list.SelectedItem as string;
            pizzak.Remove(kivalasztott);
            pizza_list.ItemsSource = null;
            pizza_list.ItemsSource = pizzak;
        }
        
        
        
        
        private void del_btn(object sender, RoutedEventArgs e)
        {
            PizzaTorol();
        }

        private void pizza_list_keydown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                PizzaTorol();
            }
        }



        private void RendelesHozzad()
        {
            string new_order = pizza_list.SelectedItem as string;
            string new_order_size = order_size_textbox.Text;
            if (rendelesek.Contains(new_order + " - " + new_order_size))
            {
                MessageBox.Show("Ez a rendelés már eleme a listának", "Hibaüzenet", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (new_order == "")
            {
                MessageBox.Show("Valamit írj bele a dobozba.", "Hibaüzenet", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(new_order_size!= "nagy" && new_order_size != "közepes" && new_order_size != "kicsi")
            {
                MessageBox.Show("Nem megfelelő a megadott méret.", "Hibaüzenet", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                rendelesek.Add(new_order + " - " + new_order_size);
                order_list.ItemsSource = null;
                order_list.ItemsSource = rendelesek;
                order_size_textbox.Text = "";
                Keyboard.ClearFocus();
                order_count.Text = "Rendelesek száma: " + Convert.ToString(rendelesek.Count());
            }
        }
        private void order_textbox_keydown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                RendelesHozzad();
            }
        }

        private void add_order_btn(object sender, RoutedEventArgs e)
        {
            RendelesHozzad();
        }

        private void RendelesTorles()
        {
            string kivalasztott = order_list.SelectedItem as string;
            rendelesek.Remove(kivalasztott);
            order_list.ItemsSource = null;
            order_list.ItemsSource = rendelesek;
        }
        private void del_order(object sender, RoutedEventArgs e)
        {
            RendelesTorles();
        }

        private void del_all_order(object sender, RoutedEventArgs e)
        {
            rendelesek.Clear();
            order_list.ItemsSource = null;
            order_list.ItemsSource = rendelesek;
        }

        private void ordero_list_keydown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                RendelesTorles();
            }
        }
    }
}