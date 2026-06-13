using System;
using Microsoft.AspNetCore.Mvc;
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
        if(request == null)
        {
            return BadRequest("Request Cannot be null");
        }

        var result = _numberToWordsService.RequestNumberConverter(request);

        var response = new NumberConversionResponse {words = result};

        return Ok(response);
    }

}