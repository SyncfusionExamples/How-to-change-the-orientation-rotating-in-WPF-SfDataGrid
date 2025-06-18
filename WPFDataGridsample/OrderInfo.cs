using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFDataGrid
{
  
    public class OrderInfo : INotifyPropertyChanged
    {
        private string orderID;
        private string customerId;
        private string country;
        private string customerName;
        private string shippingCity;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string OrderID
        {
            get => orderID;
            set
            {
                if (orderID != value)
                {
                    orderID = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CustomerID
        {
            get => customerId;
            set
            {
                if (customerId != value)
                {
                    customerId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CustomerName
        {
            get => customerName;
            set
            {
                if (customerName != value)
                {
                    customerName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Country
        {
            get => country;
            set
            {
                if (country != value)
                {
                    country = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ShipCity
        {
            get => shippingCity;
            set
            {
                if (shippingCity != value)
                {
                    shippingCity = value;
                    OnPropertyChanged();
                }
            }
        }

        public OrderInfo(string orderId, string customerName, string country, string customerId, string shipCity)
        {
            this.OrderID = orderId;
            this.CustomerName = customerName;
            this.Country = country;
            this.CustomerID = customerId;
            this.ShipCity = shipCity;
        }
    }

}
