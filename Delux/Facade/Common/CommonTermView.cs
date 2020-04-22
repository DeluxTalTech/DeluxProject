using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Abc.Facade.Common
{
    public abstract class CommonTermView : PeriodView
    {
        [Required]
        [DisplayName ("Term")]
        public string TermId { get; set; }
        public int Power { get; set; }
    }
}