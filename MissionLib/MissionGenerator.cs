using System;
using System.Collections.Generic;
using System.Linq;

namespace MissionLib
{
    public class MissionGenerator : IMissionGenerator
    {
        private enum Direction
        {
            FORWARD,
            BACKWARD
        }

        private const int MaxRotor = 12;
        private List<string[][]> layouts;

        public MissionGenerator()
        {
            generateLayouts();
        }

        public MissionInfo Generate(int numTick, int numRotor, int numRelation, int numMove)
        {
            if (numTick > 12)
                throw new ArgumentException("Maximum number of ticks are 12");

            if (numRotor > MaxRotor)
                throw new ArgumentException($"Maximum number of rotors are {MaxRotor}");

            if (numRelation > (numRotor * (numRotor - 1)))
                throw new ArgumentException("Number of Relations must no exceed numRotor * (numRotor - 1)");

            var exceptions = new HashSet<int>(Enumerable.Range(0, numRotor).Select(x => x * (numRotor + 1)));
            var relationPools = Enumerable.Range(0, numRotor * numRotor).Where(x => !exceptions.Contains(x)).ToArray();
            shuffle(relationPools);

            var relations = relationPools.Take(numRelation).Concat(exceptions).ToArray();
            var relationTable = createRelationTable(relations, numRotor);

            int[] moves;
            int[] currentState;
            int maxRetry = 0;

            while (true)
            {
                moves = createRandomArray(numMove, numRotor);
                currentState = Enumerable.Repeat(0, numRotor).ToArray();
                simulate(currentState, moves, relationTable, numTick, Direction.BACKWARD);

                if (currentState.Any(x => x != 0))
                    break;
                else
                    maxRetry++;

                if (maxRetry == 2)
                {
                    numMove--;
                    maxRetry = 0;
                }
            }

            var rotors = createRotorObjects(relationTable, currentState, numRotor);
            return new MissionInfo()
            {
                NumberOfTick = numTick,
                Answer = moves.Reverse().ToList(),
                Rotors = rotors,
                Layout = layouts[numRotor - 1]
            };
        }

        public bool CheckAnswer(MissionInfo mission, int[] moveToCheck)
        {
            var rotors = mission.Rotors;
            var currentState = new int[rotors.Count];
            var relationTable = new bool[rotors.Count, rotors.Count];
            for (var i = 0; i < rotors.Count; i++)
            {
                currentState[i] = rotors[i].CurrentState;
                foreach (var a in rotors[i].AffectTo)
                {
                    relationTable[i, a] = true;
                }
            }

            simulate(currentState, moveToCheck, relationTable, mission.NumberOfTick, Direction.FORWARD);

            return currentState.All(x => x == 0);
        }

        private void simulate(int[] currentState, int[] moves, bool[,] relationTable, int numTick, Direction direction)
        {
            foreach (var m in moves)
            {
                for (int i = 0; i < currentState.Length; i++)
                {
                    if (relationTable[m, i])
                    {
                        if (direction == Direction.BACKWARD)
                        {
                            if (currentState[i] == 0)
                                currentState[i] = numTick;

                            currentState[i]--;
                        }
                        else
                        {
                            currentState[i] = (currentState[i] + 1) % numTick;
                        }
                    }
                }
            }
        }

        private List<Rotor> createRotorObjects(bool [,] relationTable, int[] currentState, int numRotor)
        {
            var rotors = new List<Rotor>();
            for (int i = 0; i < numRotor; i++){
                var affects = new List<int>();
                for (int j = 0; j < numRotor; j++)
                {
                    if (relationTable[i, j])
                        affects.Add(j);
                }
                rotors.Add(new Rotor()
                {
                    Id = RID(i),
                    CurrentState = currentState[i],
                    AffectTo = affects
                });
            }
            return rotors;
        }

        private bool[,] createRelationTable(int[] relations, int numRotor)
        {
            bool[,] table = new bool[numRotor, numRotor];
            foreach(int x in relations)
            {
                table[x / numRotor, x % numRotor] = true;
            }
            return table;
        }

        private int[] createRandomArray(int length, int maxValue)
        {
            var items = new int[length];
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
                items[i] = rnd.Next(maxValue);

            return items;
        }

        private void shuffle<T>(T[] items)
        {
            int n = items.Length * 2;
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                var a = rnd.Next(items.Length);
                var b = rnd.Next(items.Length);

                T temp = items[a];
                items[a] = items[b];
                items[b] = temp;
            }
        }

        private void generateLayouts()
        {
            int maxGridX = 3;
            int maxGridY = 5;
            layouts = new List<string[][]>();

            for (int i = 0; i < Constant.Layouts.Length; i++)
            {
                var grid = newGrid(maxGridY, maxGridX);
                for (int j = 0; j < Constant.Layouts[i].Length; j++)
                {
                    var pos = Constant.Layouts[i][j].Split(',').Select(x => Convert.ToInt32(x)).ToList();
                    grid[pos[0], pos[1]] = j;
                }
                var cropped = Matrix.CropMatrix(grid, -1);

                var numRow = cropped.GetLength(0);
                var numCol = cropped.GetLength(1);

                var layout = new string[numRow][];

                for (int a = 0; a < numRow; a++)
                {
                    layout[a] = new string[numCol];
                    for (int b = 0; b < numCol; b++)
                    {
                        if (cropped[a, b] != -1)
                        {
                            layout[a][b] = RID(cropped[a, b]);
                        }
                        else
                        {
                            layout[a][b] = null;
                        }
                    }
                }
                layouts.Add(layout);
            }
        }

        private int[,] newGrid(int numRow, int numCol)
        {
            int[,] grid = new int[numRow, numCol];
            for (int i = 0; i < numRow; i++)
            {
                for (int j = 0; j < numCol; j++)
                {
                    grid[i, j] = -1;
                }
            }
            return grid;
        }

        private string RID(int id)
        {
            return $"R{(id + 1).ToString("D2")}";
        }
    }
}
