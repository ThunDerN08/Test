using System.Linq;
using webappmssql.Data;
using webappmssql.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webappmssql.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class GadgetsController: ControllerBase
    {
        private readonly MyWorldDBContext _myWorldDBContext;

        public GadgetsController(MyWorldDBContext myWorldDBContext)
        {
            _myWorldDBContext = myWorldDBContext;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllGadgets()
        {
            var allGadgets = _myWorldDBContext.Gadgets.ToList();
            return Ok(allGadgets);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult CreateGadget(Gadgets gadgets)
        {
            _myWorldDBContext.Gadgets.Add(gadgets);
            _myWorldDBContext.SaveChanges();
            return Ok(gadgets.Id);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateGadget(Gadgets gadgets)
        {
            _myWorldDBContext.Update(gadgets);
            _myWorldDBContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteGAdget(int id)
        {
            var gadgetToDelete = _myWorldDBContext.Gadgets.Where(_ => _.Id == id).FirstOrDefault();
            if (gadgetToDelete == null)
            {
                return NotFound();
            }

            _myWorldDBContext.Gadgets.Remove(gadgetToDelete);
            _myWorldDBContext.SaveChanges();
            return NoContent();
        }
    }

}