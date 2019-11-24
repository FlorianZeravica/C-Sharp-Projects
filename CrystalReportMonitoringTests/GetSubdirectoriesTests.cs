using NUnit.Framework;
using CrystalReportMonitoring;
using System.Collections.Generic;
using System.Linq;

namespace CrystalReportMonitoringTests
{
    internal sealed class GetSubdirectoriesTests
    {
        [TestCase(".")]
        public void GetSubdirectories(string defaultValue)
        {
            // Arrange
            var rule = new Engine();
                        
            // Act
            List<string> result = new List<string>();
            result.AddRange(rule.GetSubdirectories(defaultValue));
            
            Assert.GreaterOrEqual(result.Count, 1);         
        }

        [TestCase(".")]
        public void TestExcludingDirectory(string defaultValue)
        {
            // Arrange
            var rule = new Engine();

            // create dummy
            string testFolderPath = string.Format(".\\{0}", Engine.ExcludingDirectory);
            System.IO.Directory.CreateDirectory(testFolderPath);

            // Act
            List<string> result = new List<string>();
            result.AddRange(rule.GetSubdirectories(defaultValue));

            Assert.That(result.Where(item => item.Contains(Engine.ExcludingDirectory)).Count() <= 0);

            System.IO.Directory.Delete(".\\{0}");
        }
    }
}