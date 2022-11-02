﻿using CoronaMeccaApp.Models;
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


        Task<Box> GetboxAsync(int id);

        Task<List<Zone>> ZoneListAsync();
        Task<List<Position>> PositionsListAsync();
        Task<List<Types>> TyoesListAsync();

        Task<bool> CreateBox(CreateBox bocreateBox);



    }
}
