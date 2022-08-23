using System.IO;
using System.Text.RegularExpressions;

namespace HomeWork09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Phone Book.csv";

            string[] content = File.ReadAllLines(filePath);

            Console.WriteLine($"Enter search parameter:name,surname,number");

            string search = Console.ReadLine();

            try
            {
                if (!(search == "name" || search == "surname" || search == "number"))
                {
                    throw new Exception("Incorrect input");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }





            if (search == "name" || search == "surname" || search == "number")
            {
                Console.WriteLine($"Enter {search}");

                string input = Console.ReadLine();

                string regexName = input + @"(;[\w]+;)+([0-9]+)";
                string regexSurname = @"(\w+;)(" + input + ";)([0-9]+)";
                string regexNumber = @"([\w]+;)" + input;
                string regexOnlyDigital = @"\d";
                string regexNonDigital = @"[a-zA-Z]+";
               



                if (search == "name")
                {
                    try
                    {
                        if (Regex.IsMatch(input, regexOnlyDigital))

                        {
                            throw new Exception("The name contains numbers");
                        }
                        else
                        {
                            Print(regexName, content);
                        }
                    }
                    catch (Exception nameDig)
                    {

                        Console.WriteLine($"Exception: {nameDig.Message}");
                    }
                    
                }





                if (search == "surname")
                {
                    try
                    {
                        if (Regex.IsMatch(input, regexOnlyDigital))

                        {
                            throw new Exception("The surname contains numbers");
                        }
                        else
                        {
                            Print(regexSurname, content);
                        }
                    }
                    catch (Exception surnameDig)
                    {

                        Console.WriteLine($"Exception: {surnameDig.Message}");
                    }




                }

















                if (search == "number")
                {

                    try
                    {
                        if (Regex.IsMatch(input, regexNonDigital))

                        {
                            throw new Exception("The number contains letters");
                        }
                        else
                        {
                            Print(regexNumber, content);
                        }
                    }
                    catch (Exception surnameDig)
                    {

                        Console.WriteLine($"Exception: {surnameDig.Message}");
                    }







                    
                }
            }

            void Print(string param, string[] data)
            {
                int x = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    if (Regex.IsMatch(data[i], param, RegexOptions.IgnoreCase))
                    {
                        Console.WriteLine(data[i]);
                        x++;
                    }
                }
                if (x < 1)
                {
                    Console.WriteLine(@"The subscriber is not in the phone book.");
                }
            }
        }
    }
}

