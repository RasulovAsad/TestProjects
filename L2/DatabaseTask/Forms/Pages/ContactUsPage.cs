using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace DatabaseTask.Forms.Pages
{
    public class ContactUsPage : Form
    {
        public ContactUsPage() : base(By.XPath("//body[contains(@class,'page-template-page-contacts')]"), "Contact us page") { }

        public bool PageIsPresent => State.IsDisplayed;
    }
}
