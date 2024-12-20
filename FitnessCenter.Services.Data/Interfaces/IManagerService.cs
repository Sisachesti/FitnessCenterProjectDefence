﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Services.Data.Interfaces
{
    public interface IManagerService
    {
        Task<bool> IsUserManagerAsync(string? userId);

        Task<bool> RemoveManagerAsync(string? userId);

        Task<bool> AddManagerAsync(string? userId);
    }
}
