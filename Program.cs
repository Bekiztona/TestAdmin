using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TestAdmin
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://opensource.demo.orangehrmlive.com/index.php/auth/login");
            driver.Manage().Window.Maximize();
            IWebElement inputUser = driver.FindElement(By.Id("txtUsername"));
            inputUser.SendKeys("Admin");
            IWebElement inputPass = driver.FindElement(By.Id("txtPassword"));
            inputPass.SendKeys("admin");
            driver.FindElement(By.Id("btnLogin")).Click();
            driver.FindElement(By.XPath("//a[@id='menu_pim_viewPimModule']/b")).Click();
            driver.FindElement(By.Id("menu_pim_addEmployee")).Click();
            IWebElement inputFirstName = driver.FindElement(By.Id("firstName"));
            inputFirstName.SendKeys("Purple");
            IWebElement inputMiddleName = driver.FindElement(By.Id("middleName"));
            inputMiddleName.SendKeys("Hrm");
            IWebElement inputLastName = driver.FindElement(By.Id("lastName"));
            inputLastName.SendKeys("Automation");
            driver.FindElement(By.Id("btnSave")).Click();
            driver.FindElement(By.Id("menu_pim_viewEmployeeList")).Click();
            IWebElement searchEmployee = driver.FindElement(By.Id("empsearch_employee_name_empName"));
            searchEmployee.SendKeys("Purple Hrm Automation");

            var table = driver.FindElement(By.XPath("//table[@id='resultTable']/tbody"));
            var rows = table.FindElements(By.TagName("tr"));
            bool isPresentInTable;
            foreach (var row in rows)
            {
                
                if (row.Text.Contains("Purple Hrm"))
                {
                    isPresentInTable = true;
                    Console.WriteLine($"Row found {isPresentInTable}");
                    break;
                }
            }
            Console.ReadLine();
            driver.Close();
        }

    }
}

