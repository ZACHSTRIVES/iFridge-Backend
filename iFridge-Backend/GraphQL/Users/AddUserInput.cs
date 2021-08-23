namespace iFridge_Backend.GraphQL.Users
{
    public record AddUserInput(
        string Name,
        string GitHub,
        string? ImageURI);
}
