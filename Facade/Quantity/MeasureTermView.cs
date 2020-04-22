using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abc.Facade.Common;

namespace Abc.Facade.Quantity
{
    public sealed class MeasureTermView : CommonTermView
    {
        [Required]
        [DisplayName("Measure")]
        public string MasterId { get; set; }

        public string GetId()
        {
            return $"{MasterId}.{TermId}";
        }
    }
}
