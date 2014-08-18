public class Chef
{
    // first task
    public void Cook()
    {
        Potato potato = this.GetPotato();
        Carrot carrot = this.GetCarrot();
        Bowl bowl = this.GetBowl();

        this.Cut(potato);
        this.Cut(carrot);

        this.Peel(potato);
        this.Peel(carrot);

        bowl.Add(carrot);
        bowl.Add(potato);
    }

    private Bowl GetBowl()
    {
        // TODO 
    }

    private Carrot GetCarrot()
    {
        // TODO
    }

    private Potato GetPotato()
    {
        // TODO
    }

    private void Peel(Vegetable vegetable)
    {
        // TODO
    }

    private void Cut(Vegetable vegetable)
    {
        // TODO
    }

    // second task - first if statement
    private void CookPotato()
    {
        Potato potato;

        // TODO
        if (potato != null)
        {
            if (!potato.HasNotBeenPeeled && !potato.IsRotten)
            {
                this.Cook(potato);
            }
        }
    }
}