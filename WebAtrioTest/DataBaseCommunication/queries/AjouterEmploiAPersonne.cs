using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using WebAtrioTest.DataBaseCommunication.Model;
using System.Threading.Tasks;
using System.Linq;

namespace WebAtrioTest.DataBaseCommunication.queries
{
    public class AjouterEmploiAPersonne 
    {
        public record Command(int idPersonne,Emploi emploi) : IRequest<Response>;
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly MyDbContext _dbCtx;
            public Handler(MyDbContext myDbContext)
            {
                _dbCtx = myDbContext;
            }


            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var personne = await _dbCtx.Personnes.FindAsync(request.emploi);
                if (personne == null)
                {
                    return new Response(null);
                }

                request.emploi.PersonneId = request.idPersonne;
                _dbCtx.Emplois.Add(request.emploi);
                await _dbCtx.SaveChangesAsync();

                return new Response(personne);

            }
        }

        public record Response(Personne personne);
    }
}
