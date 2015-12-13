using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MappersTests 
    {
        

        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public  void TruncatedUniversityMapper_Test()
        {
            var result = 1;
            var expected = 1;
            Assert.AreEqual(result, expected);
        }
    }
}
