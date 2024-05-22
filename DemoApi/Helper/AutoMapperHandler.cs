using AutoMapper;
using DemoApi.Modal;
using DemoApi.Repos.Models;

namespace DemoApi.Helper
{
    public class AutoMapperHandler:Profile
    {
        public AutoMapperHandler()
        {
             CreateMap<TblCustomer, Customermodal>().ForMember(item => item.Statusname, opt => opt.MapFrom(
                item => ( item.IsActive.Value )? "Active" : "In active"));
        }
    }
}
