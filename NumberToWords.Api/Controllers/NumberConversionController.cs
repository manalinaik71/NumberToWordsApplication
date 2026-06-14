using System;
using Microsoft.AspNetCore.Mvc;
using NumberToWords.Api.Constants;
using NumberToWords.Api.Exceptions;
using NumberToWords.Api.Models;
using NumberToWords.Api.Services;

namespace NumberToWords.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NumberConversionController:ControllerBase
{
    private readonly INumberToWordsService _numberToWordsService;
    public NumberConversionController(INumberToWordsService numberToWordsService)
    {
        _numberToWordsService = numberToWordsService;
    }
    
    [HttpPost("convert")]
    public IActionResult ConvertNumbersToWords([FromBody] NumberConversionRequest request)
    {  
     
        if (!ModelState.IsValid)
        {
            throw new BadRequestException(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() ?? "Invalid request.");
        }

        if(request.Language != SupportedLanguage.English && request.Language != SupportedLanguage.German)
        {
            throw new BadRequestException("Unsupported language. Supported languages are 'en' for English and 'de' for German.");
        }

        var result = _numberToWordsService.RequestNumberConverter(request);

        var response = new NumberConversionResponse {words = result};

        return Ok(response);
    }

}