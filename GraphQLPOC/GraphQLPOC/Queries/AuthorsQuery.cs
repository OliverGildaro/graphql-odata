using GraphQL.Types;
using GraphQLPOC.Types;
using Repository;
using Repository.Models;
using System.Linq;

namespace GraphQLPOC.Queries
{
    public class AuthorsQuery : ObjectGraphType
    {
        public AuthorsQuery(AuthorsRepository authorsRepository)
        {
            this.Name = "authorQuery";

            this.FieldAsync<ListGraphType<AuthorType>>(
                this.Name = "authors",
                resolve: async context =>
                {
                    return await authorsRepository.FindAuthors();
                });
        }
    }
}
