using Microsoft.AspNetCore.Mvc;
using SistemaMarketing.Data;
using SistemaMarketing.Services;

namespace SistemaMarketing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly MarketingContext _context;
        private readonly ExcelService _excelService;

        public ClientesController(MarketingContext context, ExcelService excelService)
        {
            _context = context;
            _excelService = excelService;
        }

        [HttpGet("reporte")]
        public IActionResult GenerarReporte()
        {
            var clientes = _context.Clientes.ToList();
            var excelBytes = _excelService.Generar(clientes);
            return File(excelBytes, 
                     "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
                     "Clientes.xlsx");
        }
    }
}