using GraphQL.Types;
using Repository.Models;

namespace GraphQLPOC.Types
{
    public class AuthorInputType : InputObjectGraphType<Author>
    {
        public AuthorInputType()
        {
            this.Name = "authorInputType";
            this.Field(e => e.Name);
            this.Field(e => e.LastName);
            this.Field<ListGraphType<BookInputType>>("books");
        }
    }
}
