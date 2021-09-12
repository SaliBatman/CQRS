using CQRS2.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS2.Query
{
    public static class GetTodoListByName
    {


        //query 
        public record Query(string name) : IRequest<Response>;

        // handler

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly Repository _repository;
            public Handler(Repository repository)
            {
                _repository = repository;
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {

                var response = _repository.ToDoList.FirstOrDefault(s => s.Name.Contains(request.name));
                return new Response(response.Id, response.Name, response.IsCompleted);
            }
        }

        //response
        public record Response(int id, string name, bool isComplete);

    }
}
