﻿using System;
using Abc.Data.Technician;
using Abc.Domain.Quantity;
using Abc.Infra;
using Abc.Infra.Common;
using Abc.Infra.DatabaseClasses;
using Abc.Infra.Technician;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Infra.Quantity
{
    [TestClass]
    public class SystemsOfUnitsRepositoryTests : RepositoryTests<SystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsData>
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<QuantityDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new QuantityDbContext(options);
            dbSet = ((QuantityDbContext)db).SystemsOfUnits;
            obj = new SystemsOfUnitsRepository((QuantityDbContext)db);
            base.TestInitialize();

        }

        protected override string getId(SystemOfUnitsData d) => d.Id;

        protected override SystemOfUnits getObject(SystemOfUnitsData d) => new SystemOfUnits(d);

        protected override void setId(SystemOfUnitsData d, string id) => d.Id = id;

        internal override Type getBaseType()
        {
            return typeof(PaginatedRepository<SystemOfUnits, SystemOfUnitsData>);
        }
    }
}
