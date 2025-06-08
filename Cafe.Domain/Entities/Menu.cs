namespace Cafe.Domain
{
    public class Menu : BaseEnt<Guid>
    {
        public string MenuName { get; set; }
        //nav
        public virtual ICollection<Product> Products { get; set; }
    }
}
