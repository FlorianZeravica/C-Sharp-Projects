using NUnit.Framework;
using FileMonitoringTool;

namespace FileMonitoringTests
{
    internal sealed class PathValidatorTests
    {
        [TestCase(@"C:\User\Admin\Directory", true)]

        [TestCase("", false)]
        [TestCase(@"\User\Admin\Directory", false)]


        public void CreateAndWriteFile(string defaultValue, bool expectedResult)
        {
            // Arrange
            var rule = new Engine();

            //public bool CreateAndWriteFile(string filePath, string logfileName, string fileNameExtension, List<string> FileInformation)
            // Act
            var result = rule.ValidatePath(null);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}