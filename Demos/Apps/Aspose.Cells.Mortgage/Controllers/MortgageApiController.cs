using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Cells.Common.Config;
using Aspose.Cells.Common.Controllers;
using Aspose.Cells.Common.Models;
using Aspose.Cells.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aspose.Cells.Mortgage.Controllers
{
    public class MortgageApiController : CellsApiControllerBase
    {
        private const string AppName = "Mortgage";

        public MortgageApiController(IStorageService storage, IConfiguration configuration, ILogger<MortgageApiController> logger) : base(storage, configuration, logger)
        {
        }

        [HttpPost]
        public JsonResult Mortgage(double homeValue, double downPayment, double interestRate, int loanTerm, DateTime startDate, double propertyTax, double homeIns, double monthlyHOA)
        {
            try
            {
                var wb = calculate(homeValue, downPayment, interestRate, loanTerm, startDate, propertyTax, homeIns, monthlyHOA);
                Logger.LogWarning("AppName = {AppName}",AppName);
                var cells = wb.Worksheets[0].Cells;
                return Json(new { code = 200, result = new { 
                    b14 = cells["b14"].DisplayStringValue,
                    c14 = cells["c14"].DisplayStringValue,
                    b16 = cells["b16"].DisplayStringValue,
                    c16 = cells["c16"].DisplayStringValue,
                    b18 = cells["b18"].DisplayStringValue,
                    c18 = cells["c18"].DisplayStringValue,
                    b20 = cells["b20"].DisplayStringValue,
                    c20 = cells["c20"].DisplayStringValue,
                    b22 = cells["b22"].DisplayStringValue,
                    c22 = cells["c22"].DisplayStringValue,
                    b24 = cells["b24"].DisplayStringValue,
                    c24 = cells["c24"].DisplayStringValue,
                    b26 = cells["b26"].DisplayStringValue,
                    c26 = cells["c26"].DisplayStringValue,
                } });
            }
            catch (Exception e)
            {
                var exception = e.InnerException ?? e;
                Logger.LogError("AppName = {AppName} | Message = {Message} ",
                    AppName, exception.Message);
                return Json(new
                {
                    code = 500,
                    result = exception.Message
                });
            }
        }

        public FileStreamResult Download(string outputType, double homeValue, double downPayment, double interestRate, int loanTerm, DateTime startDate, double propertyTax, double homeIns, double monthlyHOA)
        {
            var wb = calculate(homeValue, downPayment, interestRate, loanTerm, startDate, propertyTax, homeIns, monthlyHOA);
            var doc = new DocumentInfo();
            doc.FileName = "Mortgage-Calculator." + outputType;
            doc.Workbook = wb;
            var dictionary = SaveDocument(doc, GetSaveFormatTypeByOutputType(outputType));
            foreach (KeyValuePair<string, Stream> pair in dictionary)
            {
                return File(pair.Value, "application/octet-stream", pair.Key);
            }
            return null;
        }

        private Workbook calculate(double homeValue, double downPayment, double interestRate, int loanTerm, DateTime startDate, double propertyTax, double homeIns, double monthlyHOA)
        {
            string template = Path.Combine(AppContext.BaseDirectory, "Templates/MortgageTemplate.xlsx");
            var wb = new Workbook(template);
            var cells = wb.Worksheets[0].Cells;
            cells["c2"].PutValue(homeValue);
            cells["c3"].PutValue(downPayment);
            cells["c5"].PutValue(interestRate);
            cells["c6"].PutValue(loanTerm);
            cells["c7"].PutValue(startDate);
            cells["c8"].PutValue(propertyTax);
            cells["c9"].PutValue(homeIns);
            cells["c10"].PutValue(monthlyHOA);
            wb.CalculateFormula();
            return wb;
        }
    }
}
