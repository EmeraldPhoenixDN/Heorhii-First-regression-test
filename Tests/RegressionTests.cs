using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Text.RegularExpressions;
using Tests.PageObjects;

namespace Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class RegressionTests : TestBase
    {
        string _userName = "standard_user";
        string _password = "secret_sauce";
        string _firstName = "Heorhii";
        string _lastName = "Sashniev";
        string _zip = "051997";


        [Test]
        public void ItemPurchase()
        {
            var loginPage = new LoginPage(driverManager.ChromeDriver);

            logger.Info("Step 1: Login to main page");
            var mainPage = loginPage.Login(_userName, _password);

            logger.Info("Step 2: Going to add a bag to the cart");
            mainPage.AddToCart_Btn.Click();

            logger.Info("Step 3: Getting items count number from the cart");
            var itemsCount = mainPage.ShoppingCart_Bdg.Text;

            logger.Info("Step 4: Verifying that bag was added to the cart");
            ClassicAssert.AreEqual("1", itemsCount);

            logger.Info("Step 5: Getting item price from main page");
            var itemsPrice = mainPage.ItemPrice.Text;
            string itemsPriceOriginalValue = Regex.Match(itemsPrice, @"\d+\.\d+").Value;


            logger.Info("Step 6: Verifying that item price is correct");
            ClassicAssert.AreEqual("9.99", itemsPriceOriginalValue);

            logger.Info("Step 7: Clicking on a cart button");
            mainPage.Checkout_Btn.Click();

            var basketPage = new BasketPage(driverManager.ChromeDriver);
            logger.Info("Step 8: Going to checkout");
            basketPage.Checkout_Btn.Click();

            var checkoutPage = new CheckoutPage(driverManager.ChromeDriver);
            logger.Info("Step 9: Going to final conclusion");
            checkoutPage.CheckoutForm(_firstName, _lastName, _zip);

            var totalPricePage = new TotalPricePage(driverManager.ChromeDriver);
            logger.Info("Step 10: Getting item price from checkout page");
            var itemsfinalPrice = totalPricePage.ItemPrice.Text;

            logger.Info("Step 11: Getting total price from checkout page");
            var itemsTotalPrice = totalPricePage.TotalPrice.Text;
            //Search for a number in Text string
            string itemsTotalPriceString = Regex.Match(itemsTotalPrice, @"\d+\.\d+").Value;
            //Convert to Double
            double itemsTotalPriceValue = Convert.ToDouble(itemsTotalPriceString);

            logger.Info("Step 12: Getting tax value from checkout page");
            var tax = totalPricePage.TaxValue.Text;
            string taxValueString = Regex.Match(tax, @"\d+\.\d+").Value;
            double taxValueValue = Convert.ToDouble(taxValueString);

            double originalItemPrice = itemsTotalPriceValue - taxValueValue;
            //Round to needed double format (e.g., 9.99)
            double roundedOriginalItemPrice = Math.Round(originalItemPrice, 2);
            //Convert to string to compare the value with original price
            string stringRoundedOriginalItemPrice = Convert.ToString(roundedOriginalItemPrice);


            logger.Info("Step 13: Verifying that total cost is correct");
            ClassicAssert.AreEqual(itemsPriceOriginalValue, stringRoundedOriginalItemPrice);

            logger.Info("Step 14: Going to successful purchase page");
            totalPricePage.Finish_Btn.Click();

            var completePage = new CompletePage(driverManager.ChromeDriver);
            logger.Info("Step 15: Going to successful purchase page");
            completePage.BackHome_Btn.Click();
        }
    }
}