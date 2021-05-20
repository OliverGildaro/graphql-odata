using GraphQL.Types;
using GraphQL.Utilities;
using GraphQLPOC.Mutations;
using GraphQLPOC.Queries;
using GraphQLPOC.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLPOC.Schemas
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
            : base(provider)
        {
            this.Query = provider.GetRequiredService<AuthorsQuery>();
            this.Mutation = provider.GetRequiredService<MutationContainer>();
            this.RegisterTypes(typeof(AuthorType), typeof(BookType));
        }
    }
}
