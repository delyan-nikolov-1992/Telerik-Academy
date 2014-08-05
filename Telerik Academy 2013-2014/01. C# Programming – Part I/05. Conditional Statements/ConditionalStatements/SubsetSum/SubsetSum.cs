using System;

class SubsetSum
{
    static void Main()
    {
        try
        {
            int[] numbers = new int[5];
            int sum = 0;

            Console.Write("Enter the first number: ");
            numbers[0] = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            numbers[1] = int.Parse(Console.ReadLine());
            Console.Write("Enter the third number: ");
            numbers[2] = int.Parse(Console.ReadLine());
            Console.Write("Enter the fourth number: ");
            numbers[3] = int.Parse(Console.ReadLine());
            Console.Write("Enter the fifth number: ");
            numbers[4] = int.Parse(Console.ReadLine());

            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    sum = numbers[i] + numbers[j];

                    if (sum == 0)
                    {
                        Console.Write(numbers[i]);

                        if (numbers[j] >= 0)
                        {
                            Console.Write("+" + numbers[j] + "=0\n");
                        }
                        else
                        {
                            Console.Write(numbers[j] + "=0\n");
                        }
                    }
                    for (int k = j + 1; k < 5; k++)
                    {
                        sum += numbers[k];

                        if (sum == 0)
                        {
                            Console.Write(numbers[i]);

                            if (numbers[j] >= 0)
                            {
                                Console.Write("+" + numbers[j]);
                            }
                            else
                            {
                                Console.Write(numbers[j]);
                            }

                            if (numbers[k] >= 0)
                            {
                                Console.Write("+" + numbers[k] + "=0\n");
                            }
                            else
                            {
                                Console.Write(numbers[k] + "=0\n");
                            }
                        }
                        for (int l = k + 1; l < 5; l++)
                        {
                            sum += numbers[l];

                            if (sum == 0)
                            {
                                Console.Write(numbers[i]);

                                if (numbers[j] >= 0)
                                {
                                    Console.Write("+" + numbers[j]);
                                }
                                else
                                {
                                    Console.Write(numbers[j]);
                                }

                                if (numbers[k] >= 0)
                                {
                                    Console.Write("+" + numbers[k]);
                                }
                                else
                                {
                                    Console.Write(numbers[k]);
                                }

                                if (numbers[l] >= 0)
                                {
                                    Console.Write("+" + numbers[l] + "=0\n");
                                }
                                else
                                {
                                    Console.Write(numbers[l] + "=0\n");
                                }
                            }
                            for (int m = l + 1; m < 5; m++)
                            {
                                sum += numbers[m];

                                if (sum == 0)
                                {
                                    Console.Write(numbers[i]);

                                    if (numbers[j] >= 0)
                                    {
                                        Console.Write("+" + numbers[j]);
                                    }
                                    else
                                    {
                                        Console.Write(numbers[j]);
                                    }

                                    if (numbers[k] >= 0)
                                    {
                                        Console.Write("+" + numbers[k]);
                                    }
                                    else
                                    {
                                        Console.Write(numbers[k]);
                                    }

                                    if (numbers[l] >= 0)
                                    {
                                        Console.Write("+" + numbers[l]);
                                    }
                                    else
                                    {
                                        Console.Write(numbers[l]);
                                    }

                                    if (numbers[m] >= 0)
                                    {
                                        Console.Write("+" + numbers[m] + "=0\n");
                                    }
                                    else
                                    {
                                        Console.Write(numbers[m] + "=0\n");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}