using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Statistic.Application.Dto;
using Statistic.Application.Interfaces;
using Statistic.Domain.Models;
using System;

namespace Statistic.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeteorologyController : ControllerBase
    {
        private readonly IMeteorologyRepository _meteorologyRepository;

        public MeteorologyController(IMeteorologyRepository meteorologyRepository)
        {
            _meteorologyRepository = meteorologyRepository;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        [HttpGet("GetMeteorologyData")]
        public async Task<IActionResult> GetMeteorologyData([FromQuery] MeteorologyDto filter)
        {
            var (data, totalItems) = await _meteorologyRepository.GetMeteorologyDataAsync(filter);

            return Ok(new
            {
                TotalItems = totalItems,
                Data = data
            });
        }

        [HttpGet("GetMonthsAsync")]
        public Task<List<string>> GetMonthsAsync()
        {
            return _meteorologyRepository.GetDistinctValuesAsync<Meteorology, string>(x => x.Month);
        }

        [HttpGet("GetYearsAsync")]
        public Task<List<int>> GetYearsAsync()
        {
            return _meteorologyRepository.GetDistinctValuesAsync<Meteorology, int>(x => x.Year);
        }

        [HttpGet("ExportToExcel")]
        public async Task<IActionResult> ExportToExcel([FromQuery] MeteorologyDto filter)
        {
            var (meteorologyData, totalItems) = await _meteorologyRepository.GetMeteorologyDataAsync(filter);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Meteorology Data");

                worksheet.Cells[1, 1].Value = "Год";
                worksheet.Cells[1, 2].Value = "Месяц";
                worksheet.Cells[1, 3].Value = "Температура воздуха";

                for (int i = 0; i < meteorologyData.Count(); i++)
                {
                    var data = meteorologyData.ElementAt(i);
                    worksheet.Cells[i + 2, 1].Value = data.Year;
                    worksheet.Cells[i + 2, 2].Value = data.Month;
                    worksheet.Cells[i + 2, 3].Value = data.AirTemperature;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                var fileBytes = package.GetAsByteArray();

                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MeteorologyData.xlsx");
            }
        }
    }
}