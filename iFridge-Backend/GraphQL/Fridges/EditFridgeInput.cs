using System;

namespace iFridge_Backend.GraphQL.Fridges
{
    public record EditFridgeInput
     (
        String FridgeId,
        String Name

        );
}
