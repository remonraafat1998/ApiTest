﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Contract
{
    public interface IStoreContextIntializer
    {
        Task intializeAsync();

         Task SeedAsync();

    }
}
