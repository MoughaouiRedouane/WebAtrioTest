using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAtrioTest.DataBaseCommunication.Command.EmploiCommand;
using WebAtrioTest.DataBaseCommunication.Model;
using WebAtrioTest.DataBaseCommunication.queries;

namespace WebAtrioTest.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    [EnableCors("AllowSpecificOrigin")]
    public class PersonneController : Controller
    {
        private readonly IMediator _mediator;

        public PersonneController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] Personne person)
        {
            var response = await _mediator.Send(new AjouterPersonne.Command(person));
            var personne = response.personne;
            return Json(new { personne });
        }

        [HttpGet]
        public async Task<IActionResult> GetListPersons()
        {
            var persons = new List<Personne>();
            try
            {
                var response = await _mediator.Send(new GetAllpersonnes.Command());
                persons = response.Personnes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
            return Json(new { persons });
        }

        [HttpGet]
        public async Task<IActionResult> GetListPersonsByWork([FromHeader] string entrepriseName)
        {
            var response = await _mediator.Send(new GetPersonnesByEntreprise.Command(emploiId));
            var persons = response.Personnes;
            return Json(new { persons });
        }

    }
}
