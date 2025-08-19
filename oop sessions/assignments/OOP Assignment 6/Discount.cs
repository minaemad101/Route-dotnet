using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_6
{
    abstract class Discount
    {
        public string Name { get; set; }
        public abstract decimal CalculateDiscount(decimal price, int quantity);
    }

    class PercentageDiscount : Discount
    {
        private decimal _percentage;
        public PercentageDiscount(decimal percentage)
        {
            _percentage = percentage;
            Name = $"percentage: {_percentage}%";
        }

        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            return price * quantity * _percentage / 100;
        }

    }
    class FlatDiscount : Discount
    {
        private decimal _flatAmount;

        public FlatDiscount(decimal flatAmount)
        {
            _flatAmount = flatAmount;
            Name = $"Flat Discount (${flatAmount})";
        }

        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            // applies once per purchase, regardless of quantity
            return _flatAmount * Math.Min(quantity, 1);
        }
    }
    class BuyOneGetOneDiscount : Discount
    {
        public BuyOneGetOneDiscount()
        {
            Name = "Buy One Get One";
        }

        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            return (price) * (quantity / 2);
        }
    }

    abstract class User
    {
        private string _name;
        public string Name { get; set; }
        public User(string name) { _name =  name; }
        public abstract Discount GetDiscount();
    }
    class RegularUser : User
    {
        public RegularUser(string name) : base(name) { }
        public override Discount GetDiscount()
        {
            return new PercentageDiscount(5);
        }
    }
    class PremiumUser : User
    {
        public PremiumUser(string name) : base(name) { }
        public override Discount GetDiscount()
        {
            return new FlatDiscount(100);
        }
    }
    class GuestUser: User
    {
        public GuestUser(string name) : base(name) { }
        public override Discount GetDiscount()
        {
            return new FlatDiscount(0);
        }
    }
}