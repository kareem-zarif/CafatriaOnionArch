namespace Cafe.Domain
{
    public class Auditable<T> where T : struct //for make generic Class used in any project :: but if all Application Use Guid => can do without that Generic T and use Guid directly
    {
        public T CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        //= DateTime.Now; //as it set once when creating the object , not saving in database .  ModifiedOn will NOT change automatically.
        public T ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        //= DateTime.Now;
    }
}
