using System;

namespace NumberToWords.Api.Converters;

public interface INumberConverter
{
    public string LanguageCode { get; }    
    public string HandleNumberToWordsConversion(long number, int cents = 0);
}