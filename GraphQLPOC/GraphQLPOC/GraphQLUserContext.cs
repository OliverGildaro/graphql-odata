namespace GraphQLPOC
{
    using System.Collections.Generic;
    using System.Security.Claims;

    public class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
