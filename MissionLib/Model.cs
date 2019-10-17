using System;
using System.Collections.Generic;
using System.Text;

namespace MissionLib
{
    public class MissionInfo
    {
        public int NumberOfTick { get; set; }
        public List<int> Answer { get; set; }
        public List<Rotor> Rotors { get; set; }
        public string[][] Layout { get; set; }
    }

    public class Rotor
    {
        public string Id { get; set; }
        public int CurrentState { get; set; }
        public List<int> AffectTo { get; set; }
    }
}
