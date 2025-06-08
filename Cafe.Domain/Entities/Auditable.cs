namespace Cafe.Domain
{
    public class Auditable<T> where T : struct
    {
        public T CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public T ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
