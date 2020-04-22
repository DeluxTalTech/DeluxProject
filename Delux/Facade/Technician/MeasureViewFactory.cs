using Abc.Aids;
using Abc.Data.Technician;
using Abc.Domain.Quantity;

namespace Abc.Facade.Technician
{
    public static class MeasureViewFactory
    {
        public static Measure Create(MeasureView v)
        {
            var d = new MeasureData();
            Copy.Members(v, d);
            
            return new Measure(d);
        }

        public static MeasureView Create(Measure o)
        {
            var v = new MeasureView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);
            return v;
        } 
    }
}
