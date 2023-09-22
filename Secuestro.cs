using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SecuestroBienes.Interfaces;       
using SecuestroBienes.Models.DataContext;
using System;

namespace SecuestroBienes
{
    public class Secuestro
    {
        private readonly IUnitOfWork _unitOfWork;

        public Secuestro(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [FunctionName("Secuestro")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            try
            {   
                var result = await _unitOfWork._secuestroBienRepository.ObtenerTodos();
                return new OkObjectResult(result);
            } catch(Exception e)
            {
                return new BadRequestObjectResult(e);
            }
            
        }
    }
}
