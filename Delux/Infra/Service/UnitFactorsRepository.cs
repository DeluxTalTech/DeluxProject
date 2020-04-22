using System.Threading.Tasks;
using Abc.Aids;
using Abc.Data.Service;
using Abc.Domain.Quantity;
using Abc.Infra.Common;
using Abc.Infra.DatabaseClasses;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra.Service {

    public sealed class UnitFactorsRepository : PaginatedRepository<UnitFactor, UnitFactorData>, IUnitFactorsRepository {

        public UnitFactorsRepository() : this(null) { }
        public UnitFactorsRepository(QuantityDbContext c) : base(c, c?.UnitFactors) { }

        protected internal override UnitFactor toDomainObject(UnitFactorData d) => new UnitFactor(d);

        protected override async Task<UnitFactorData> getData(string id) {
            var systemOfUnitsId = GetString.Head(id);
            var unitId = GetString.Tail(id);

            return await dbSet.SingleOrDefaultAsync(x => x.SystemOfUnitsId == systemOfUnitsId && x.UnitId == unitId);
        }

        protected override string getId(UnitFactor obj) {
            return obj?.Data is null ? string.Empty : $"{obj.Data.SystemOfUnitsId}.{obj.Data.UnitId}";
        }

    }

}
