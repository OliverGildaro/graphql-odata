using GraphQL.Types;
using Repository.Models;

namespace GraphQLPOC.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            this.Name = "authorType";
            this.Field(e => e.Id, type: typeof(IdGraphType));
            this.Field(e => e.Name);
            this.Field(e => e.LastName);
            this.Field<ListGraphType<BookType>>("books");
        }
    }
}
