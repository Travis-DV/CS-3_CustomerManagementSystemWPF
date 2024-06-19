using System.Collections.ObjectModel;
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

namespace CustomerManagementSystemWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<Customer> _customerList;
        private ObservableCollection<Order> _OrderList;

        public MainWindow()
        {
            InitializeComponent();
            this.Show();
            _customerList = new ObservableCollection<Customer>();
            _OrderList = new ObservableCollection<Order>();

            _customerList.Add(new Customer()
            {
                CustomerId = 1,
                Name = "test1",
                Email = "test1@test.com",
                DateOfJoining = DateOnly.FromDateTime(DateTime.Now),
            });
            _customerList.Add(new Customer()
            {
                CustomerId = 2,
                Name = "Test2",
                Email = "test2@test.com",
                DateOfJoining = DateOnly.FromDateTime(DateTime.Now),
            });

            _OrderList.Add(new Order()
            {
                OrderId = 1,
                CustomerId = 1,
                Amount = 1.5,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
            });
            _OrderList.Add(new Order()
            {
                OrderId = 2,
                CustomerId = 2,
                Amount = 15,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
            });
            _OrderList.Add(new Order()
            {
                OrderId = 3,
                CustomerId = 1,
                Amount = 5,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
            });

            this.Update();

        }

        private void Update()
        {
            LV_Customers.ItemsSource = _customerList;


            var customerSales = _OrderList.GroupBy(order => order.CustomerId)
                .Select(group => new
                {
                    CustomerId = group.Key,
                    TotalMoney = group.Sum(order => order.Amount),
                    TotalSales = group.Count()
                });
            List<string> TotalString = new List<string>();
            foreach (var c in customerSales)
            {
                TotalString.Add($"Customer Id: {c.CustomerId}, Total Sales: {c.TotalSales}, Total Dollars: {c.TotalMoney}");
            };
            LV_Total.ItemsSource = TotalString;
        }

        private string ListAll<T>(String Message, IList<T> List)
        {
            var query = from item in List
                        select item;
            string s = $"{Message}\n";
            foreach (var item in query)
            {
                s += $"{item.ToString()}\n";
            }
            return s;
        }

        private void PrintAll_CLicked(object sender, RoutedEventArgs e)
        {
            LV_Orders.ItemsSource = _OrderList;
        }

        private void PrintByCustomerId_Clicked(object sender, RoutedEventArgs e)
        {
            int customerId = Validator.Validator.GetInt($"CustomerId", Max: this._customerList.Count - 1);
            var query = _OrderList.Where(order => order.CustomerId == customerId);
            LV_Orders.ItemsSource = query.ToList();
        }

        private void AddCustomer_Clicked(object sender, RoutedEventArgs e)
        {
            NewCustomer c = new NewCustomer(_customerList.Count);
            c.ShowDialog();
            _customerList.Add(c.Customer);
        }

        private void AddOrder_Clicked(object sender, RoutedEventArgs e)
        {
            NewOrder o = new NewOrder(_OrderList.Count, _customerList.Count-1);
            o.ShowDialog();
            _OrderList.Add(o.Order);
        }
    }
}