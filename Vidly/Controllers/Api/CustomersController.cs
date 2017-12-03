using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        private ApplicationDbContext _context;
        //Get /api/customers

        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(x => x.MembershipType);


            if (!string.IsNullOrEmpty(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            }
            var customerDtos = customersQuery.ToList()
            .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _context.Customers.
                SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();

            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }


            var customerInDB = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDB);

            //customerInDB.Name = customerDto.Name;
            //customerInDB.BirthDate = customerDto.BirthDate;
            //customerInDB.MembershipTypeId = customerDto.MembershipTypeId;
            //customerInDB.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }
    }
}
