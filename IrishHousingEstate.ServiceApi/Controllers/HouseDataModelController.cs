using IrishHousingEstate.ModelApp.DataRepository;
using IrishHousingEstate.ModelApp.Models;
using IrishHousingEstate.ModelApp.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrishHousingEstate.ServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseDataModelController : ControllerBase
    {
        private readonly ILogger<HouseDataModelController> logger;
        private readonly IHouseDataRepository houseDataRepository;

        public HouseDataModelController(ILogger<HouseDataModelController> logger, IHouseDataRepository houseDataRepository)
        {
            this.logger = logger;
            this.houseDataRepository = houseDataRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] HouseData houseData)
        {
            var crud = this.houseDataRepository.AddRecord(houseData);
            return CreatedAtAction(nameof(Get), new { id = houseData.Id}, houseData);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var crud = this.houseDataRepository.GetAllRecords();
            return new OkObjectResult(crud);
        }

        [HttpGet, Route("{Id}")]
        public IActionResult Get(int id)
        {        
            var crud = this.houseDataRepository.GetRecordById(id);

            if (crud == null)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(crud);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.houseDataRepository.DeleteRecord(id);

            return new OkResult();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] HouseData houseData)
        {
            if(houseData != null)
            {
                this.houseDataRepository.UpdateRecord(houseData);
                return new OkResult();
            }

            return new NoContentResult();
        }
    }
}
