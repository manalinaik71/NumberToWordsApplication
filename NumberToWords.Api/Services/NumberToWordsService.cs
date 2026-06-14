using System;
using NumberToWords.Api.Constants;
using NumberToWords.Api.Converters;
using NumberToWords.Api.Enums;
using NumberToWords.Api.Models;

namespace NumberToWords.Api.Services;

public class NumberToWordsService : INumberToWordsService
{
    private readonly IEnumerable<INumberConverter> _numberConverter;
    public NumberToWordsService(IEnumerable<INumberConverter> numberConverter)
    {
        _numberConverter = numberConverter;
    }
    public string RequestNumberConverter(NumberConversionRequest numberConversionRequest)
    {
        var converter = _numberConverter.FirstOrDefault(c=> c.LanguageCode == numberConversionRequest.Language);
        if(converter == null)
        {
            throw new NotSupportedException($"No converter found for language code: {numberConversionRequest.Language}");
        }

        var result = converter.HandleNumberToWordsConversion(numberConversionRequest.Number, numberConversionRequest.Cents);
        return result;
    }
}