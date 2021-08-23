using iFridge_Backend.Models;

namespace iFridge_Backend.GraphQL.Users
{
    public record LoginPayload
    (
        User User,
        string Jwt

        );
}
