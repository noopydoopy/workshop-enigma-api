using System;
using System.Collections.Generic;
using System.Text;

namespace MissionLib
{
    public interface IMissionGenerator
    {
        MissionInfo Generate(int numTick, int numRotor, int numRelation, int numMove);
    }
}
