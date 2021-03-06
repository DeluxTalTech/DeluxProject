﻿using Abc.Domain.Quantity;
using Abc.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using Abc.Aids;
using Abc.Data.Technician;
using Abc.Infra.Common;
using Abc.Infra.DatabaseClasses;
using Abc.Infra.Technician;

namespace Abc.Tests.Infra.Quantity
{
    [TestClass]
    public class MeasuresRepositoryTests : RepositoryTests<MeasuresRepository, Measure, MeasureData>
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<QuantityDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new QuantityDbContext(options);
            dbSet = ((QuantityDbContext)db).Measures;
            obj = new MeasuresRepository((QuantityDbContext) db);
            base.TestInitialize();

        }

        protected override string getId(MeasureData d) => d.Id;

        protected override Measure getObject(MeasureData d) => new Measure(d);

        protected override void setId(MeasureData d, string id) => d.Id = id;

        internal override Type getBaseType()
        {
            return typeof(UniqueEntityRepository<Measure, MeasureData>);
        }
    }
}
