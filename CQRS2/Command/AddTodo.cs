using CQRS2.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS2.Command
{
    public static class AddTodo
    {
        // Command 
        public record Command(string name ) : IRequest<Response>;

        //Handler
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly Repository _repository ;
            public Handler(Repository repository)
            {
                _repository = repository;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                _repository.ToDoList.Add(new Domain.Todo
                {
                    Id = 25,
                    IsCompleted = false,
                    Name = request.name
                }) ;

                return new Response(25, request.name, false);
            }
        }

        // Response

        public record Response(int id , string name , bool isComplete);
    }
}
