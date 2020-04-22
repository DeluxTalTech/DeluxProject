using Abc.Aids;
using Abc.Data.Service;
using Abc.Domain.Quantity;

namespace Abc.Facade.Service
{
    public static class MeasureTermViewFactory 
    {
        public static MeasureTerm Create(MeasureTermView view)
        {
            var d = new MeasureTermData();
            Copy.Members(view, d);
            return new MeasureTerm(d);
        }

        public static MeasureTermView Create(MeasureTerm obj)
        {
            var v = new MeasureTermView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
