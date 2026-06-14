using System;

namespace NumberToWords.Api.Converters;

public class EnglishNumberConverter : INumberConverter
{
     string[] ones = ["", "one", "two", "three", "four", "five", "six","seven", "eight","nine","ten","eleven","twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen"];
     string[] tens = ["","","twenty","thirty", "fourty", "fifty", "sixty","seventy","eighty","ninety"];
     
     public string LanguageCode { get; } = "en";
     public string UnderThousandConversion(long number)
      { List<string> subWords = new List<String>();
             
          if(number >= 100)
          {
            long num  = number / 100;
            subWords.Add(ones[num]+ " hundred");
            number = number % 100;
          }

          if(number >= 20)
          {
            long num = number / 10;
            subWords.Add(tens[num]); 
            number = number % 10;
          }

          if(number > 0)
          {
            subWords.Add(ones[number]);
          }
          return string.Join(' ',subWords);
        }
    
     public string HandleNumberToWordsConversion(long number, int cents = 0)
    {    List<string> words = new List<String>();
         
          if(number == 0)
          {
            words.Add("zero dollars");
          }

          if(number >= 1000_000_000)
          {
             long num = number / 1000_000_000;
             words.Add(UnderThousandConversion(num));
             words.Add("billion");
             number = number % 1000_000_000;
          }
           if(number >= 1000_000)
          {
             long num = number / 1000_000;
             words.Add(UnderThousandConversion(num));
             words.Add("million");
             number = number % 1000_000;
          }

          if(number >= 1000)
          {
             long num = number / 1000;
             words.Add(UnderThousandConversion(num));
             words.Add("thousand");
             number = number % 1000; 
          }

          if(number > 0)
          {
            words.Add(UnderThousandConversion(number));
            string dollarword = (number == 1 ? "dollar" : "dollars");
            words.Add(dollarword);
          }

          /*handle cent*/
          if(cents > 0)
          {
            words.Add("and");
            words.Add(UnderThousandConversion(cents));
            words.Add("cents");
          }

          return string.Join(' ',words);
    }

}