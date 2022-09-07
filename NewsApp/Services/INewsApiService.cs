using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Services
{
    public interface INewsApiService
    {
        Task<NewsModel> GetNewsAsync(string topic);
    }
}
