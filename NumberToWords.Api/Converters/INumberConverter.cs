using System;

namespace NumberToWords.Api.Converters;

public interface INumberConverter
{
    public string HandleNumberToWordsConversion(long number);
}