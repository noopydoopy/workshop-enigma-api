using System;
using Xunit;

namespace MissionLib.Test
{
    public class MissionGeneratorSpec
    {
        [Fact]
        public void can_generate_mission()
        {
            var sut = new MissionGenerator();
            var result = sut.Generate(3, 4, 7, 5);
            Assert.Equal(5, result.Answer.Count);
            Assert.Equal(4, result.Rotors.Count);
            Assert.True(sut.CheckAnswer(result, result.Answer.ToArray()));
        }

        [Fact]
        public void can_generate_at_maximum()
        {
            var sut = new MissionGenerator();
            var result = sut.Generate(12, 12, 132, 10);
            Assert.Equal(10, result.Answer.Count);
            Assert.Equal(12, result.Rotors.Count);
            Assert.True(result.Rotors.TrueForAll(x => x.CurrentState == 2));
            Assert.True(sut.CheckAnswer(result, result.Answer.ToArray()));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void can_generate_at_small(int sublevel)
        {
            var level = 1;
            var difficulty = ((level - 1) * 5 + sublevel) + 1;
            var numTick = level + 1;
            var numRotor = sublevel + 1;
            var numMove = Math.Max(4, difficulty / 3);
            var numRelation = Math.Max(numRotor - 1, Convert.ToInt32(Math.Floor(numRotor * (numRotor - 1) * Math.Min(1.0, (double)difficulty / 25) * 0.6)));

            var sut = new MissionGenerator();
            var result = sut.Generate(numTick, numRotor, numRelation, numMove);
            Assert.True(sut.CheckAnswer(result, result.Answer.ToArray()));
        }
    }
}
