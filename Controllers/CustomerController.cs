using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public static List<Customer> customers = new()
        { 
            new Customer { Id=1,FirstName="john",LastName="rocky",City="mumbai" },
            new Customer { Id = 2, FirstName = "2", LastName = "2", City = "2" }
        };
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = customers.Find(x=> x.Id == id);  
            if(customer == null)
            {
                return NotFound("Customwer not found");
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            customers.Add(customer);
            return Ok(customers);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var customerlist=customers.Find(x=>x.Id == customer.Id);
            if (customerlist == null)
                return NotFound("Invalid customer details");
            customerlist.FirstName = customer.FirstName;
            customerlist.LastName = customer.LastName;
            customerlist.City = customer.City;
            return Ok(customerlist);
        }

        [HttpDelete]
        public IActionResult Deletecustomer(int id)
        {
            var customer=customers.Find(x=>x.Id == id);
            if(customer==null)
            {
                return NotFound("invaliud customewr details");
            }
            customers.Remove(customer);
            return Ok(customer);
        }

    }
}
