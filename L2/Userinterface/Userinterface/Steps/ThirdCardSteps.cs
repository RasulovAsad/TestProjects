using NUnit.Framework;
using Userinterface.Forms;

namespace Userinterface.Steps
{
    public static class ThirdCardSteps
    {
        private static readonly ThirdCardForm thirdCard = new ThirdCardForm();

        public static void ThirdCardIsPresent()
        {
            Assert.IsTrue(thirdCard.State.WaitForDisplayed(), "Third card should be presented");
        }
    }
}
