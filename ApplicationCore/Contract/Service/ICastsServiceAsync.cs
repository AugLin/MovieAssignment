﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Service
{
    public interface ICastsServiceAsync
    {
        Task<Casts> GetCastByIdAsync(int id);
    }
}
