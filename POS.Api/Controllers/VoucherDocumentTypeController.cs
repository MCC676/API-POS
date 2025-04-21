using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Interfaces;

namespace POS.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherDocumentTypeController : ControllerBase
    {
        private readonly IVoucherDocumentTypeApplication _voucherDocumentTypes;

        public VoucherDocumentTypeController(IVoucherDocumentTypeApplication voucherDocumentTypes)
        {
            _voucherDocumentTypes = voucherDocumentTypes;
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectWarehouses()
        {
            var response = await _voucherDocumentTypes.ListSelectVoucherDocumentType();
            return Ok(response);
        }
    }
}
