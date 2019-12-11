using NUnit.Framework;
using FileMonitoringTool;

namespace FileMonitoringToolTests
{
    internal sealed class FileWriterTests
    {
        [TestCase("CrystalReportsMonitoringFile", "", false)]
        [TestCase("", "CrystalReportsMonitoringFile1", false)]
        [TestCase("CrystalReportsMonitoringFile", "CrystalReportsMonitoringFile2", true)]
        [TestCase("CrystalReportsMonitoringFile", "CrystalReportsMonitoringFile3", false)]
        [TestCase("CrystalReportsMonitoringFile1", "CrystalReportsMonitoringFile2", false)]
        [TestCase("CrystalReportsMonitoringFile1", "CrystalReportsMonitoringFile4", false)]

        public void CreateAndWriteFile(string defaultValue, string comparingValue, bool expectedResult)
        {
            // Arrange
            var rule = new FileWriter();

            // Act
            var result = rule.CreateAndWriteFile(null, defaultValue, comparingValue, null);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}