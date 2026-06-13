using System;
using NumberToWords.Api.Enums;

namespace  NumberToWords.Api.Models;

public class NumberConversionRequest
{
    public long Number { get; set; }
    public string Language { get; set; } = string.Empty;
}