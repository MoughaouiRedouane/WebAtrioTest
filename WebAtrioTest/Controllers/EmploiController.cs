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
    public class EmploiController : Controller
    {
        private readonly IMediator _mediator;
        public EmploiController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> GetEmploisByDate([FromHeader] int idPersonne, [FromHeader] DateTime dateDebut, [FromHeader] DateTime dateFin)
        {
            var response = await _mediator.Send(new GetEmploisEntreDateOfPersonne.Command(idPersonne, dateDebut, dateFin));
            var emplois = response.Emplois;
            return Json(new { emplois });
        }

        [HttpGet]
        public async Task<IActionResult> AddEmploiToPerson([FromHeader] int idPersonne, [FromHeader] Emploi emploi)
        {
            var response = await _mediator.Send(new AjouterEmploiAPersonne.Command(idPersonne,emploi));
            var personne = response.personne;
            return Json(new { personne });
        }

    }
}
