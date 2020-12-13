using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StarDriver.domain.core.Business.DevPlans;
using StarDriver.domain.core.Contracts;

namespace StarDriver.application.core.DevPlanServices
{
    public class CreateDevPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CreateDevPlanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public CreateDevPlanResponse Run(CreateDevPlanRequest request)
        {
            var devPlan = request.Map();

            var mainTheme = _unitOfWork.MainThemeRepository.Find(request.IdMainTheme);

            if (mainTheme == null)
            {
                return new CreateDevPlanResponse() {Message = "El tema principal ingresado no se encuentra registrado."};
            }

            devPlan.MainThemes.Add(mainTheme);

            _unitOfWork.DevPlanRepository.Add(devPlan);
            _unitOfWork.Commit();
            return new CreateDevPlanResponse() {Message = "El plan de desarrollo fue creado con exito."};
            
        }
        
    }
    
    public class CreateDevPlanRequest
    {
        [Required(ErrorMessage = "Es necesario el Nivel del plan de desarrollo.")]
        public string Level { get; set; }

        [Required(ErrorMessage = "Es necesaria la id del tema principal para el plan de desarrollo.")]
        public int IdMainTheme { get; set; }

        public DevelopmentPlan Map()
        { 
            return new DevelopmentPlan(){Level = Level};
        }
            
    }
    
    public class CreateDevPlanResponse
    {
        public string Message { get; set; }
    }
}