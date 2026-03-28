using System;

public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    // Read-only properties
    public string Name => _name;
    public string ProductId => _productId;

    public void DisplayProductInfo()
    {
        Console.WriteLine($"Product: {_name} (ID: {_productId})");
        Console.WriteLine($"Price: {_price}, Quantity: {_quantity}");
        Console.WriteLine($"Total Cost: {GetTotalCost()}");
        Console.WriteLine();
    }
}
