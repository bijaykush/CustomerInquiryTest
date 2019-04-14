using System.Threading.Tasks;
using CustomerInquiry.Service.DTO;
using CustomerInquiry.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInquiry.WebAPI.Controllers
{
    [Route("api/customerinquiry")]
    [ApiController]
    public class CustomerInquiryController : ControllerBase
    {
        private readonly ICustomerInquiryService _customerInquiryService;

        public CustomerInquiryController(ICustomerInquiryService customerInquiryService)
        {
            _customerInquiryService = customerInquiryService;
        }


        [HttpPost("profile")]
        public async Task<IActionResult> GetCustomerProfile(CustomerInquiryFilterDTO customerInquiryFilter)
        {
            if (customerInquiryFilter == null) return BadRequest("No inquiry criteria");

            if (!ModelState.IsValid) return BadRequest("invalid customer id or email address");

            var customerProfile = await _customerInquiryService.GetCustomerProfile(customerInquiryFilter);

            if (customerProfile == null) return NotFound("No records found");

            return Ok(customerProfile);
        }
    }
}
