using GraphQLPOC.Types;
namespace GraphQLPOC.Mutations
{
    public class MutationContainer : ContainerType
    {
        public MutationContainer(
                              AuthorsMutation authorsMutation,
                              BooksMutation booksMutation)
            : base("Mutation", authorsMutation, booksMutation)
        {
        }
    }
}
