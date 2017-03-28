using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class wcfQueueTest
    {
        [Test]
        public void PositiveTest()
        {
            bool retVal = true;
            Assert.AreEqual(retVal, true);
        }

        [Test]
        public void NegativeTest()
        {
            bool retVal = true;
            Assert.AreEqual(retVal, false);
        }

    }
}
