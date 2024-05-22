using AutoMapper;
using DemoApi.Modal;
using DemoApi.Repos;
using DemoApi.Repos.Models;
using DemoApi.Service;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Container
{
    public class CustomerService : ICustomerService
    {
        private readonly LearndataContext _context;
        private readonly IMapper _mapper;   
        public CustomerService(LearndataContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }    
        public async Task<List<Customermodal>> GetAll()
        {
            List<Customermodal> _response = new List<Customermodal>();
            var _data= await this._context.TblCustomers.ToListAsync();
            if(_data != null) { 
              _response=this._mapper.Map<List<TblCustomer>,List<Customermodal>>(_data);
            }
            return _response;
        }
    }
}
