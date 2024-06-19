using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Validator;

namespace CustomerManagementSystemWPF
{
    public record Customer
    {

        public int CustomerId 
        { 
            get => _CustomerId;
            set
            {
                if (value > 0 && value < 10000)
                {
                    _CustomerId = value;
                }
                else
                {
                    MessageBox.Show("ERROR, Invalid CustomerId set in Customer", "ERROR");
                }
            } 
        }
        private int _CustomerId;

        public string Name 
        { 
            get => _Name; 
            set 
            {
                if (Validator.Validator.CheckString(value))
                {
                    _Name = value;
                }
                else
                {
                    MessageBox.Show("ERROR, Invalid Name set in Customer", "ERROR");
                }
            } 
        }
        private string _Name;

        public string Email 
        { 
            get => _Email; 
            set 
            {
                if (Validator.Validator.CheckEmail(value))
                {
                    _Email = value;
                }
                else
                {
                    MessageBox.Show("ERROR, Invalid Email set in Customer", "ERROR");
                }
            } 
        }
        private string _Email;

        public DateOnly DateOfJoining { get; set; }

        public override string ToString()
        {
            return $"Customer ID: {CustomerId}, Name: {Name}, Email: {Email}, Joined: {DateOfJoining.ToString("yyyy-MM-dd")}";
        }

    }

    public record Order
    {

        public int OrderId
        {
            get => _OrderId;
            set
            {
                if (value > 0 && value < 10000)
                {
                    _OrderId = value;
                }
                else
                {
                    MessageBox.Show("ERROR, Invalid OrderId set in Order", "ERROR");
                }
            }
        }
        private int _OrderId;

        public int CustomerId
        {
            get => _CustomerId;
            set
            {
                if (value > 0 && value < 10000)
                {
                    _CustomerId = value;
                }
                else
                {
                    MessageBox.Show("ERROR, Invalid CustomerId set in Order", "ERROR");
                }
            }
        }
        private int _CustomerId;

        public double Amount
        {
            get => _Amount;
            set
            {
                if (value > 0)
                {
                    _Amount = value;
                }
                else
                {
                    MessageBox.Show("ERROR, Invalid Amount set in Order", "ERROR");
                }
            }
        }
        private double _Amount;

        public DateOnly OrderDate { get; set; }

        public override string ToString()
        {
            return $"Order ID: {OrderId}, Customer ID: {CustomerId}, Amount: ${Amount}, Order Date: {OrderDate.ToString("yyyy-MM-dd")}";
        }

    }
}
