using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAtrioTest.DataBaseCommunication.Model;

namespace WebAtrioTest.DataBaseCommunication.queries
{
    public class GetPersonnesByEntreprise
    {
        public record Command(string entrepriseName) : IRequest<Response>;
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly MyDbContext _dbCtx;
            public Handler(MyDbContext myDbContext)
            {
                _dbCtx = myDbContext;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var personnes = await _dbCtx.Personnes
                .Join(_dbCtx.Emplois,
                    personne => personne.Id,
                    emploi => emploi.PersonneId,
                    (personne, emploi) => new { Personne = personne, Emploi = emploi })
                .Where(x => x.Emploi.NomEntreprise == request.entrepriseName)
                .OrderBy(x => x.Personne.Nom)
                .Select(x => x.Personne)
                .ToListAsync(cancellationToken);


                return new Response(personnes);
            }
        }

        public record Response(List<Personne> Personnes);
    }
}
