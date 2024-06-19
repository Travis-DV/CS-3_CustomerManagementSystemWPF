using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Validator;

namespace CustomerManagementSystemWPF
{
    /// <summary>
    /// Interaction logic for NewCustomer.xaml
    /// </summary>
    public partial class NewOrder : Window
    {

        public Order Order { get; set; }
        private int count;
        private int max;

        public NewOrder(int count, int max)
        {
            InitializeComponent();
            this.count = count;
            this.max = max;
            TB_DateInput.Text = DateOnly.FromDateTime(DateTime.Now).ToString();
            LB_CustomerIdInput.Content += $" ({max}): ";
        }

        private void NUMBERSONLY(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DOUBLEONLY(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DATEONLY(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9-:]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void Done_CLicked(object sender, RoutedEventArgs e)
        {
            DateOnly date;

            Tuple<bool, int> CustomerId = Validator.Validator.CheckInt(TB_CustomerIdInput.Text, Max: max);
            Tuple<bool, double> Amount = Validator.Validator.CheckDouble(TB_AmountInput.Text);

            if (!CustomerId.Item1)
            {
                MessageBox.Show("Invalid Customer Id", "ERROR");
                return;
            }
            if (!Amount.Item1)
            {
                MessageBox.Show("Invalid Price", "ERROR");
                return;
            }
            if (!DateOnly.TryParse(TB_DateInput.Text, out date))
            {
                MessageBox.Show("Invalid Date", "ERROR");
                return;
            }

            this.Order = new Order()
            {
                OrderId = count,
                CustomerId = CustomerId.Item2,
                Amount = Amount.Item2,
                OrderDate = date,
            };

            this.Close();
        }
    }
}
