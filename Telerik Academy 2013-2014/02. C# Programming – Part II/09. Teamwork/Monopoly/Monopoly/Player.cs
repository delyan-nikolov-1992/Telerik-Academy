using System;
using System.Collections.Generic;

class Player
{
    private double cash;
    private ConsoleColor color;
    private byte currentPosition;
    private List<Property> properties = new List<Property>();
    private byte id;

    public Player(double cash, ConsoleColor color, byte currentPosition, byte id)
    {
        this.cash = cash;
        this.color = color;
        this.currentPosition = currentPosition;
        this.id = id;
    }

    public double Cash
    {
        get { return this.cash; }
        set { this.cash = value; }
    }

    public ConsoleColor Color
    {
        get { return this.color; }
        set { this.color = value; }
    }

    public byte CurrentPosition
    {
        get { return this.currentPosition; }
        set { this.currentPosition = value; }
    }
    
    public List<Property> Properties
    {
        get { return this.properties; }
        set { this.properties = value; }
    }

    public byte ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public void AddProperty(Property property)
    {
        this.properties.Add(property);
        cash -= property.Price;
    }

    public void Move(byte newPosition)
    {
        if (currentPosition > newPosition)
        {
            cash += 1;
        }

        currentPosition = newPosition;
    }

    public bool HasMoney(double money)
    {
        if (cash >= money)
        {

            return true;
        }

        return false;
    }
   
    public bool GiveMoney(double moneyToGive, Player player)
    {
        if (HasMoney(moneyToGive))
        {
            cash -= moneyToGive;

            if (!(player == null))
            {
                player.cash += moneyToGive;
            }

            return true;

        }
        else
        {
            double totalAmount = 0;

            foreach (var current in properties)
            {
                totalAmount += current.Price;
            }

            totalAmount *= 0.75;

            if ((totalAmount + cash) < moneyToGive)
            {
                if (!(player == null))
                {
                    player.Cash += totalAmount + cash;
                }

                for (int i = 0; i < properties.Count; i++)
                {
                    properties[i].Owner = null;
                }

                return false;
            }
            else
            {
                properties.Sort((x, y) => x.Price.CompareTo(y.Price));

                while (!HasMoney(moneyToGive))
                {
                    SellProperty(properties[0]);
                }

                cash -= moneyToGive;

                if (!(player == null))
                {
                    player.Cash += moneyToGive;
                }

                return true;
            }
        }
    }

    private void SellProperty(Property property)
    {
        foreach (var item in properties)
        {
            if (item.Equals(property))
            {
                cash += item.Price * 0.75;
                item.Owner = null;
                properties.Remove(item);
                break;
            }
        }
    }
}