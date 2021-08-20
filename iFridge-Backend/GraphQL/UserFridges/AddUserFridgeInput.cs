using System;


namespace iFridge_Backend.GraphQL.UserFridges
{
    public record AddUserFridgeInput
    (
        String UserId,
        String FridgeId

    );
}
