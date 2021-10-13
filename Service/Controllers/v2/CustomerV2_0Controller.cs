using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETDemo.Data.Repository.Abstractions;
using NETDemo.Domain.Handlers.CommandHandlers;
using NETDemo.Domain.Handlers.QueryHandlers;
using System;
using System.Threading.Tasks;

namespace NETDemo.Service.Controllers
{
    //[Route("api/[controller]")]
    [ApiVersion("2.0")]
    //[Route("v{v:apiVersion}/customers")]  // Using URL versioning
    [Route("customers")]
    [ApiController]
    public class CustomerV2_0Controller : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerV2_0Controller> _logger;

        public CustomerV2_0Controller(ICustomerRepository repository, IMediator mediator, ILogger<CustomerV2_0Controller> logger)
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
                var result = await _mediator.Send(new GetAllCustomersQuery());
                if (result != null)
                    return Ok(new { success = true, status_code = 200, message = "Customers retreived successfully!", customers_list = result });
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, status_code = 400, message = "An error occured while retrieving customers!", error = e.Message });
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
        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            try
            {
                var result = await _mediator.Send(new GetCustomerByIdQuery { CustomerId = id });
                if (result != null)
                    return Ok(new { success = true, status_code = 200, message = "Customer retreived successfully!", customer = result });
                else
                    return NotFound(new { success = false, status_code = 404, message = "Customer does not exist!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, status_code = 400, message = "An error occured while creating customer!", exception = ex });
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
        public async Task<IActionResult> AddCustomer([FromBody] CreateCustomerCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new { success = true, status_code = 200, message = "Customer created successfully!", customer = result });
            }
            catch (Exception)
            {
                return BadRequest(new { success = false, status_code = 400, message = "An error occured while creating customer." });
            }
        }



        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <remarks>
        /// Update the details of an existing user using the user id
        /// </remarks>
        /// <param name="id">Refers to the user id</param>
        /// <returns></returns>
        // PUT: api/users/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, [FromBody] UpdateCustomerCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != null)
                    return Ok(new { success = true, status_code = 200, message = "Customer created successfully!", customer = result });
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest(new { success = false, status_code = 400, message = "An error occured while updating customer." });
            }

        }


        /// <summary>
        /// Delete an existing customer
        /// </summary>
        /// <remarks>
        /// Delete an existing customer using the customer id
        /// </remarks>
        /// <param name="customerId">Refers to the customer id</param>
        /// <returns></returns>
        // DELETE: api/customers/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int customerId, DeleteCustomerCommand command)
        {
            try
            {
                var clients = await _mediator.Send(command);
                return Ok(clients);
            }
            catch (Exception)
            {
                return BadRequest(new { success = false, status_code = 400, message = "An error occured while deleting customer." });
            }
        }


    }
}
