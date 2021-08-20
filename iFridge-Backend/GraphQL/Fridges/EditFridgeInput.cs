using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iFridge_Backend.GraphQL.Fridges
{
    public record EditFridgeInput
     (  
        String FridgeId,
        String Name

        );
}
