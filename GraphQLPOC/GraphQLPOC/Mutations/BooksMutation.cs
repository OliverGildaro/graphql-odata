using GraphQL;
using GraphQL.Types;
using GraphQLPOC.Types;
using Repository;
using Repository.Models;
using System;

namespace GraphQLPOC.Mutations
{
    public class BooksMutation : ObjectGraphType
    {
        public BooksMutation(AplicationContext aplicationContext)
        {
            this.Name = "booksMutation";

            this.Field<BookType>(
                this.Name = "createBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }),
                resolve: context =>
                {
                    var @book = context.GetArgument<Book>("book");
                    @book.Id = Guid.NewGuid().ToString();
                    var result = aplicationContext.Add(@book).Entity;
                    aplicationContext.SaveChanges();
                    return result;
                });
        }
    }
}
