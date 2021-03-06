﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abc.Domain.Quantity;
using Abc.Pages.Technician;

namespace Abc.Soft.Areas.Quantity.Pages.Units
{
    public class EditModel : UnitsPage
    {
        public EditModel(IUnitsRepository r, IMeasuresRepository m,
            IUnitTermsRepository t, IUnitFactorsRepository f) : base(r, m, t, f) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            if (id == null) return NotFound();

            await getObject(id, fixedFilter, fixedValue);
            if (Item == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            await updateObject(fixedFilter, fixedValue);
            return Redirect(PageUrl);
        }
    }
}
