using NUnit.Framework;
using FileMonitoringTool;

namespace FileMonitoringToolTests
{
    internal sealed class PathValidatorTests
    {
        [TestCase(@"C:\_Code\R17\diva4\Solutions\DivaWeb", true)]
        [TestCase(@"\\mv100\Ablage\Entwicklung\DIVA\DIVA4\Betriebsstatistik\Vorlagen(Crystal Reports)", true)]

        [TestCase("", false)]
        [TestCase(@"C:\_Code\R17\diva4\Solut", false)]


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
