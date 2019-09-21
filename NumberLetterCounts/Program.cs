using System;

namespace NumberLetterCount
{
    public class NumberToWordsConverter
    {
        readonly string[] onesMap;
        readonly string[] tensMap;

        public NumberToWordsConverter()
        {
            onesMap = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            tensMap = new string[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        }

        public string NumberToWords(int number)
        {
            if (number <= 0 || number > 999999)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Unsupported number. Valid range: 1 to 999999");
            }

            string words = string.Empty;
            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + "thousand";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + "hundred";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != string.Empty)
                    words += "and";

                if (number < 20)
                    words += onesMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                    {
                        words += onesMap[number % 10];
                    }
                }
            }
            return words;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var converter = new NumberToWordsConverter();
            long totalCount = 0;
            try
            {
                for (int i = 1; i <= 1000; i++)
                {
                    totalCount += converter.NumberToWords(i).Length;
                }
                Console.WriteLine($"Total letters for 1 to 1000 numbers in words: {totalCount}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in converting number to words: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
