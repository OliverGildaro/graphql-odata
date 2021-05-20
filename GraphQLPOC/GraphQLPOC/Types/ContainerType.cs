using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;

namespace GraphQLPOC.Types
{
    public abstract class ContainerType : ObjectGraphType
    {
        public ContainerType(string name, params ObjectGraphType[] elements)
        {
            this.Name = name;
            elements.Apply(element => this.AddFields(element.Fields));
        }

        private void AddFields(IEnumerable<FieldType> fields)
        {
            fields.Apply(field => this.AddField(field));
        }
    }
}
