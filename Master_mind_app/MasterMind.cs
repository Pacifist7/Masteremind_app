using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_mind_app
{
    public static class MasterMind
    {

        public static void CheckNumber()
        {
            var rnd = new Random();
            var hiddenNumber = $"{rnd.Next(1, 6)}{rnd.Next(1, 6)}{rnd.Next(1, 6)}{rnd.Next(1, 6)}";
            Console.WriteLine(hiddenNumber);

            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("Choose a number with 4 digits, where each digit is between 1 and 6");
                Console.WriteLine("There are 6 colors supported: 1=Red, 2=Green, 3=Yellow, 4=Blue, 5=Black and 6=Orange");
                Console.WriteLine("(+) is used if one of the chosen colors is in the right position as in the secret code");
                Console.WriteLine("(-) is used if one of the chosen colors is present in the code, but its position is incorrect.");
                var guessNumber = Console.ReadLine();
                //CheckNumber
                
                var resultMinus = "";
                var resultPlus = "";

                //control guessNumber
                for (int i = 0; i < guessNumber.Length; i++)
                {
                    var digit = guessNumber[i];
                    if (hiddenNumber.Contains(digit))
                    {
                        //same position
                        if (hiddenNumber[i] == digit)
                        {
                            resultPlus += "+";
                            Console.WriteLine("+");
                        }

                        //not same position
                        else
                        {
                            resultMinus += "-";
                            Console.WriteLine("-");
                        }
                    }
                }

                if (resultPlus == "++++")
                {
                    Console.WriteLine("Congratulations, you cracked the code!");
                    break;
                }
            }
            Console.WriteLine("Unfortunately you lost, try again another time.");
        }


        private static void CheckGuessNumber(string guessNumber)
        {
            for (int i = 0; i < guessNumber.Length; i++)
            {
                if (guessNumber[i] == '1' || guessNumber[i] == '2' || guessNumber[i] == '3' || guessNumber[i] == '4' || guessNumber[i] == '5' || guessNumber[i] == '6')
                {
                    Console.WriteLine("All right then.");
                    continue;
                }
                else
                {
                    Console.WriteLine("Your guess does not match the requirements");
                    break;
                }
            }
        }


    }
}
