﻿using DemoApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;
        public CustomerController(ICustomerService service)
        {
            this.service = service; 
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data= await this.service.GetAll(); 
            if(data == null ) {
                return NotFound();  
            }
            return Ok(data);    
        }
    }
}
