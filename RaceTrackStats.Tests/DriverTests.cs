using RaceTrackStats;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RaceTrackStats.Tests
{
    public class Tests
    {
        [Test]
        public void WhenTenResultsAdded_ShouldReturnPoints()
        {
            //Testing if gratified positions are scored correctly
            var driver = new DriverInMemory("John", "Doe", 1);
            for(int i = 1; i <= 10; i++)
            {
                driver.AddResult(i);
            }
            var stats = driver.GetStatistics();
            var result = stats.Points;

            Assert.AreEqual(101, result);
        }

        [Test]
        public void WhenEightResultsAdded_ShouldReturnAvgPosition()
        {
            var driver = new DriverInMemory("John", "Doe", 1);
            for (int i = 1; i <= 20; i+=3)
            {
                driver.AddResult(i);
            }
            //DNF should be added to results in driver but shouldnt be taken into account when calculating avg position
            driver.AddResult("DNF");

            var stats = driver.GetStatistics();
            var result = stats.AvaregePosition;

            Assert.AreEqual(10, result);
        }

        [Test]
        public void WhenEightResultsAdded_ShouldReturnAvgPoints()
        {
            var driver = new DriverInMemory("John", "Doe", 1);
            for (int i = 1; i <= 20; i += 3)
            {
                driver.AddResult(i);
            }
            //Adding 20 to make nicer control number
            driver.AddResult("20");

            var stats = driver.GetStatistics();
            var result = stats.AvaregePoints;

            Assert.AreEqual(5.5, result);
        }

        [Test]
        public void WhenFourResultsAdded_ShouldReturnBestOne()
        {
            var driver = new DriverInMemory("John", "Doe", 1);
            driver.AddResult(5);
            driver.AddResult(3);
            driver.AddResult(4);
            driver.AddResult(5);

            var stats = driver.GetStatistics();
            var result = stats.BestResult;

            Assert.AreEqual(3, result);
        }

        [Test]
        public void WhenFourResultsAdded_ShouldReturnWorstOne()
        {
            var driver = new DriverInMemory("John", "Doe", 1);
            driver.AddResult(5);
            driver.AddResult(3);
            driver.AddResult(4);
            driver.AddResult(5);

            var stats = driver.GetStatistics();
            var result = stats.WorstResult;

            Assert.AreEqual(5, result);
        }


    }
}
