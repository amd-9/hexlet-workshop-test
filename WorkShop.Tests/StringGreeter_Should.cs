using NUnit.Framework;
using System;
using WorkShop.Lib;

namespace WorkShop.Tests
{
    [TestFixture]
    public class StringGreeter_Should
    {
        private readonly StringGreeter _stringGreeter;

        public StringGreeter_Should()
        {
            _stringGreeter = new StringGreeter();
        }

        [Test]
        public void ReturnReturnHelloString()
        {
            var result = _stringGreeter.SayHello();

            Assert.AreEqual(result, "Hello, World!");
        }
    }
}
