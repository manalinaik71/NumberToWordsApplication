using System;
using NumberToWords.Api.Models;

namespace NumberToWords.Api.Services;

public interface INumberToWordsService
{
    public string RequestNumberConverter(NumberConversionRequest numberConversionRequest);
}