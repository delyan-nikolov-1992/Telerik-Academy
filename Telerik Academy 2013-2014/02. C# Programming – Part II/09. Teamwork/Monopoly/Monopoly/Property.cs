using System;

class Property
{
    private byte boardPosition;
    private string name;
    private double price;
    private Player owner;
    private ConsoleColor color;
    private double rent;

    public Property(byte boardPosition, string name, int price, Player owner, ConsoleColor color, int rent)
    {
        this.boardPosition = boardPosition;
        this.name = name;
        this.price = price;
        this.color = color;
        this.owner = owner;
        this.rent = rent;
    }

    public byte BoardPosition
    {
        get { return this.boardPosition; }
        set { this.boardPosition = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public double Price
    {
        get { return this.price; }
        set { this.price = value; }
    }

    public ConsoleColor Color
    {
        get { return this.color; }
        set { this.color = value; }
    }

    public Player Owner
    {
        get { return this.owner; }
        set { this.owner = value; }
    }

    public double Rent
    {
        get { return this.rent; }
        set { this.rent = value; }
    }


}