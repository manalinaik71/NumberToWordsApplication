using System;

namespace NumberToWords.Api.Converters;

public class EnglishNumberConverter : INumberConverter
{
     string[] ones = ["", "one", "two", "three", "four", "five", "six","seven", "eight","nine","ten","eleven","twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen"];
     string[] tens = ["","","twenty","thirty", "fourty", "fifty", "sixty","seventy","eighty","ninety"];
     
     List<string> words = new List<String>();
     public void UnderThousandConversion(int number)
        {
             
          if(number >= 100)
          {
            int num  = number / 100;
            words.Add(ones[num]+ " hundred");
            number = number % 100;
          }

          if(number >= 20)
          {
            int num = number / 10;
            words.Add(tens[num]); 
            number = number % 10;
          }

          if(number > 0)
          {
            words.Add(ones[number]);
            
          }
        }
    
     public string HandleNumberToWordsConversion(long number)
    {
         
          if(number == 0)
          {
            return "Zero";
          }

          if(number >= 1000_000_000)
          {
             long num = number / 1000_000_000;
             UnderThousandConversion((int)num);
             words.Add("billion");
             number = number % 1000_000_000;
          }
           if(number >= 1000_000)
          {
             long num = number / 1000_000;
             UnderThousandConversion((int)num);
             words.Add("million");
             number = number % 1000_000;
          }

          if(number >= 1000)
          {
             long num = number / 1000;
             UnderThousandConversion((int) num);
             words.Add("thousand");
             number = number % 1000; 
          }

          if(number > 0)
          {
            UnderThousandConversion((int)number);
            words.Add("dollars");
          }

          /*handle cent*
          if(cent > 0)
          {
            words.Add("and");
            UnderThousandConversion(cent);
            words.Add("cents");
          } */

          return string.Join(' ',words);
    }

}