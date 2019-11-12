// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
