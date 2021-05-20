using GraphQL.Types;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLPOC.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            this.Name = "bookType";
            this.Field(e => e.Id, type: typeof(IdGraphType));
            this.Field(e => e.AuthorId, type: typeof(IdGraphType));
            this.Field(e => e.Title);
            this.Field(e => e.Price);
        }
    }
}
