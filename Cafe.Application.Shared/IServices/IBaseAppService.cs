namespace Cafe.Application.Shared.IServices
{
    public interface IBaseAppService<TCreateAppDto, TUpdateAppDto, ResAppDto>
        where TCreateAppDto : class
        where TUpdateAppDto : class
        where ResAppDto : class
    {
        Task<ResAppDto> GetAsync(Guid id);
        Task<List<ResAppDto>> GetAsyncAll(); //as return is readonly , not need add/remove(collection) or indexing(list)
        Task<ResAppDto> CreateAsync(TCreateAppDto requestDto);
        Task<ResAppDto> UpdateAsync(TUpdateAppDto requestDto);
        Task<ResAppDto> DeleteAsync(Guid id);


    }
}
