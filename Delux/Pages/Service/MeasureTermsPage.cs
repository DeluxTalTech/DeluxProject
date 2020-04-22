﻿using System.Collections.Generic;
using Abc.Data.Service;
using Abc.Data.Technician;
using Abc.Domain.Quantity;
using Abc.Facade.Service;
using Abc.Pages.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Service
{
    public class MeasureTermsPage : CommonPage<IMeasureTermsRepository, MeasureTerm, MeasureTermView, MeasureTermData>
    {
        public IEnumerable<SelectListItem> Measures { get; }
        protected internal MeasureTermsPage(IMeasureTermsRepository r, IMeasuresRepository m) : base(r)
        {
            PageTitle = "Teenused";
            Measures = createSelectList<Measure, MeasureData>(m);
        }

        public override string ItemId
        {
            get
            {
                if (Item is null) return string.Empty;
                return $"{Item.MasterId}.{Item.TermId}";
            }
        }

        protected internal override string getPageUrl() => "/Quantity/MeasureTerms";

        protected internal override MeasureTerm toObject(MeasureTermView view)
        {
            return MeasureTermViewFactory.Create(view);
        }

        protected internal override MeasureTermView toView(MeasureTerm obj)
        {
            return MeasureTermViewFactory.Create(obj);
        }

        public string GetMeasureName(string measureId)
        {
            foreach (var m in Measures)
                if (m.Value == measureId)
                    return m.Text;
            return "Unspecified";
        }

        protected internal override string getPageSubTitle()
        {
            return FixedValue is null
                ? base.getPageSubTitle()
                : $"For {GetMeasureName(FixedValue)}";
        }
    }
}
