using NUnit.Framework;

namespace RPGHexplorer.Test
{
    public class BaseFixture
    {
        [SetUp]
        public void BaseSetup()
        {
            SetUp();
        }

        protected virtual void SetUp()
        {
            
        }
    }
}