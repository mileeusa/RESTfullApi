using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CpiApi.Services;
using CpiApi.Models;

namespace CpiApi.Controllers;

[ApiController]
[Route("api/Cpi")]
public class CpiController : ControllerBase
{
    private readonly IBlsClient _blsClient;

    public CpiController(IBlsClient blsClient)
    {
        _blsClient = blsClient;
    }

    /// <summary>
    /// Get CPI integer value and notes for a given month and year and optional seriesId.
    /// Example: GET /api/cpi?year=2020&month=05&seriesId=LAUCN040010000000005
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<CpiResponse>> Get([FromQuery] int year, [FromQuery] int month, [FromQuery] string? seriesId = null)
    {
        if (month < 1 || month > 12)
        {
            return BadRequest("month must be between 1 and 12");
        }

        if (year < 1900 || year > DateTime.UtcNow.Year + 1)
        {
            return BadRequest("year out of range");
        }

        var cpiResponse = await _blsClient.GetCpiForMonthAsync(year, month, seriesId);

        if (cpiResponse == null)
        {
            return NotFound(string.Format($"CPI data not found for the requested {year}/{month}/{seriesId}"));
        }

        return Ok(cpiResponse);
    }
}
