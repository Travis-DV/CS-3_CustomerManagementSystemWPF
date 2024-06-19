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
    public partial class NewCustomer : Window
    {

        public Customer Customer { get; set; }
        private int count;

        public NewCustomer(int count)
        {
            InitializeComponent();
            this.count = count;
            TB_DateInput.Text = DateOnly.FromDateTime(DateTime.Now).ToString();
        }

        private void DATEONLY(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9-:]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Done_CLicked(object sender, RoutedEventArgs e)
        {
            DateOnly date;

            if (!Validator.Validator.CheckString(TB_NameInput.Text))
            {
                MessageBox.Show("Invalid Name", "ERROR");
                return;
            }
            if (!Validator.Validator.CheckEmail(TB_EmailInput.Text))
            {
                MessageBox.Show("Invalid Email", "ERROR");
                return;
            }
            if (!DateOnly.TryParse(TB_DateInput.Text, out date))
            {
                MessageBox.Show("Invalid Date", "ERROR");
                return;
            }

            this.Customer = new Customer()
            {
                CustomerId = count,
                Name = TB_NameInput.Text,
                Email = TB_EmailInput.Text,
                DateOfJoining = date,
            };

            this.Close();
        }
    }
}
