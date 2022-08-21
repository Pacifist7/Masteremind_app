using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_mind_app
{

 

    public static class MasterMind
    {

        public static void RunGame()
        {
            var rnd = new Random();
            var hiddenNumber = $"{rnd.Next(1, 6)}{rnd.Next(1, 6)}{rnd.Next(1, 6)}{rnd.Next(1, 6)}";
            Console.WriteLine(hiddenNumber);

            Console.WriteLine("Choose a number with 4 digits, where each digit is between 1 and 6");
            Console.WriteLine("There are 6 colors supported: 1=Red, 2=Green, 3=Yellow, 4=Blue, 5=Black and 6=Orange");
            Console.WriteLine("(+) is used if one of the chosen colors is in the right position as in the secret code");
            Console.WriteLine("(-) is used if one of the chosen colors is present in the code, but its position is incorrect.");
            
            var isGuessed = false;

            for (int j = 0; j < 10; j++)
            {

                Console.WriteLine("attempt: " + (j + 1));

                var guessNumber = Console.ReadLine();
                var isValid = CheckGuessNumber(guessNumber);

                while (!isValid)
                {
                    Console.WriteLine("Your guess does not meet the requirements. Keep in mind that all the digits should be between 1 and 6.");
                    Console.WriteLine("Try again: ");
                    guessNumber = Console.ReadLine();
                    isValid = CheckGuessNumber(guessNumber);
                }

                var resultPlus = "";
                var resultMinus = "";


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
                        }

                        //not same position
                        else
                        {
                            resultMinus += "-";
                        }
                    }
                }

                
                Console.WriteLine(resultPlus + resultMinus);


                if (resultPlus == "++++")
                {
                    Console.WriteLine("Congratulations, you cracked the code!");
                    isGuessed = true;
                    break;
                }
            }

            if (!isGuessed)
                Console.WriteLine("Unfortunately you lost, try again another time.");

        }


        public static bool CheckGuessNumber(string guessNumber)
        {
            for (int i = 0; i < guessNumber.Length; i++)
            {
                if (guessNumber[i] != '1' && guessNumber[i] != '2' && guessNumber[i] != '3' && guessNumber[i] != '4' && guessNumber[i] != '5' && guessNumber[i] != '6')
                    return false;
            }
            return true;
        }


    }
}
