using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SmallestThingThatWillWork
{
    public class Tests
    {
        [Test]
        public void A_failing_test()
        {
            Assert.Fail("I'm failing.. oh nose!");
        }

        [Test]
        public void A_passing_test()
        {
            Assert.Pass("Weeee");
        }

        [Test]
        public void A_warning_test()
        {
            Assume.That(false, "Warning..");
        }
    }
}
