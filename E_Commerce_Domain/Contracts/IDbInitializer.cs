﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Domain.Contracts
{
    public interface IDbInitializer
    {
        Task InitializeAsync();
    }
}
