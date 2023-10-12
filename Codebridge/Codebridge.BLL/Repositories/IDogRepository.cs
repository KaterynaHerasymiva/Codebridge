﻿using Codebridge.BLL.Entities;

namespace Codebridge.BLL.Repositories;

public interface IDogRepository
{
    IQueryable<Dog> GetDogs();
}