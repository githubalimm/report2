using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace titan
{
    [Binding]
    public class Hooksdemo
    {
        private readonly ParallelConfig _parallelConfig;
        private readonly FeatureContext _featurecontext;
        private readonly ScenarioContext _scenariocontext;
        private ExtentTest _currentScenarioname;

        //public Hooksdemo(ParallelConfig parallelConfig, FeatureContext featurecontext, ScenarioContext scenariocontext) : base(parallelConfig)
        //{
        //    _parallelConfig = parallelConfig;
        //    _featurecontext = featurecontext;
        //    _scenariocontext = scenariocontext;
        //}



        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;


        private readonly IObjectContainer _objectContainer;

        private RemoteWebDriver driver;

        public Hooksdemo(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {

            var stepType = _scenariocontext.StepContext.StepInfo.StepDefinitionType.ToString();



            if (_scenariocontext.TestError == null)
            {
                if (stepType == "Given")
                    _currentScenarioname.CreateNode<Given>(_scenariocontext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _currentScenarioname.CreateNode<Given>(_scenariocontext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _currentScenarioname.CreateNode<Given>(_scenariocontext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _currentScenarioname.CreateNode<Given>(_scenariocontext.StepContext.StepInfo.Text);
            }
            else if (_scenariocontext.TestError != null)
            {
                var mediaentity = _parallelConfig.CaptureScreenshotAndReturnModel(_scenariocontext.Scenarioinfo.tittle.trim);
                if (stepType == "Given")
                    _currentScenarioname.CreateNode<Given>(_scenariocontext.StepContext.StepInfo.Text).Fail(_scenariocontext.TestError.InnerException);
                //string path = LoginPage.GetShot();
                //scenario.AddScreenCaptureFromPath(path);  
                else if (stepType == "When")
                    _currentScenarioname.CreateNode<Given>(_scenariocontext.StepContext.StepInfo.Text).Fail(_scenariocontext.TestError.InnerException);
                else if (stepType == "Then")
                    _currentScenarioname.CreateNode<Given>(_scenariocontext.StepContext.StepInfo.Text).Fail(_scenariocontext.TestError.Message);
            }
            // pending status
            else if (_scenariocontext.ScenarioExecutionStatus.ToString() == "StepDefintionPending")
            {
                if (stepType == "Given")
                    _currentScenarioname.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("StepDefintionPending");
                else if (stepType == "When")
                    _currentScenarioname.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("StepDefintionPending");
                else if (stepType == "Then")
                    _currentScenarioname.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("StepDefintionPending");
            }

        }
        [BeforeTestRun]
        public static void InitializeReport()
        {

            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Ali\source\repos\titan\titan\report1\extentline.html");

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
        }


        [BeforeScenario]
        public void Initialize()
        {

            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void CleanUp()
        {
            //driver.Quit();
        }


    }


}