using System;
using Abc.Aids;
using Abc.Data.Service;
using Abc.Domain.Quantity;
using Abc.Infra;
using Abc.Infra.Common;
using Abc.Infra.DatabaseClasses;
using Abc.Infra.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Infra.Quantity
{
    [TestClass]
    public class UnitFactorsRepositoryTests : RepositoryTests<UnitFactorsRepository, UnitFactor, UnitFactorData>
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<QuantityDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new QuantityDbContext(options);
            dbSet = ((QuantityDbContext)db).UnitFactors;
            obj = new UnitFactorsRepository((QuantityDbContext)db);
            base.TestInitialize();

        }

        protected override string getId(UnitFactorData d) => $"{d.SystemOfUnitsId}.{d.UnitId}";

        protected override UnitFactor getObject(UnitFactorData d) => new UnitFactor(d);

        protected override void setId(UnitFactorData d, string id)
        {
            var systemOfUnitsId = GetString.Head(id);
            var unitId = GetString.Tail(id);
            d.SystemOfUnitsId = systemOfUnitsId;
            d.UnitId = unitId;
        }

        internal override Type getBaseType()
        {
            return typeof(PaginatedRepository<UnitFactor, UnitFactorData>);
        }
    }
}
