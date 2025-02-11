﻿using Microsoft.AspNetCore.Mvc;
using POS.Application.Commons.Bases.Request;
using POS.Application.Dtos.Warehouse.Request;
using POS.Application.Interfaces;
using POS.Utilities.Static;

namespace POS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseApplication _warehouseApplication;
        private readonly IGenerateExcelApplication _generateExcelApplication;

        public WarehouseController(IWarehouseApplication warehouseApplication, IGenerateExcelApplication generateExcelApplication)
        {
            _warehouseApplication = warehouseApplication;
            _generateExcelApplication = generateExcelApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListWarehouse([FromQuery] BaseFiltersRequest filters)
        {
            var response = await _warehouseApplication.ListWarehouses(filters);

            if ((bool)filters.Download!)
            {
                var columnNames = ExcelColumnNames.GetColumnsWarehouses();
                var filesBytes = _generateExcelApplication.GenerateToExcel(response.Data!, columnNames);
                return File(filesBytes, ContentType.ContentTypeExcel);
            }
            return Ok(response);
        }

        [HttpGet("{warehouseId:int}")]
        public async Task<IActionResult> WarehouseById(int warehouseId)
        {
            var response = await _warehouseApplication.WarehousesById(warehouseId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterWArehouse([FromBody] WarehouseRequestDto requestDto)
        {
            var response = await _warehouseApplication.RegisterWarehouse(requestDto);
            return Ok(response);
        }
    }
}
