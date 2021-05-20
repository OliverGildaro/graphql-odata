using GraphQL.Types;
using Repository.Models;

namespace GraphQLPOC.Types
{
    public class BookInputType : InputObjectGraphType<Book>
    {
        public BookInputType()
        {
            this.Name = "bookInputType";
            this.Field(e => e.Title);
            this.Field(e => e.Price);
        }
    }
}
