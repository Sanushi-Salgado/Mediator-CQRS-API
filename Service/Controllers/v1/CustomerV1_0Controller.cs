using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETDemo.Data.Models.RequestModels;
using NETDemo.Data.Repository.Abstractions;
using NETDemo.Domain.Handlers.CommandHandlers;
using NETDemo.Domain.Handlers.QueryHandlers;
using System;
using System.Threading.Tasks;

namespace NETDemo.Service.Controllers
{
    //[Route("api/[controller]")]
    //[Route("api/customers")]
    [ApiVersion("1.0")]
    //[Route("v{v:apiVersion}/customers")] // Using URL versioning
    [Route("customers")]
    [ApiController]
    public class CustomerV1_0Controller : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerV1_0Controller> _logger; // Indicate the class name from where the error is coming

        public CustomerV1_0Controller(ICustomerRepository repository, IMediator mediator, ILogger<CustomerV1_0Controller> logger)
        {
            _repository = repository;
            _mediator = mediator;
            _logger = logger;
        }


        /// <summary>
        /// Get all customers
        /// </summary>
        /// <remarks>
        ///  Get the details of all customers
        /// </remarks>
        /// <returns>A list of customers</returns> 
        // GET: api/customers
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                //_repository.GetAllCustomers();

                var result = await _mediator.Send(new GetAllCustomersQuery());
                if (result != null)
                    //return Ok();
                    return Ok(new { success = true, message = "Customers retreived successfully!", customers_list = result });
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

                //_logger.LogTrace("Trace log");
                //_logger.LogDebug("Debug log");
                //_logger.LogInformation("Information log");
                //_logger.LogWarning("Warning log");
                //_logger.LogError($"The path {exceptionDetails.Path} threw an exception {exceptionDetails.Error}");
                //_logger.LogCritical("Critical log");

                return BadRequest(new { success = false, message = "An error occured while retrieving customers!", exception = ex });
            }
        }



        /// <summary>
        /// Get selected customer
        /// </summary>
        /// <remarks>
        /// Get the details of a particular customer using the customer id
        /// </remarks>
        /// <param name="id">Refers to the customer id</param>
        /// <returns>The details of a single customer</returns>
        // GET: api/customer/5
        //[HttpGet("{id}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetCustomerByIdQuery { CustomerId = id });
                if (result != null)
                    return Ok(new { success = true, message = "Customer retreived successfully!", customer = result });
                else
                    return NotFound(new { success = false, message = "Retreived failed. Customer does not exist!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while retreiving customer!", exception = ex });
            }
        }


        /// <summary>
        /// Add a new customer
        /// </summary>
        /// <remarks>
        /// Create a new customer with the relevant details
        /// </remarks>
        /// <returns></returns>
        // POST: api/customers
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerModel model)
        {
            try
            {
                var result = await _mediator.Send(new CreateCustomerCommand(model));
                return Ok(new { success = true, message = "Customer created successfully!", customer = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while creating customer!", exception = ex });
            }
        }



        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <remarks>
        /// Update the details of an existing customer using the customer id
        /// </remarks>
        /// <param name="id">Refers to the customer id</param>
        /// <returns></returns>
        // PUT: api/customer/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, [FromBody] UpdateCustomerModel model)
        {
            try
            {
                var result = await _mediator.Send(new UpdateCustomerCommand(id, model));
                if (result != null)
                    return Ok(new { success = true, message = "Customer updated successfully!", customer = result });
                else
                    return NotFound(new { success = false, message = "Update failed. Customer does not exist!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while updating customer!", exception = ex });
            }

        }


        /// <summary>
        /// Delete an existing customer
        /// </summary>
        /// <remarks>
        /// Delete an existing customer using the customer id
        /// </remarks>
        /// <param name="id">Refers to the customer id</param>
        /// <returns></returns>
        // DELETE: api/customers/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCustomerCommand(id));
                if (result != null)
                    return Ok(new { success = true, message = "Customer deleted successfully!", customer = result });
                else
                    //return NotFound();
                    return NotFound(new { success = false, message = "Delete failed. Customer does not exist!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while deleting customer!", exception = ex });
            }
        }


    }
}
