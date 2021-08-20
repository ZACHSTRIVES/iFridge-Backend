using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iFridge_Backend.GraphQL.Users
{
        public record EditUserInput(
        string UserId,
        string? Name,
        string? GitHub,
        string? ImageURI);
    
}
