﻿using Persistence.DbContext;
using Domain.Entities;
using Application.Common.Interfaces;

namespace Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly VinylShopDbContext _context;
        private GenericRepository<Genre> _genreRepository;
        private GenericRepository<Person> _personRepository;

        public UnitOfWork(VinylShopDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Genre> GenreRepository => _genreRepository ??= new GenericRepository<Genre>(_context);
        public IGenericRepository<Person> PersonRepository => _personRepository ??= new GenericRepository<Person>(_context);

        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}