using NUnit.Framework;

namespace PairsOfIntegers
{
    public class Tests
    {
        [Test]
        [TestCase("1,9,5,0,20,-4,12,16,7 12")]
        [TestCase("-8,-2,4,7,3,11,17,6,-4,-5 9")]
        [TestCase("-8,78,6,8,-79,1,0,31,7,-1 -1")]
        [TestCase("4,0,-6,-14,12,-16,7,6,-2 17")]
        public void Should_Pass_AllTestCases(string input)
        {
            //Arrange
            var line = input.Split(" ");
            var target = int.Parse(line[1]);
            var list = new List<int>(line[0].Split(",").Select(x => int.Parse(x)));
            var matches = new List<int>();
            foreach (var value in list)
            {
                var targetValue = target - value;
                if (!matches.Contains(value) && list.Contains(targetValue))
                    matches.AddRange(new[] { value, targetValue });
            }

            //Act
            var result = Function.FindPairsOfIntegers(input);

            //Assert
            var values = result.Any() ? string.Join(",", result)?.Split(",").Select(x => int.Parse(x)).ToList() : new List<int>();
            foreach (var value in matches)
            {
                if (values.Contains(value)) values.Remove(value);
            };
            Assert.That(values.Count, Is.EqualTo(0));
        }
    }
}
