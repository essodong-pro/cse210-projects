using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetName() => name;
    public string GetProductId() => productId;
}

class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName() => name;
    public Address GetAddress() => address;
}

class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (Product p in products)
        {
            total += p.GetTotalCost();
        }
        total += customer.LivesInUSA() ? 5 : 35; // shipping
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in products)
        {
            label += $"{p.GetName()} (ID: {p.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}

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
