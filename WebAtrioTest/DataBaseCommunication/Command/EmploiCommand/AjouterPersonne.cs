using Azure;
using MediatR;
using System;
using WebAtrioTest.DataBaseCommunication.Model;

namespace WebAtrioTest.DataBaseCommunication.Command.EmploiCommand
{
    public class AjouterPersonne
    {
        public record Command(Personne personne) : IRequest<Response>;

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly MyDbContext _dbCtx;
            public Handler(MyDbContext myDbContext)
            {
                _dbCtx = myDbContext;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                _dbCtx.Personnes.Add(request.personne);
                await _dbCtx.SaveChangesAsync();
                return new Response(request.personne);
            }
        }

        public record Response(Personne personne);
    }
}
