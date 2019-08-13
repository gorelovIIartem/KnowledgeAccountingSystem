using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Configurations;
using DAL.EF;
using DAL.Entities;
using DAL.Identity;
using DAL.Interfaces;
using DAL.Repositories;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;

namespace TestDAL
{
    public class TestClass
    {
        private readonly IUnitOfWork _uow;
        public TestClass(string connectionString)
        {
            _uow = new EFUnitOfWork(connectionString);
        }

        public IUnitOfWork UnitOfWork
        {
            get => _uow;
        }
    }
}
