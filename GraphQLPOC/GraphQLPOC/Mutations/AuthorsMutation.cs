using GraphQL;
using GraphQL.Types;
using GraphQLPOC.Types;
using Repository;
using Repository.Models;
using System;

namespace GraphQLPOC.Mutations
{
    public class AuthorsMutation : ObjectGraphType
    {
        public AuthorsMutation(AuthorsRepository authorsRepository)
        {
            this.Name = "authorsMutation";

            this.FieldAsync<AuthorType>(
                this.Name = "createAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AuthorInputType>> { Name="author"}),
                resolve: async context =>
                {
                    var @author = context.GetArgument<Author>("author");
                    var result = await authorsRepository.CreateAuthor(@author);
                    return result;
                });
        }
    }
}
