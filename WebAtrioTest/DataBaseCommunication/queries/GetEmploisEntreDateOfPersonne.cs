using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAtrioTest.DataBaseCommunication.Model;

namespace WebAtrioTest.DataBaseCommunication.queries
{
    public class GetEmploisEntreDateOfPersonne
    {
        public record Command(int personneId, DateTime dateDebut, DateTime dateFin) : IRequest<Response>;

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly MyDbContext _dbCtx;
            public Handler(MyDbContext myDbContext)
            {
                _dbCtx = myDbContext;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var emplois = await _dbCtx.Emplois
                .Where(e => e.PersonneId == request.personneId &&
                            e.DateDebut >= request.dateDebut && e.DateDebut <= request.dateFin)
                .OrderBy(e => e.DateDebut)
                .ToListAsync(cancellationToken);

                return new Response(emplois);
            }
        }
        public record Response(List<Emploi> Emplois);
    }
}
