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
            var foundList = await _branchService.GetAsyncAll();
            var mapped = _mapper.Map<List<BranchResVM>>(foundList);
            return View(mapped);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        #region ValidateAntiForgeryToken protects form CSRF
        //1-Apllied to POST actions that modify data (like Create, Edit, Delete).
        //When a form is rendered, an anti-forgery token is generated and included in the form as a hidden field. When the form is submitted, the token is sent back to the server
        //Protect from Cross-Site Request Forgery(CSRF) by checking that the token is valid and matches the user's session.
        //If you use the Razor <form asp-action="Create"> tag helper, the anti-forgery token is included automatically.
        //

        #endregion
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
