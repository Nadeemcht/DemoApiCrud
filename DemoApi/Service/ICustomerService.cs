using DemoApi.Modal;
using DemoApi.Repos.Models;

namespace DemoApi.Service
{
    public interface ICustomerService
    {
        Task <List<Customermodal>> GetAll();
    }
}
