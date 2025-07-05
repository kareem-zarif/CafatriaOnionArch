namespace Cafe.Application.Services
{
    public abstract class BaseAppService<TEntity, TCreateAppDto, TUpdateAppDto, TResponseAppDto> : IBaseAppService<TCreateAppDto, TUpdateAppDto, TResponseAppDto>
        where TEntity : BaseEnt<Guid>
        where TCreateAppDto : class
        where TUpdateAppDto : class
        where TResponseAppDto : class
    {
        protected readonly IUnitOfWork _unitOfWork; //As Applicaton Layer Call Infra Diectly
        protected readonly IMapper _mapper;
        protected abstract IBaseRepo<TEntity, Guid> _baseRepo { get; } //abstract to foerce any devired class to tell me which repo
        //can not inject _baseRepo instead of  _unitOfWork as i lose transictional Complete which prevent me from update many tables in same service =>ex: student and StudentCourse must change when student leave coursw
        //can not inject both _unitOfWork and _baseRepo as i will have 2 instances of repo (one by UOW and other by BaseRepo) 
        protected BaseAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual async Task<TResponseAppDto> GetAsync(Guid id)
        {
            var foundEnt = await _baseRepo.GetAsync(id);
            var mappedResponse = _mapper.Map<TResponseAppDto>(foundEnt);
            return mappedResponse;
        }

        public virtual async Task<List<TResponseAppDto>> GetAsyncAll()
        {
            var foundEnts = await _baseRepo.GetAsyncAll();
            var MappedResponses = _mapper.Map<List<TResponseAppDto>>(foundEnts);
            return MappedResponses;
        }

        public virtual async Task<TResponseAppDto> CreateAsync(TCreateAppDto requestDto)
        {
            var entity = _mapper.Map<TEntity>(requestDto);
            var created = await _baseRepo.CreateAsync(entity);
            int saved = await _unitOfWork.Complete();
            if (saved > 0)
            {
                var mappedResponse = _mapper.Map<TResponseAppDto>(created);
                return mappedResponse;
            }
            else
                throw new Exception("error occured when saving changes in DB");
        }

        public virtual async Task<TResponseAppDto> UpdateAsync(TUpdateAppDto requestDto)
        {
            var entity = _mapper.Map<TEntity>(requestDto);
            var updated = await _baseRepo.UpdateAsync(entity);
            int saved = await _unitOfWork.Complete();
            if (saved > 0)
                return _mapper.Map<TResponseAppDto>(updated);

            throw new Exception("error occured when saving changes in DB");
        }

        public virtual async Task<TResponseAppDto> DeleteAsync(Guid id)
        {
            var deleted = await _baseRepo.DeleteAsync(id);
            var saved = await _unitOfWork.Complete();
            if (saved > 0)
                return _mapper.Map<TResponseAppDto>(deleted);

            throw new Exception("error occured when saving changes in DB");
        }

    }
}
