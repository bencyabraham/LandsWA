using LandsWa.Acceptance.Smoke.Tests.Pages;
using LandsWa.Acceptance.Smoke.Tests.SetupTeardown;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static LandsWa.Acceptance.Smoke.Tests.Helper.Enumerations;

namespace LandsWa.Acceptance.Smoke.Tests.Tests
{
    public class RequestDetailsMileStoneTest : BaseTest
    {
        LoginPage loginPage;
        MyDashboardPage myDashboard;
        [TestCase("BenAss", "Ben", "infy4321", User.Officer, "Ravi")]
        public void VerifyOfficerCanReachLandDetailsScreen(string login, string name, string password, User user, string applicantName)
        {
            loginPage = new LoginPage(Driver);

            var dashboard = loginPage.EnterUsername(login, user)
                .EnterPassword(password)
                .ClickLoginButton();

            myDashboard = (MyDashboardPage)dashboard;
            Assert.IsTrue(myDashboard.IsPageLoadComplete());
            Assert.IsTrue(myDashboard.IsOfficerNameDisplayed(name));

            bool isLandRecordPageLoaded = myDashboard.ClickCreateNewCaseButon()
                .SearchAnApplicantWithName(applicantName)
                .SelectTheApplicantFromSearchResultWithName(applicantName)
                .Continue()
                .ClickContinueButton()
                .SelectGeneralRequestType()
                .SelectCategoryFromDropdown("Easement")
                .EnterDescription("Case created by Automation testing script for an Easement")
                .ClickCLEFRequestCheckbox()
                .ClickApplicantSignedCheckbox()
                .EnterDateSigned()
                .EnterDateReceived()
                .UploadDocument("Document_1.txt")
                .ClickContinueButton()
                .IsPageLoaded();

            Assert.IsTrue(isLandRecordPageLoaded, "Land Record page has not loaded");
        }
 
        [TestCase("LiamKnP", "Liam", "infy4321", User.Officer, "Benjamin")]
        public void VerifyThatUserCanSubmitLgaRequest(string login, string name, string password, User user, string applicantName)
        {
            loginPage = new LoginPage(Driver);

            var dashboard = loginPage.EnterUsername(login, user)
                .EnterPassword(password)
                .ClickLoginButton();

            myDashboard = (MyDashboardPage)dashboard;
            Assert.IsTrue(myDashboard.IsPageLoadComplete());
            Assert.IsTrue(myDashboard.IsOfficerNameDisplayed(name));

            myDashboard.ClickCreateNewCaseButon()
                .SearchAnApplicantWithName(applicantName)
                .SelectTheApplicantFromSearchResultWithName(applicantName)
                .Continue()
                .ClickContinueButton()
                .SelectLgaRequestType()
                .SelectCategoryFromDropdown("Lease")
                .EnterDescription("LGA Request automation")
                .ClickCLEFRequestCheckbox()
                .ClickApplicantSignedCheckbox()
                .EnterDateSigned()
                .EnterPosition("Analyst")
                .EnterDateReceived()
                .UploadDocument("Document_1.txt")
                .ClickContinueButton()
                .IsPageLoaded();

            Thread.Sleep(2000);
        }

        [TestCase("WilmaFlin", "Wilma", "infy4321", User.Officer, "And")]
        public void VerifyOfficerCanCreateAnEvent(string login, string name, string password, User user, string applicantName)
        {
            loginPage = new LoginPage(Driver);

            var dashboard = loginPage.EnterUsername(login, user)
                .EnterPassword(password)
                .ClickLoginButton();

            myDashboard = (MyDashboardPage)dashboard;
            Assert.IsTrue(myDashboard.IsPageLoadComplete());
            Assert.IsTrue(myDashboard.IsOfficerNameDisplayed(name));

            RequestDetailsMileStone requestDetails =  myDashboard.ClickCreateNewCaseButon()
                .SearchAnApplicantWithName(applicantName)
                .SelectTheApplicantFromSearchResultWithName(applicantName)
                .Continue()
                .ClickContinueButton()
                .SelectEventRequestType()
                .CompleteEventDetails();

            Thread.Sleep(7000);

        }
    }
}
