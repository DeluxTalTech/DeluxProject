namespace Abc.Data.Common
{
    public abstract class CommonTermData : PeriodData
    {
        public string MasterId { get; set; }
        public string TermId { get; set; }
        public int Power { get; set; }
    }
}
