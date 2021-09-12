using CQRS2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS2.Database
{
    public class Repository
    {
        public List<Todo> ToDoList { get; } = new List<Todo>() 
        { 
            new Todo {Id =1 , IsCompleted = true, Name = "First" },
            new Todo {Id =2 , IsCompleted = true, Name = "Sirst" },
            new Todo {Id =3 , IsCompleted = true, Name = "SDirst" },
            new Todo {Id =4 , IsCompleted = true, Name = "Asdasdrst" },
            new Todo {Id =5 , IsCompleted = false, Name = "assdasdast" },

        };
    }
}
