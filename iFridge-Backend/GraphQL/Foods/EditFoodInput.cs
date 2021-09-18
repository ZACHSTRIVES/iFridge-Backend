using System;

namespace iFridge_Backend.GraphQL.Foods
{
    public record EditFoodInput
    (
        String FoodID,
        String Name,
        String FridgeID,
        String? OriginQTY,
        String? CurrentQTY,
        String? Type,
        DateTime? ExpireDate,
        String? Notes
    );
}
