using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.PlanViewModel;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Classes
{
    internal class PlanService : IPlanService
    {
        private readonly IUniteOfWork _uniteOfWork;
        PlanService(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }
        public IEnumerable<PlanViewModel> GetAllPlans()
        {
            var Plans = _uniteOfWork.GetRepository<Plan>().GetAll();
            if(Plans == null||!Plans.Any())
                return Enumerable.Empty<PlanViewModel>();

            return Plans.Select(X => new PlanViewModel()
            {
                Description = X.Description,
                DurationDays = X.DurationDays,
                Id = X.Id,
                IsActive = X.IsActive,
                Name = X.Name,
                Price = X.Price,
            });
        }

        public PlanViewModel? GetPlanDetails(int planId)
        {
            var Plan = _uniteOfWork.GetRepository<Plan>().GetById(planId);
            if (Plan == null) return null;

            return new PlanViewModel()
            {
                Description = Plan.Description,
                DurationDays = Plan.DurationDays,
                Id = planId,
                IsActive = Plan.IsActive,
                Name = Plan.Name,
                Price = Plan.Price,
            };
        }

        public UpdatePlanViewModel? GetPlanToUpdate(int planId)
        {
            var Plan = _uniteOfWork.GetRepository<Plan>().GetById(planId);
            if (Plan is null || Plan.IsActive == false || HasActiveMemberShips(planId)) return null;
            return new UpdatePlanViewModel()
            {
                Description = Plan.Description,
                DurationDays = Plan.DurationDays,
                Name = Plan.Name,
                Price = Plan.Price,
            };
            
        }

        public bool ToggleStatus(int planId)
        {
            try
            {
                var Plan = _uniteOfWork.GetRepository<Plan>().GetById(planId);
                if (Plan is null || Plan.IsActive == false || HasActiveMemberShips(planId)) return false;

                Plan.IsActive = !Plan.IsActive;
                _uniteOfWork.GetRepository<Plan>().Update(Plan);
                return _uniteOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool UpdatePlan(int planId, UpdatePlanViewModel updatedplan)
        {
            try
            {
                var Plan = _uniteOfWork.GetRepository<Plan>().GetById(planId);
                if (Plan is null || Plan.IsActive == false || HasActiveMemberShips(planId)) return false;

                (Plan.Description, Plan.DurationDays, Plan.Price, Plan.UpdatedAt) = (updatedplan.Description, updatedplan.DurationDays, updatedplan.Price, DateTime.Now);

                _uniteOfWork.GetRepository<Plan>().Update(Plan);
                return _uniteOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region healper methods
        private bool HasActiveMemberShips(int planId)
        {
            return _uniteOfWork.GetRepository<MemberShip>().GetAll(X=> X.PlanId==planId && X.Status=="Active").Any();
        }
        #endregion
    }
}
