using System;
using NumberToWords.Api.Constants;

namespace NumberToWords.Api.Converters;

public class EnglishNumberConverter : INumberConverter
{
  private readonly string[] ones = ["", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"];
  private readonly string[] tens = ["", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];

  public string LanguageCode { get; } = SupportedLanguage.English.ToString();
  public string UnderThousandConversion(long number)
  {
    List<string> subWords = new List<string>();

    if (number >= 100)
    {
      long num = number / 100;
      subWords.Add(ones[num] + " hundred");
      number = number % 100;
    }

    if (number >= 20)
    {
      long num = number / 10;
      subWords.Add(tens[num]);
      number = number % 10;
    }

    if (number > 0)
    {
      subWords.Add(ones[number]);
    }
    return string.Join(' ', subWords);
  }

  public string HandleNumberToWordsConversion(long number, int cents = 0)
  {
    long originalNumber = number;
    List<string> words = new List<string>();

    if (number == 0)
    {
      words.Add("zero");
    }

    if (number >= 1000_000)
    {
      long num = number / 1000_000;
      words.Add(UnderThousandConversion(num));
      words.Add("million");
      number = number % 1000_000;
    }

    if (number >= 1000)
    {
      long num = number / 1000;
      words.Add(UnderThousandConversion(num));
      words.Add("thousand");
      number = number % 1000;
    }

    if (number > 0)
    {
      words.Add(UnderThousandConversion(number));
    }

    words.Add(originalNumber == 1 ? "dollar" : "dollars");

    /*handle cent*/
    if (cents > 0)
    {
      words.Add("and");
      words.Add(UnderThousandConversion(cents));
      words.Add(cents == 1 ? "cent" : "cents");
    }

    return string.Join(' ', words);
  }
}