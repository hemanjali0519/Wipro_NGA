// See https://aka.ms/new-console-template for more information
//Step 1: Create an Enum to represent OrderStaus with values Pending, Processing, Shipped, Delivered, Cancelled
//Step 2: Create a stucture to represent Location with properties Latitude and Longitude of type double
//Step 3: Create a interface for payment contract with methods ProcessPayment and RefundPayment, makePayment(double amount)
//creating a class to implement the payment interface
//ex creditcard payment AND debit card payment
//Step 4: Class to represent Order with properties OrderId, OrderStatus (use enum), ShippingLocation (use struct), and implement payment interface.

using System;

namespace OrderSystem
{
    // Step 1: Enum for Order Status
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    // Step 2: Struct for Location
    public struct Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    // Step 3: Interface for Payment Contract
    public interface IPayment
    {
        void ProcessPayment(double amount);
        void RefundPayment(double amount);
        void MakePayment(double amount);
    }

    // Credit Card Payment Implementation
    public class CreditCardPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing credit card payment of ₹{amount}");
        }

        public void RefundPayment(double amount)
        {
            Console.WriteLine($"Refunding ₹{amount} to credit card");
        }

        public void MakePayment(double amount)
        {
            ProcessPayment(amount);
        }
    }

    // Debit Card Payment Implementation
    public class DebitCardPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing debit card payment of ₹{amount}");
        }

        public void RefundPayment(double amount)
        {
            Console.WriteLine($"Refunding ₹{amount} to debit card");
        }

        public void MakePayment(double amount)
        {
            ProcessPayment(amount);
        }
    }

    // Step 4: Order Class implementing Payment Interface
    public class Order : IPayment
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public Location ShippingLocation { get; set; }

        private IPayment _paymentMethod;

        public Order(int orderId, Location location, IPayment paymentMethod)
        {
            OrderId = orderId;
            Status = OrderStatus.Pending;
            ShippingLocation = location;
            _paymentMethod = paymentMethod;
        }

        public void ProcessPayment(double amount)
        {
            _paymentMethod.ProcessPayment(amount);
        }

        public void RefundPayment(double amount)
        {
            _paymentMethod.RefundPayment(amount);
        }

        public void MakePayment(double amount)
        {
            _paymentMethod.MakePayment(amount);
        }
    }

    // Demo
    class Program
    {
        static void Main()
        {
            Location loc = new Location(28.6139, 77.2090);

            IPayment payment = new CreditCardPayment();
            Order order = new Order(101, loc, payment);

            order.MakePayment(1500);
            order.Status = OrderStatus.Processing;

            Console.WriteLine($"Order Status: {order.Status}");
        }
    }
}
