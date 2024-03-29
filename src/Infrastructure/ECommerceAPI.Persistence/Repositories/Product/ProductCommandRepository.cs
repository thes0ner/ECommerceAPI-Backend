﻿using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class ProductCommandRepository : CommandRepository<Product>, IProductCommandRepository
    {
        public ProductCommandRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
