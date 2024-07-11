using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAtrioTest.DataBaseCommunication.Model;

namespace WebAtrioTest.DataBaseCommunication.queries
{
    public class GetAllpersonnes
    {
        public record Command() : IRequest<Response>;


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
                    .Include(p => p.Emplois)
                    .OrderBy(p => p.Nom)
                    .Select(p => new Personne
                    {
                        Nom = p.Nom,
                        Prenom = p.Prenom,
                        Age = CalculateAge(p.DateDeNaissance),
                        Emplois = p.Emplois.Select(e => new Emploi
                        {
                            Id = e.Id,
                            NomEntreprise = e.NomEntreprise,
                           
                        }).ToList()
                    })
                    .ToListAsync(cancellationToken);

                return new Response(personnes);
            }

            private static int CalculateAge(DateTime? dateDeNaissance)
            {
                var today = DateTime.Today;
                var age = today.Year - dateDeNaissance.Value.Year;
                if (dateDeNaissance.Value.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        public record Response(List<Personne> Personnes);
    }
}
