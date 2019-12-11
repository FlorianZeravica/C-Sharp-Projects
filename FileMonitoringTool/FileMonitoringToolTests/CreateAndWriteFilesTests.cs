using NUnit.Framework;
using FileMonitoringTool;

namespace FileMonitoringTests
{
    internal sealed class FileWriterTests
    {
        [TestCase("FileMonitoringFile", "", false)]
        [TestCase("", "FileMonitoringFile1", false)]
        [TestCase("FileMonitoringFile", "FileMonitoringFile2", true)]
        [TestCase("FileMonitoringFile", "FileMonitoringFile3", false)]
        [TestCase("FileMonitoringFile1", "FileMonitoringFile2", false)]
        [TestCase("FileMonitoringFile1", "FileMonitoringFile4", false)]

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