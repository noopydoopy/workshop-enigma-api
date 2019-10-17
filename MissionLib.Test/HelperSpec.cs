using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MissionLib.Test
{
    public class HelperSpec
    {
        [Fact]
        public void testcase_1()
        {
            int[,] x = {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 1, 2, 0, 0 },
                { 0, 3, 4, 5, 0 },
                { 0, 0, 0, 0, 0 },
            };

            var result = Matrix.CropMatrix(x, 0);
            Assert.Equal(new int[2, 3] { { 1, 2, 0 }, { 3, 4, 5 } }, result);
        }

        [Fact]
        public void testcase_2()
        {
            int[,] x = {
                { 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
            };

            var result = Matrix.CropMatrix(x, 0);
            Assert.Equal(new int[1, 1] { { 1 } }, result);
        }

        [Fact]
        public void testcase_3()
        {
            int[,] x = {
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
            };

            var result = Matrix.CropMatrix(x, 0);
            Assert.Equal(new int[1, 1] { { 1 } }, result);
        }

        [Fact]
        public void testcase_4()
        {
            int[,] x = {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0 },
            };

            var result = Matrix.CropMatrix(x, 0);
            Assert.Equal(new int[1, 1] { { 1 } }, result);
        }

        [Fact]
        public void testcase_5()
        {
            int[,] x = {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1 },
            };

            var result = Matrix.CropMatrix(x, 0);
            Assert.Equal(new int[1, 1] { { 1 } }, result);
        }

        [Fact]
        public void testcase_6()
        {
            int[,] x = {
                { 0, 1, 2, 3, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
            };

            var result = Matrix.CropMatrix(x, 0);
            Assert.Equal(new int[1, 3] { { 1, 2, 3 } }, result);
        }

        [Fact]
        public void testcase_7()
        {
            int[,] x = {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 1, 2, 3, 0 },
            };

            var result = Matrix.CropMatrix(x, 0);
            Assert.Equal(new int[1, 3] { { 1, 2, 3 } }, result);
        }

        [Fact]
        public void testcase_8()
        {
            int[,] x = {
                { 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0 },
                { 2, 0, 0, 0, 0 },
                { 3, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
            };

            var result = Matrix.CropMatrix(x, 0);
            Assert.Equal(new int[3, 1] { { 1 }, { 2 }, { 3 } }, result);
        }

        [Fact]
        public void testcase_9()
        {
            int[,] x = {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 2 },
                { 0, 0, 0, 0, 3 },
                { 0, 0, 0, 0, 0 },
            };

            var result = Matrix.CropMatrix(x, 0);
            Assert.Equal(new int[3, 1] { { 1 }, { 2 }, { 3 } }, result);
        }

        [Fact]
        public void testcase_10()
        {
            int[,] x = {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
            };

            var result = Matrix.CropMatrix(x, 0);
            Assert.Null(result);
        }

        [Fact]
        public void testcase_11()
        {
            int[,] x = {
                { 1, 0, 0, 0, 2 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 3, 0, 0, 0, 4 },
            };

            int[,] y = {
                { 1, 0, 0, 0, 2 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 3, 0, 0, 0, 4 },
            };

            var result = Matrix.CropMatrix(x, 0);
            Assert.Equal(y, result);
        }
    }
}
