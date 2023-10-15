using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Userinterface.Forms
{
    public class ThirdCardForm : Form
    {
        public ThirdCardForm() : base(By.XPath("//div[contains(@class,'personal-details')]"), "Third card")
        {
                
        }
    }
}
