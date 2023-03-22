﻿using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork 
    {
        public IGenericRepository<Genre> GenreRepository { get; }
        public IGenericRepository<Person> PersonRepository { get; }
    }
}
