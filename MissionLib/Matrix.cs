using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("MissionLib.Test")]
namespace MissionLib
{
    class Matrix
    {
        public static int[,] CropMatrix(int[,] matrix, int excludedValue)
        {
            int left = 0, right = matrix.GetLength(1), top = 0, bottom = matrix.GetLength(0);
            
            while(left < right)
            {
                bool passed = false;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, left] != excludedValue)
                    {
                        passed = true;
                        break;
                    }
                }
                if (passed)
                    break;

                left++;
            }
            right--;
            while (right > left)
            {
                bool passed = false;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, right] != excludedValue)
                    {
                        passed = true;
                        break;
                    }
                }
                if (passed)
                    break;

                right--;
            }
            while (top < bottom)
            {
                bool passed = false;
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[top, i] != excludedValue)
                    {
                        passed = true;
                        break;
                    }
                }
                if (passed)
                    break;

                top++;
            }
            bottom--;
            while (bottom > top)
            {
                bool passed = false;
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[bottom, i] != excludedValue)
                    {
                        passed = true;
                        break;
                    }
                }
                if (passed)
                    break;

                bottom--;
            }

            if (left <= right && top <= bottom)
            {
                int width = right - left + 1;
                int height = bottom - top + 1;
                int[,] result = new int[height, width];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        result[i, j] = matrix[top + i, left + j];
                    }
                }
                return result;
            } else
            {
                return null;
            }
        }
    }
}
