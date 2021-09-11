using System;

namespace iFridge_Backend.GraphQL.UserFridges
{
    public record RemoveFridgemateInput
    (
       
        String FridgeId,
        String UserId

    );
}
