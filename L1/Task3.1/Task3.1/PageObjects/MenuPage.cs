using OpenQA.Selenium;
using Serilog;
using Task3._1.Framework.Models;
using Task3._1.Framework.Models.Base;
using Task3._1.PageObjects.MenuForms;

namespace Task3._1.PageObjects
{
    public class MenuPage : BaseForm
    {
        private Label _alerts = new Label(By.XPath("//span[@class='text' and text()='Alerts']"), "alertsLink");
        private Label _frames = new Label(By.XPath("//span[@class='text' and text()='Frames']"), "framesLink");
        private Label _nestedFrames = new Label(By.XPath("//span[@class='text' and text()='Nested Frames']"), "framesLink");
        private Label _browserWindows = new Label(By.XPath("//span[@class='text' and text()='Browser Windows']"), "browserWindowsLink");
        private Label _elements = new Label(By.XPath("//div[@class='header-text' and text()='Elements']"), "elementsLink");
        private Label _links = new Label(By.XPath("//span[@class='text' and text()='Links']"), "linksLink");
        private Label _webTables = new Label(By.XPath("//span[@class='text' and text()='Web Tables']"), "tablesLink");

        //Does this count as "Composition principle should be used to work form on pages"?
        private AlertsForm _alertsForm = new AlertsForm(By.XPath("//div[@id='javascriptAlertsWrapper']"), "Alerts Form");
        private NestedFramesForm _nestedFramesForm = new NestedFramesForm(By.XPath("//div[@id='framesWrapper']"), "Nested Frames form");
        private FramesForm _framesForm = new FramesForm(By.XPath("//div[@id='framesWrapper']"), "Frames form");
        private WebTablesForm _webTablesForm = new WebTablesForm(By.XPath("//div[@class='web-tables-wrapper']"), "Tables form");
        private BrowserWindowsForm _browserWindowsForm = new BrowserWindowsForm(By.XPath("//div[@id='browserWindows']"), "Browser windows");
        private LinksForm _linksForm = new LinksForm(By.XPath("//div[@id='linkWrapper']"), "Links");

        public MenuPage(By locator, string name) : base(locator, name) { }

        public AlertsForm Alerts()
        {
            return _alertsForm;
        }

        public NestedFramesForm NestedFrames()
        {
            return _nestedFramesForm;
        }

        public FramesForm Frames()
        {
            return _framesForm;
        }

        public WebTablesForm WebTables()
        {
            return _webTablesForm;
        }

        public BrowserWindowsForm BrowserWindows()
        {
            return _browserWindowsForm;
        }

        public LinksForm Links()
        {
            return _linksForm;
        }

        public void SelectAlertsMenu()
        {
            Log.Information("User selected Alerts menu");
            _alerts.ScrollToElement();
            _alerts.Click();
        }

        public void SelectElementsMenu()
        {
            Log.Information("User selected Elements menu");
            _elements.ScrollToElement();
            _elements.Click();
        }

        public void SelectNestedFramesMenu()
        {
            Log.Information("User selected Nested frames menu");
            _nestedFrames.ScrollToElement();
            _nestedFrames.Click();
        }

        public void SelectFramesMenu()
        {   
            Log.Information("User selected Frames menu");
            _frames.ScrollToElement();
            _frames.Click();
        }

        public void SelectWebTablesMenu()
        {
            Log.Information("User selected Web tables menu");
            _webTables.ScrollToElement();
            _webTables.Click();
        }

        public void SelectLinksMenu()
        {
            Log.Information("User selected Links menu");
            _links.ScrollToElement();
            _links.Click();
        }

        public void SelectBrowserWindowsMenu()
        {
            Log.Information("User selected Browser windows menu");
            _browserWindows.ScrollToElement();
            _browserWindows.Click();
        }
    }
}
