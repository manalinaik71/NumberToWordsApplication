using System;
using NumberToWords.Api.Constants;
using NumberToWords.Api.Converters;
using NumberToWords.Api.Enums;
using NumberToWords.Api.Models;

namespace NumberToWords.Api.Services;

public class NumberToWordsService : INumberToWordsService
{
    private readonly INumberConverter _numberConverter;
    public NumberToWordsService(INumberConverter numberConverter)
    {
        _numberConverter = numberConverter;
    }
    public string RequestNumberConverter(NumberConversionRequest numberConversionRequest)
    {
        
        if(numberConversionRequest.Language == SupportedLanguage.English)
        { 
          string outputString = _numberConverter.HandleNumberToWordsConversion(numberConversionRequest.Number);
          return outputString;
        }

        return "";
    }
}