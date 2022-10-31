using CoronaMeccaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaMeccaApp.Services
{
    public interface IAPIService
    {
        Task<bool> LoginAsync(User user);

        Task<List<Zone>> ZoneListAsync();


    }
}
