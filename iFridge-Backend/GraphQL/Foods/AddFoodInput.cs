using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iFridge_Backend.GraphQL.Foods
{
    public record AddFoodInput
    (
        String FridgeID,
        String OriginQTY,
        String CurrentQTY,
        String Type,
        DateTime ExpireDate,
        String Notes
        );
}
