using System;
using System.ComponentModel.DataAnnotations;
using NumberToWords.Api.Enums;

namespace  NumberToWords.Api.Models;

public class NumberConversionRequest
{   [Required]
    [Range(0,999_999_999, ErrorMessage = "Number must be between 0 and 999,999,999.")]
    public long Number { get; set; } = 0;

    [Range(0,99, ErrorMessage = "Cents must be between 0 and 99.")]
    public int Cents { get; set; }= 0;
    
    [Required]
    public string Language { get; set; } = string.Empty;
}