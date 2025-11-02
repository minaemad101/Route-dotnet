using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.MemberViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentPL.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Index()
        {
            var members = _memberService.GetAllMembers();
            return View(members);
        }
        public IActionResult MemberDetails(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id of Member cant be less than 1";
                return RedirectToAction(nameof(Index));
            }

            var member = _memberService.GetMemberDetails(id);
            if (member == null)
            {
                TempData["ErrorMessage"] = "Member not found";
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        public IActionResult HealthRecordDitails(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id of Health Record cant be less than 1";
                return RedirectToAction(nameof(Index));
            }

            var HealthRecord = _memberService.GetMemberHealthRecordDetails(id);
            if (HealthRecord == null)
            {
                TempData["ErrorMessage"] = "Health Record not found";
                return RedirectToAction(nameof(Index));
            }
            return View(HealthRecord);

        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMember(CreateMemberViewModel createMember)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataInvalid", "Re-enter Invalid Data");
                return View(nameof(Create),createMember);
            }
            bool Result = _memberService.CreateMember(createMember);
            if (Result) 
            {
                TempData["SuccessMessage"] = "Member Created Successfully";
            }
            else
            {
                TempData["SuccessMessage"] = "Member Not Created";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
