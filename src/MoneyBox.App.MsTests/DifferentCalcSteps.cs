using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace MoneyBox.App.MsTests
{
    [Binding]
    public class DifferentCalcSteps
    {
        private int result;
        private Calculator calc = new Calculator();
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            calc.FirstNumber = p0;
        }
        
        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int p0)
        {
            calc.SecondNumber = p0;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            result = calc.Add();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(p0, result);
        }
    }
}
