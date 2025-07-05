namespace Cafe.Domain
{
    public class BaseEnt<T> : Auditable<T> where T : struct
    {
        public T Id { get; set; }
        //bool is Active {get;set;} // for soft delete
    }
}
