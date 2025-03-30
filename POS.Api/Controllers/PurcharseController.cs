using Microsoft.AspNetCore.Mvc;
using POS.Application.Commons.Bases.Request;
using POS.Application.Dtos.Purcharse.Request;
using POS.Application.Dtos.Warehouse.Request;
using POS.Application.Interfaces;
using POS.Application.Services;
using POS.Utilities.Static;

namespace POS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurcharseController : ControllerBase
    {
        private readonly IPurcharseApplication _purcharseApplication;
        private readonly IGenerateExcelApplication _generateExcelApplication;

        public PurcharseController(IPurcharseApplication purcharseApplication, IGenerateExcelApplication generateExcelApplication)
        {
            _purcharseApplication = purcharseApplication;
            _generateExcelApplication = generateExcelApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListPurcharse([FromQuery] BaseFiltersRequest filters)
        {
            var response = await _purcharseApplication.ListPurcharse(filters);

            if ((bool)filters.Download!)
            {
                var columnNames = ExcelColumnNames.GetColumnsPurcharse();
                var fileBytes = _generateExcelApplication.GenerateToExcel(response.Data!, columnNames);
                return File(fileBytes, ContentType.ContentTypeExcel);
            }
            return Ok(response);
        }

        [HttpGet("{purcharseId:int}")]
        public async Task<IActionResult> PurcharseById(int purcharseId)
        {
            var response = await _purcharseApplication.PurcharseById(purcharseId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterPurcharse([FromBody] PurcharseRequestDto requestDto)
        {
            var response = await _purcharseApplication.RegisterPurcharse(requestDto);
            return Ok(response);
        }

        [HttpPut("Cancel/{purcharseId:int}")]
        public async Task<IActionResult> RemovePurcharse(int purcharseId)
        {
            var response = await _purcharseApplication.CancelPurcharse(purcharseId);
            return Ok(response);
        }
    }
}
