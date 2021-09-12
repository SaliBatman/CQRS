using CQRS2.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS2.Query
{
    public static class GetTodoListById
    {
        //query 
        public record Query (int id ) : IRequest<Response>;

        //handler

        public class Handler : IRequestHandler<Query, Response>
{
            private readonly Repository _toDoItem;
            public Handler(Repository toDoItem)
            {
                _toDoItem = toDoItem;
            }
            public  async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {

                var model = _toDoItem.ToDoList.FirstOrDefault(s => s.Id == request.id);

                return new Response(model.Id, model.Name, model.IsCompleted);
             
            }
        }


        //response
        public record Response(int id , string name , bool isCompleted);

    }
}
