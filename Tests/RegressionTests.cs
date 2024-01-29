using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Tests.PageObjects;

namespace Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class RegressionTests : TestBase
    {
        const string UserName = "standard_user";
        const string Password = "secret_sauce";
        const string FirstName = "Heorhii";
        const string LastName = "Sashniev";
        const string Zip = "051997";

        [Test]
        public void ItemPurchase()
        {
            var loginPage = new LoginPage(driverManager.ChromeDriver);

            logger.Info("Step 1: Login to main page");
            var mainPage = loginPage.Login(UserName, Password);

            logger.Info("Step 2: Going to add a bag to the cart");
            mainPage.AddToCart_Btn.Click();

            logger.Info("Step 3: Getting items count number from the cart");
            var itemsCount = mainPage.ShoppingCart_Bdg.Text;

            logger.Info("Step 4: Verifying that bag was added to the cart");
            ClassicAssert.AreEqual("1", itemsCount);

            logger.Info("Step 5: Getting item price from main page");
            var itemsPriceOriginal = NumberSeachInText(mainPage.ItemPrice.Text);

            logger.Info("Step 6: Getting item name from main page");
            var itemsName = mainPage.ItemName.Text;

            logger.Info("Step 7: Clicking on a cart button");
            mainPage.Checkout_Btn.Click();

            var basketPage = new BasketPage(driverManager.ChromeDriver);
            logger.Info("Step 8: Verifying that item price is correct");
            var basketItemPrice = NumberSeachInText(basketPage.BasketItemPrice.Text);
            ClassicAssert.AreEqual(itemsPriceOriginal, basketItemPrice);

            logger.Info("Step 9: Verifying that item name is correct");
            var basketItemName = basketPage.BasketItemName.Text;
            ClassicAssert.AreEqual(itemsName, basketItemName);

            logger.Info("Step 10: Getting item quantity from basket page");
            var itemsQuantity = basketPage.BasketItemQuantity.Text;

            logger.Info("Step 11: Verifying that there is only 1 added item");
            ClassicAssert.AreEqual("1", itemsQuantity);

            logger.Info("Step 12: Going to checkout");
            basketPage.Checkout_Btn.Click();

            var checkoutPage = new CheckoutPage(driverManager.ChromeDriver);
            logger.Info("Step 13: Going to final conclusion");
            checkoutPage.CheckoutForm(FirstName, LastName, Zip);

            var totalPricePage = new TotalPricePage(driverManager.ChromeDriver);
            logger.Info("Step 14: Getting item price from checkout page");
            var itemsfinalPrice = totalPricePage.ItemPrice.Text;

            logger.Info("Step 15: Getting total price from checkout page");
            var itemsTotalPrice = NumberSeachInText(totalPricePage.TotalPrice.Text);
            //Convert to Double
            double itemsTotalPriceValue = Convert.ToDouble(itemsTotalPrice);

            logger.Info("Step 16: Getting tax value from checkout page");
            var tax = NumberSeachInText(totalPricePage.TaxValue.Text);
            double taxValue = Convert.ToDouble(tax);

            double originalItemPrice = itemsTotalPriceValue - taxValue;
            //Round to needed double format (e.g., 9.99)
            double roundedOriginalItemPrice = Math.Round(originalItemPrice, 2);
            //Convert to string to compare the value with original price
            string stringRoundedOriginalItemPrice = Convert.ToString(roundedOriginalItemPrice);

            logger.Info("Step 17: Verifying that total cost is correct");
            ClassicAssert.AreEqual(itemsPriceOriginal, stringRoundedOriginalItemPrice);

            logger.Info("Step 18: Going to successful purchase page");
            totalPricePage.Finish_Btn.Click();

            var completePage = new CompletePage(driverManager.ChromeDriver);
            logger.Info("Step 19: Going to successful purchase page");
            completePage.BackHome_Btn.Click();
        }

        public string NumberSeachInText(string RecivedString)
        {
           string SentString = Regex.Match(RecivedString, @"\d+\.\d+").Value;
           return SentString;
        }
    }
}