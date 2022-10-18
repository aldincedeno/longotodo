using System;
using System.Threading.Tasks;

namespace LongoTodo.Contracts.Repository
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(string uri, string authToken = "");
        Task<T> PostAsync<T>(string uri, T data, string authToken = "");
        Task<T> PutAsync<T>(string uri, T data, string authToken = "");
        Task<bool> DeleteAsync(string uri, string authToken = "");
    }
}
