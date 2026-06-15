using System;
using NumberToWords.Api.Constants;

namespace NumberToWords.Api.Converters;

public class GermanNumberConverter : INumberConverter
{
    public string LanguageCode { get; } = SupportedLanguage.German.ToString();
    private readonly string[] ones = ["", "eins", "zwei", "drei", "vier", "fünf", "sechs", "sieben", "acht", "neun", "zehn", "elf", "zwölf", "dreizehn", "vierzehn", "fünfzehn", "sechzehn", "siebzehn", "achtzehn", "neunzehn"];

    private readonly string[] tens = ["", "", "zwanzig", "dreißig", "vierzig", "fünfzig", "sechzig", "siebzig", "achtzig", "neunzig"];


    public string UnderHundredConversion(int number)
    {
        string t = ""; string o = ""; string output = "";

        if (number >= 20)
        {
            int num = number / 10;
            t = tens[num];
            number = number % 10;
        }

        if (number == 0)
        {
            return t;
        }

        o = (number == 1 ? "ein" : ones[number]);
        output = (t != "" ? (o + "und" + t) : o);

        return output;
    }

    public string UnderThousandConversion(int number)
    {
        List<string> words = new List<string>();

        if (number >= 100)
        {
            int hundredPart = number / 100;
            string hundredWord = hundredPart == 1 ? "ein" : ones[hundredPart];

            words.Add(hundredWord + "hundert");

            number = number % 100;
        }

        if (number > 0)
        {
            words.Add(UnderHundredConversion(number));
        }

        return string.Join(' ', words);
    }

    public string HandleNumberToWordsConversion(long number, int cents = 0)
    {

        List<string> words = new List<string>();
        if (number == 0)
        {
            words.Add("null");
        }

        if (number >= 1_000_000)
        {
            long millionPart = number / 1_000_000;

            if (millionPart == 1)
                words.Add("eine Million");
            else
                words.Add(UnderThousandConversion((int)millionPart) + " Millionen");

            number = number % 1_000_000;
        }

        if (number >= 1000)
        {
            long thousandPart = number / 1000;

            if (thousandPart == 1)
                words.Add("eintausend");
            else
                words.Add(UnderThousandConversion((int)thousandPart) + "tausend");

            number = number % 1000;
        }

        if (number > 0)
        {
            words.Add(UnderThousandConversion((int)number));
        }
        words.Add("Dollar");

        /*handle cent*/
        if (cents > 0)
        {
            words.Add("und");
            words.Add(UnderThousandConversion(cents));
            words.Add("Cent");
        }

        return string.Join(' ', words);
    }
}
