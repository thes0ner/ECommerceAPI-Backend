﻿using ECommerceAPI.Application.Repositories.BaseRepository.Abstract;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    public interface IOrderCommandRepository :ICommandRepository<Order>
    {
    }
}