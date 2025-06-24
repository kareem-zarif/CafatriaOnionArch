using AutoMapper;
using Cafe.Application.Shared.DTOS.Request;
using Cafe.Application.Shared.IServices;
using Cafe.UI.WEB.MVC2.ViewModels.Request.Branch;
using Cafe.UI.WEB.MVC2.ViewModels.Response.Branch;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.UI.WEB.MVC2.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchAppService _branchService;
        private readonly IMapper _mapper;

        public BranchController(IBranchAppService branchService, IMapper mapper)
        {
            _branchService = branchService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var allBranches = await _branchService.GetAsyncAll();
            var mapped = _mapper.Map<List<BranchResVM>>(allBranches);
            return View(mapped);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        //[ActionName("CreateBranch")]
        public async Task<IActionResult> Create(BranchCreateVM requestVM)
        {
            if (!ModelState.IsValid)
                return View(requestVM);

            var mappedGo = _mapper.Map<BranchCreateAppDto>(requestVM);
            var created = await _branchService.CreateAsync(mappedGo);
            var mappedCome = _mapper.Map<BranchResVM>(created);

            return RedirectToAction(nameof(Index));
        }

    }
}
