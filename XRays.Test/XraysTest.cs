using System;
using System.Threading.Tasks;

using NUnit.Framework;

namespace XRays.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static async Task<string> Throwable(bool shouldThrow)
        {
            await Task.Yield(); //no-op to give the compiler a real async method
            if (shouldThrow)
            {
                throw new Exception("A Not So Nice Error Message");
            }
            return "Some Really Cool Data";
        }

        [Test]
        public async Task PassingFunctionReturnsData()
        {
            var ( data, error ) = await Throwable(false).X();
            Assert.AreEqual(data, "Some Really Cool Data");
            Assert.Null(error);
        }

        [Test]
        public async Task FailingFunctionReturnsError()
        {
            var (data, error) = await Throwable(true).X();
            Assert.Null(data);
            Assert.NotNull(error);
            Assert.AreEqual(error.Message, "A Not So Nice Error Message");
        }
    }
}