using iFridge_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iFridge_Backend.GraphQL.Users
{
    public record LoginPayload
    (
        User User,
        string Jwt

        );
}
