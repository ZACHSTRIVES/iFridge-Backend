using System;

namespace iFridge_Backend.GraphQL.Foods
{
    public record AddFoodInput
    (
        String FridgeID,
        String Name,
        String OriginQTY,
        String CurrentQTY,
        String Type,
        DateTime ExpireDate,
        String Notes
        );
}
