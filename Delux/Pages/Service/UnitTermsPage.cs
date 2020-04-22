using System.Collections.Generic;
using Abc.Data.Service;
using Abc.Data.Technician;
using Abc.Domain.Quantity;
using Abc.Facade.Service;
using Abc.Pages.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Service
{
    public class UnitTermsPage : CommonPage<IUnitTermsRepository, UnitTerm, UnitTermView, UnitTermData>
    {
        public IEnumerable<SelectListItem> Units { get; }

        protected internal UnitTermsPage(IUnitTermsRepository r, IUnitsRepository u) : base(r)
        {
            PageTitle = "Unit Terms";
            Units = createSelectList<Unit, UnitData>(u);
        }

        public override string ItemId
        {
            get
            {
                if (Item is null) return string.Empty;
                return $"{Item.MasterId}.{Item.TermId}";
            }
        }

        protected internal override string getPageUrl() => "/Quantity/UnitTerms";

        protected internal override UnitTerm toObject(UnitTermView view)
        {
            return UnitTermViewFactory.Create(view);
        }

        protected internal override UnitTermView toView(UnitTerm obj)
        {
            return UnitTermViewFactory.Create(obj);
        }

    }
}
