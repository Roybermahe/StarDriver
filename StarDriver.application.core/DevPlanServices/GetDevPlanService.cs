using System.Collections.Generic;
using System.Linq;
using StarDriver.domain.core.Business.DevPlans;
using StarDriver.domain.core.Contracts;

namespace StarDriver.application.core.DevPlanServices
{
    public class GetDevPlanService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        
        public GetDevPlanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public GetDevPlanResponse Run()
        {
            var list = _unitOfWork.DevPlanRepository.GetAll().ToArray();
            return !list.Any() ?
                new GetDevPlanResponse("No se encontro ningun plan de desarrollo.") : 
                new GetDevPlanResponse($"Se encontraron {list.Count()} planes de desarrollo.", list);
        }

        public GetDevPlanResponse Run(int id)
        {
            var devPlan = _unitOfWork.DevPlanRepository.Find(id);
            return devPlan == null
                ? new GetDevPlanResponse("no se encontro el plan de desarrollo")
                : new GetDevPlanResponse($"El plan de desarrollo {devPlan.Level} fue encontrado.", null, devPlan);

        }
        
    }
    
    public class GetDevPlanResponse
    {
        public  string Message { get; }
        public DevelopmentPlan DevelopmentPlan { get; }
        public IEnumerable<DevelopmentPlan> DevelopmentPlanList { get; }
        
        public GetDevPlanResponse(string message, IEnumerable<DevelopmentPlan> developmentPlanList = null, DevelopmentPlan developmentPlan = null)
        {
            Message = message;
            DevelopmentPlan = developmentPlan;
            DevelopmentPlanList = developmentPlanList;
        }
    }
}