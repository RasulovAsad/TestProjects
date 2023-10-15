using OpenQA.Selenium;
using Serilog;
using Task3._1.Framework.Driver;
using Task3._1.Framework.Models;
using Task3._1.Framework.Models.Base;

namespace Task3._1.PageObjects.MenuForms
{
    public class WebTablesForm : BaseForm
    {
        private Button _add = new Button(By.XPath("//button[@id='addNewRecordButton']"), "Add button");

        private RegistrationForm _registrationForm = new RegistrationForm(By.XPath("//div[@class='modal-content']"), "Registration form");

        public WebTablesForm(By locator, string name) : base(locator, name) { }

        public RegistrationForm RegistrationForm()
        {
            return _registrationForm;
        }

        public void ClickAdd()
        {
            Log.Information("User clicked Add button");
            _add.ScrollToElement();
            _add.Click();
        }

        public bool UserExistsInTable(string name)
        {
            try
            {
                var gridCell = new Label(By.XPath($"//div[@role='gridcell' and text()='{name}']"), "Grid cell");
                return gridCell.IsDisplayed();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int GetUsersCount()
        {
            int count = 0;

            for (int i = 1; i < 10; i++)
            {
                try
                {
                    var element = Browser.GetDriver().FindElement(By.XPath($"//span[@id='delete-record-{i}']"));
                    count++;
                }
                catch (Exception)
                {
                    break;
                }
            }
            return count;
        }

        public void DeleteUser(int id)
        {
            Log.Information("User clicked Delete button");
            var element = Browser.GetDriver().FindElement(By.XPath($"//span[@id='delete-record-{id}']"));
            element.Click();
        }
    }
}
