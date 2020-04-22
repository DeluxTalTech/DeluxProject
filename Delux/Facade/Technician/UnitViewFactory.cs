using Abc.Aids;
using Abc.Data.Technician;
using Abc.Domain.Quantity;

namespace Abc.Facade.Technician
{
    public static class UnitViewFactory
    {
        public static Unit Create(UnitView v)
        {
            var d = new UnitData();
            Copy.Members(v, d);

                return new Unit(d);
            
        }

        public static UnitView Create(Unit o)
        {
            var v = new UnitView();
            if(!(o?.Data is null))
                Copy.Members(o.Data, v);

            return v;
        }
    }
}

