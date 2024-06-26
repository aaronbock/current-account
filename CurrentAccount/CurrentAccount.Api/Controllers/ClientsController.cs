using CurrentAccount.Contracts;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CurrentAccount.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly ICustomerService _customerService;

        public ClientsController(ILogger<ClientsController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        [Route("{customerId}/details")]
        public IActionResult GetDetails(int customerId)
        {
            _logger.LogInformation("Calling getdetails for customer id: {id}", customerId);
            var result = _customerService.GetDetails(customerId);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            var viewModel = Mappings.CustomerMapping.MapFromCustomer(result.Value);

            return Ok(viewModel);
        }

        [HttpPost]
        [Route("{customerId}/accounts/open")]
        public IActionResult CreateAccount(int customerId, double initialCredit)
        {
            _logger.LogInformation("Calling createaccount for customer id: {id}", customerId);
            var customerResult = _customerService.OpenAccount(customerId, initialCredit);

            if (customerResult.IsFailed)
            {
                return BadRequest(customerResult.Errors);
            }

            return Ok();
        }

    }
}
