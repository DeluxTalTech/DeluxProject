using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abc.Facade.Common;

namespace Abc.Facade.Service
{
    public sealed class UnitTermView : CommonTermView
    {
        [Required]
        [DisplayName("Unit")]
        public string MasterId { get; set; }

        public string GetId()
        {
            return $"{MasterId}.{TermId}";
        }
    }
}
