namespace Cafe.Domain.Shared
{
    public enum TableStatusEnum : byte
    {
        Available = 1,
        Occupied = 2,
        Reserved = 3,
        NeedsCleaning = 4
    }
}
