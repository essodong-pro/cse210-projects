using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // First order
        Address addr1 = new Address("123 Main St", "Accra", "Greater Accra", "Ghana");
        Customer cust1 = new Customer("Nia", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Shirt", "P001", 20, 2));
        order1.AddProduct(new Product("Skirt", "P002", 35, 1));

        // Second order
        Address addr2 = new Address("456 Elm St", "New York", "NY", "USA");
        Customer cust2 = new Customer("Kwame", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Shoes", "P003", 50, 1));
        order2.AddProduct(new Product("Hat", "P004", 15, 3));

        // Display results
        List<Order> orders = new List<Order> { order1, order2 };
        foreach (Order o in orders)
        {
            Console.WriteLine(o.GetPackingLabel());
            Console.WriteLine(o.GetShippingLabel());
            Console.WriteLine($"Total Price: ${o.GetTotalPrice()}\n");
        }
    }
}
