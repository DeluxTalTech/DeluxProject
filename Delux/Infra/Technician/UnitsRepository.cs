using Abc.Data.Technician;
using Abc.Domain.Quantity;
using Abc.Infra.Common;
using Abc.Infra.DatabaseClasses;

namespace Abc.Infra.Technician
{
    public sealed class UnitsRepository : UniqueEntityRepository<Unit, UnitData>, IUnitsRepository
    {

        public UnitsRepository(QuantityDbContext c) : base(c, c.Units) { }

        protected internal override Unit toDomainObject(UnitData d) => new Unit(d);

    }
}
