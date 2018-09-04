using OpenQA.Selenium;
using System;
using static LandsWa.Acceptance.Smoke.Tests.Helper.Enumerations;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Reflection;

namespace LandsWa.Acceptance.Smoke.Tests.Pages
{
    public class RequestDetailsMileStone : BasePage
    {
        protected override By IsPageLoadedBy => By.XPath("//a[text()='Request Details']/span[text()='Current Step']");
        private IWebDriver _driver;
        protected string staticPageElement = "//h2[contains(text(), 'Request Details')]";
        protected string continueButton = "//button[text()='Continue']";
        protected string genrealRequestType = "//label[text()='General Crown land request']";
        protected string LgaType = "//label[text()='Crown land request from Local Government, Management Body or State Government Agency']";
        protected string EventType = "//label[text()='Crown land request from Local Government, Management Body or State Government Agency']";
        protected string crownLandRequestType = "//label[text()='Crown land request from Local Government, Management Body or State Government Agency']";
        protected string eventRequestRequestType = "//label[text()='Request for access to Crown land for an event']";
        protected string categoryDropdown = "//div[text()='Select one item...']";
        protected string descriptionTextArea = "//textarea";
        protected string CLEFRequestCheckbox = "//label[text()=' Request received on a CLEF']";
        protected string signedCheckbox = "//label[text()='Signed by Applicant']";
        protected string positionTextBox = "//label[text()='Position']/../../div[2]//input";
        protected string dateReceived = "//label[text()='Date Received']/../../div[2]//input";
        protected string dateSigned = "//label[text()='Date Signed']/../../div[2]//input";
        protected string uploadButton = "//button[text()='Upload']";
        protected string uploadField = "//input[@class='MultipleFileUploadWidget---ui-inaccessible']";
        // Event Request Type Inputs
        protected string eventFromDate = "//span[text()='From']/../../div[2]//input[contains(@class,'DatePickerWidget')]";
        protected string eventFromTime = "//span[text()='From']/../../div[2]//input[contains(@class,'TimeWidget')]";
        protected string eventToDate = "//span[text()='To']/../../div[2]//input[contains(@class,'DatePickerWidget')]";
        protected string eventToTime = "//span[text()='To']/../../div[2]//input[contains(@class,'TimeWidget')]";
        protected string eventPurpose = "//textarea";
        protected string eventLandSize = "//label[text()='Approximate size of the land area required for the event']/../../div[2]/div/input";
        protected string eventUploadLayoutDocument = "(//input[@class='MultipleFileUploadWidget---ui-inaccessible'])[1]";
        protected string eventExternalStructuresYes = "//input[@value='Yes']";
        protected string eventExternalStructuresNo = "//input[@value='No']";
        protected string eventVisitors = "//*[contains(text(),'Visitor')]/../../td[2]/div/input";
        protected string eventEmployees = "//*[contains(text(),'Employees')]/../../td[2]/div/input";
        protected string eventArtists = "//*[contains(text(),'Artists')]/../../td[2]/div/input";
        protected string eventRevenue = "//*[contains(text(),'Revenue')]/../../td[2]/div/input";
        protected string eventGrants = "//*[contains(text(),'Grants')]/../../td[2]/div/input";
        protected string eventExpenditure = "//*[contains(text(),'Expenditure')]/../../td[2]/div/input";
        protected string eventApplicationDateReceived = "//label[text()='Date Received']/../../div[2]//input[contains(@class,'DatePickerWidget')]";
        protected string eventUploadApplicantsRequest = "(//input[@class='MultipleFileUploadWidget---ui-inaccessible'])[3]";
        protected string eventUploadGrantDocument = "(//input[@class='MultipleFileUploadWidget---ui-inaccessible'])[2]";

        protected string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
        protected string errorMessage = "//*[contains(text(), 'A value is required')]";

        public RequestDetailsMileStone(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            GetElementByXpath(staticPageElement).Click();
        }

        public RequestDetailsMileStone SelectGeneralRequestType()
        {
            GetElementByXpath(genrealRequestType).Click();
            return this;
        }

        public RequestDetailsMileStone SelectLgaRequestType()
        {
            GetElementByXpath(LgaType).Click();
            return this;
        }
	 
	public RequestDetailsMileStone SelectEventRequestType()
        {
            GetElementByXpath(eventRequestRequestType).Click();
            return this;
        }

        public RequestDetailsMileStone CompleteEventDetails()
        {
            GetElementByXpath(eventFromDate).SendKeys("28/11/2020");
            GetElementByXpath(eventFromTime).SendKeys("10:00 am");
            GetElementByXpath(eventToDate).SendKeys("30/11/2020");
            GetElementByXpath(eventToTime).SendKeys("11:35 pm");
            GetElementByXpath(eventPurpose).SendKeys("Splendour in the Grass");
            GetElementByXpath(eventLandSize).SendKeys("24596");
            UploadDocument(_driver.FindElement(By.XPath(eventUploadLayoutDocument)), "20180619 Event Layout or map.docx");
            GetElementByXpath(eventVisitors).SendKeys("24500");
            GetElementByXpath(eventEmployees).SendKeys("75");
            GetElementByXpath(eventArtists).SendKeys("14");
            GetElementByXpath(eventRevenue).SendKeys("750000");
            GetElementByXpath(eventGrants).SendKeys("175250");
            GetElementByXpath(eventExpenditure).SendKeys("458769");
            GetElementByXpath(eventApplicationDateReceived).SendKeys("03/09/2018");
            GetElementByXpath(staticPageElement).Click();
            UploadDocument(_driver.FindElement(By.XPath(eventUploadApplicantsRequest)), "20180611_Applicants_Request_01.docx");
            UploadDocument(_driver.FindElement(By.XPath(eventUploadGrantDocument)), "20180619 Event Grant or Sponsorship Details.docx");

            return this;
        }

        public RequestDetailsMileStone SelectRequestType(RequestType type)
        {
            switch (type)
            {
                case RequestType.General:
                    GetElementByXpath(genrealRequestType).Click();
                    break;
                case RequestType.LGA:
                    GetElementByXpath(LgaType).Click();
                    break;
                case RequestType.Event:
                    GetElementByXpath(EventType).Click();
                    break;
            }           
            return this;
        }

        public RequestDetailsMileStone EnterPosition(string position)
        {
            GetElementByXpath(positionTextBox).SendKeys(position);
            return this;
        }

        public RequestDetailsMileStone SelectCategoryFromDropdown(string name)
        {
            GetElementByXpath(categoryDropdown).Click();
            GetElementByXpath($"//*[text()='{name}']").Click();
            return this;
        }

        public RequestDetailsMileStone EnterDescription(string desc)
        {
            GetElementByXpath(descriptionTextArea).SendKeys(desc);
            return this;
        }

        public RequestDetailsMileStone ClickCLEFRequestCheckbox()
        {
            GetElementByXpath(CLEFRequestCheckbox).Click();
            return this;
        }

        public RequestDetailsMileStone ClickApplicantSignedCheckbox()
        {
            GetElementByXpath(signedCheckbox).Click();
            return this;
        }

        public RequestDetailsMileStone EnterDateSigned()
        {
            GetElementByXpath(dateSigned).SendKeys(currentDate);
            return this;
        }

        public RequestDetailsMileStone EnterDateReceived()
        {
            GetElementByXpath(dateReceived).SendKeys(currentDate);
            return this;
        }

        public RequestDetailsMileStone UploadDocument(string fileName)
        {
            GetElementByXpath(staticPageElement).Click();
            UploadDocument(_driver.FindElement(By.XPath(uploadField)), fileName);
            return this;
        }


        public LandDetailsMileStone ClickContinueButton()
        {
            GetElementByXpath(continueButton).Click();
            try { 
            if (_driver.FindElement(By.XPath(errorMessage)).Displayed)
                throw new Exception("Error displayed on Request Details page");
            }catch(Exception e) { Console.WriteLine("Request Details error validation throws error");   }
            Console.WriteLine("Moved past Request Details Page");
            return new LandDetailsMileStone(_driver);
        }
    }
}
