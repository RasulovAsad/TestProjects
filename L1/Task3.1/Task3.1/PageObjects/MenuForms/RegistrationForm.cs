using OpenQA.Selenium;
using Serilog;
using Task3._1.Framework.Models;
using Task3._1.Framework.Models.Base;
using Task3._1.Models;

namespace Task3._1.PageObjects.MenuForms
{
    public class RegistrationForm : BaseForm
    {
        public TextBox FirstNameInput = new TextBox(By.XPath("//input[@id='firstName']"), "First Name input");
        public TextBox LastNameInput = new TextBox(By.XPath("//input[@id='lastName']"), "Last Name input");
        public TextBox EmailInput = new TextBox(By.XPath("//input[@id='userEmail']"), "Email input");
        public TextBox AgeInput = new TextBox(By.XPath("//input[@id='age']"), "Age input");
        public TextBox SalaryInput = new TextBox(By.XPath("//input[@id='salary']"), "Salary input");
        public TextBox DepartmentInput = new TextBox(By.XPath("//input[@id='department']"), "Departmnet input");

        public Button Submit = new Button(By.XPath("//button[@id='submit']"), "Submit button");

        public RegistrationForm(By locator, string name) : base(locator, name) { }

        public void AddUser(User user)
        {
            Log.Information("User filled data in registration form");
            FirstNameInput.Click();
            FirstNameInput.SendText(user.FirstName);
            LastNameInput.SendText(user.LastName);
            EmailInput.SendText(user.Email);
            AgeInput.SendText(user.Age.ToString());
            SalaryInput.SendText(user.Salary.ToString());
            DepartmentInput.SendText(user.Department);

            Log.Information("User clicked Submit button");
            Submit.Click();
        }
    }
}
