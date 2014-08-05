using System;

class BitTowerOfDoom
{
    static void Main()
    {
        string[] bitTower = new string[8];
        int[,] representation = new int[8, 8];
        string end = "";
        int current;
        string command;
        int allKnights = 0;
        int survivedKnights = 0;
        int sum = 0;

        for (int i = 0; i < 8; i++)
        {
            current = int.Parse(Console.ReadLine());
            bitTower[i] = Convert.ToString(current, 2).PadLeft(8, '0');

            for (int j = 0; j < 8; j++)
            {
                if (bitTower[i][j] == '1')
                {
                    allKnights++;
                }
            }
        }


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                representation[i, j] = Convert.ToInt32(bitTower[i][j]) - 48;
            }
        }


        command = Console.ReadLine();
        int firstAttacker = 0;
        int secondAttacker = 0;
        int firstDefender = 0;
        int secondDefender = 0;
        int attacker;
        int defender;



        while (command != "end")
        {

            if (command.Equals("select"))
            {

                firstAttacker = int.Parse(Console.ReadLine());
                secondAttacker = int.Parse(Console.ReadLine());

                if (firstAttacker >= 0 && firstAttacker < 8 && secondAttacker >= 0 && secondAttacker < 8)
                {

                    attacker = representation[firstAttacker, secondAttacker];

                }
            }
            else if (command.Equals("kill"))
            {

                firstDefender = int.Parse(Console.ReadLine());
                secondDefender = int.Parse(Console.ReadLine());
                representation[firstAttacker, secondAttacker] = 0;

                if (firstDefender < 0 || firstDefender >= 8 || secondDefender < 0 || secondDefender >= 8)
                {
                    if (firstAttacker == 0 || firstAttacker == 1)
                    {
                        survivedKnights++;

                    }
                }
                else
                {
                    defender = representation[firstDefender, secondDefender];

                    if (defender == 0)
                    {
                        if ((secondDefender - 1 >= 0 && secondDefender + 1 < 8)
                            && representation[firstDefender, secondDefender + 1] == 1
                            && representation[firstDefender, secondDefender - 1] == 1)
                        {
                            representation[firstDefender, secondDefender] = 0;
                        }
                        else if (secondDefender - 1 >= 0 && representation[firstDefender, secondDefender - 1] == 1)
                        {
                            representation[firstDefender, secondDefender] = 0;
                            representation[firstDefender, secondDefender - 1] = 0;
                        }
                        else if (secondDefender + 1 < 8 && representation[firstDefender, secondDefender + 1] == 1)
                        {
                            representation[firstDefender, secondDefender] = 0;
                            representation[firstDefender, secondDefender + 1] = 0;
                        }

                        else
                        {
                            representation[firstDefender, secondDefender] = 1;
                        }
                    }
                }



            }
            else if (command.Equals("move"))
            {


                firstDefender = int.Parse(Console.ReadLine());
                secondDefender = int.Parse(Console.ReadLine());
                representation[firstAttacker, secondAttacker] = 0;

                if (firstDefender < 0 || firstDefender >= 8 || secondDefender < 0 || secondDefender >= 8)
                {
                    if (firstAttacker == 0 || firstAttacker == 1)
                    {
                        survivedKnights++;

                    }

                }
                else
                {


                    defender = representation[firstDefender, secondDefender];

                    if (defender == 0)
                    {
                        if ((secondDefender - 1 >= 0 && secondDefender + 1 < 8)
                            && (representation[firstDefender, secondDefender + 1] == 1
                            || representation[firstDefender, secondDefender - 1] == 1))
                        {
                            representation[firstDefender, secondDefender] = 0;
                        }
                        else
                        {
                            representation[firstDefender, secondDefender] = 1;
                        }
                    }
                }

            }

            command = Console.ReadLine();

        }




        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (representation[i, j] == 0)
                {
                    end += '0';
                }
                else
                {
                    end += '1';
                    survivedKnights++;
                }

            }

            sum += Convert.ToInt32(end, 2);
            end = "";

        }

        Console.WriteLine(allKnights);
        Console.WriteLine(survivedKnights);
        Console.WriteLine(sum);

    }
}