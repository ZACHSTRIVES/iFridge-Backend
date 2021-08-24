namespace iFridge_Backend.GraphQL.Users
{
    public record EditUserInput(
        string UserId,
        string? Name,
        string? GitHub,
        string? ImageURI);

}
