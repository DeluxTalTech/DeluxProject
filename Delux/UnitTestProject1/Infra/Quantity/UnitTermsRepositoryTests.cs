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
    public class UnitTermsRepositoryTests : RepositoryTests<UnitTermsRepository, UnitTerm, UnitTermData>
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<QuantityDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new QuantityDbContext(options);
            dbSet = ((QuantityDbContext)db).UnitTerms;
            obj = new UnitTermsRepository((QuantityDbContext)db);
            base.TestInitialize();

        }

        protected override string getId(UnitTermData d) => $"{d.MasterId}.{d.TermId}";

        protected override UnitTerm getObject(UnitTermData d) => new UnitTerm(d);

        protected override void setId(UnitTermData d, string id)
        {
            var masterId = GetString.Head(id);
            var termId = GetString.Tail(id);
            d.MasterId = masterId;
            d.TermId = termId;
        }

        internal override Type getBaseType()
        {
            return typeof(PaginatedRepository<UnitTerm, UnitTermData>);
        }
    }
}
