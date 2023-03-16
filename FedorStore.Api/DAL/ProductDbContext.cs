﻿using Microsoft.EntityFrameworkCore;
using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.DAL;

public sealed class ProductsDbContext : DbContext
{
    public DbSet<UserEntity>? Products { get; set; }
}