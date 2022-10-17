using System;
using System.Threading.Tasks;

namespace LongoTodo.Contracts.Repository
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(string uri, string authToken = "");
    }
}
