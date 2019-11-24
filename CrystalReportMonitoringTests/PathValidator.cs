using NUnit.Framework;
using CrystalReportMonitoring;

namespace CrystalReportMonitoringTests
{
    internal sealed class PathValidatorTests
    {        
        [TestCase(@"C:\Users\Admin\Downloads", true)]
        [TestCase(@"C:\Users\Admin\github", true)]

        [TestCase("", false)]
        [TestCase(@"C:\Users\Admin\.nuget", false)]


        public void CreateAndWriteFile(string defaultValue, bool expectedResult)
        {
            // Arrange
            var rule = new Engine();

            // Act
            var result = rule.ValidatePath(null);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}