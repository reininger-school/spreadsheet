// Reid Reininger
// 11512839
namespace Cpts321
{
    using NUnit.Framework;

    /// <summary>
    /// Test suite for CommnadManager.
    /// </summary>
    [TestFixture]
    public class TestCommandManager
    {
        private CommandManager manager;

        /// <summary>
        /// Create fresh instanct of CommandManager for each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.manager = new CommandManager();
        }
    }
}
