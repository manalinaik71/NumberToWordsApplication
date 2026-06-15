using NumberToWords.Api.Converters;
using NumberToWords.Api.Exceptions;
using NumberToWords.Api.Models;

namespace NumberToWords.Api.Services;

public class NumberToWordsService : INumberToWordsService
{
    private readonly IEnumerable<INumberConverter> _numberConverters;
    public NumberToWordsService(IEnumerable<INumberConverter> numberConverter)
    {
        _numberConverters = numberConverter;
    }
    public string RequestNumberConverter(NumberConversionRequest numberConversionRequest)
    {   
        var language = numberConversionRequest.Language.Trim().ToLower();
        var converter = _numberConverters.FirstOrDefault(c=> c.LanguageCode == language);
        if(converter == null)
        {
            throw new BadRequestException($"No converter found for language code: {numberConversionRequest.Language}");
        }

        var result = converter.HandleNumberToWordsConversion(numberConversionRequest.Number, numberConversionRequest.Cents);
        return result;
    }
}