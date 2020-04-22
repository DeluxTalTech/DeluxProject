using Abc.Data.Technician;
using Abc.Domain.Quantity;
using Abc.Infra.Common;
using Abc.Infra.DatabaseClasses;

namespace Abc.Infra.Technician {

    public sealed class SystemsOfUnitsRepository : UniqueEntityRepository<SystemOfUnits, SystemOfUnitsData>,
        ISystemsOfUnitsRepository {

        public SystemsOfUnitsRepository() : this(null) { }
        public SystemsOfUnitsRepository(QuantityDbContext c) : base(c, c?.SystemsOfUnits) { }

        protected internal override SystemOfUnits toDomainObject(SystemOfUnitsData d) => new SystemOfUnits(d);

    }

}

