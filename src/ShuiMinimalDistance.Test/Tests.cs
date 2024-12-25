using System;
using Xunit;

namespace ShuiMinimalDistance.Test
{
    public class Tests
    {
        [Fact]
        public void FindMinDistanceToVertice_Test()
        {
            var graph = Program.Graph;

            int source1 = 0;
            int destination1 = 9;

            int source2 = 1;
            int destination2 = 8;

            double result1 = Program.FindMinDistanceToVertex(graph, source1, destination1);
            double result2 = Program.FindMinDistanceToVertex(graph, source2, destination2);

            double expected1 = 4.81;
            double expected2 = 3.27;
            int precision = 2;

            Assert.Equal(expected1, result1, precision);
            Assert.Equal(expected2, result2, precision);
        }

        [Fact]
        public void ParseAndValidateInput_Test()
        {
            var inputSource1 = "test";
            var inputDestination1 = "test2";

            var inputSource2 = "test";
            var inputDestination2 = "1";

            var inputSource3 = "1";
            var inputDestination3 = "test";

            var inputSource4 = "0";
            var inputDestination4 = "11";

            var inputSource5 = "1";
            var inputDestination5 = "11";

            var inputSource6 = "0";
            var inputDestination6 = "10";

            var inputSource7 = "1";
            var inputDestination7 = "10";

            Assert.False(Program.ParseAndValidateInput(inputSource1, inputDestination1, out _, out _));
            Assert.False(Program.ParseAndValidateInput(inputSource2, inputDestination2, out _, out _));
            Assert.False(Program.ParseAndValidateInput(inputSource3, inputDestination3, out _, out _));
            Assert.False(Program.ParseAndValidateInput(inputSource4, inputDestination4, out _, out _));
            Assert.False(Program.ParseAndValidateInput(inputSource5, inputDestination5, out _, out _));
            Assert.False(Program.ParseAndValidateInput(inputSource6, inputDestination6, out _, out _));

            var result7 = Program.ParseAndValidateInput(inputSource7, inputDestination7, out int source7, out int destination7);
            Assert.True(result7 && source7 == 1 && destination7 == 10);
        }
    }
}
