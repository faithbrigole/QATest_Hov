using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QATest_Hov
{
	[Parallelizable]
	class SigninTestSuite : TestBase
	{

		[SetUp]
		public void SetUp()
		{
			BasicActions.ClickSignIn(driver);
		}

		[Test]
		public void Verify_Logo()
		{
			Assert.IsTrue(BasicActions.HasLogoLogin(driver));
		}

		[Test]
		public void Verify_Email()
		{
			string[] invalid = { "s", "ss@", "222", "gmail.com", "@gmail.com" };
			string[] valid = { "faithbrigole@gmail.com", "fbi@g.com", };

			string error_invalid = "Email is invalid.";
			string no_email = "Email is required.";

			foreach (var input in valid)
			{
				BasicActions.SetEmailAddressLogin(driver, input);
				if (input.Equals(string.Empty))
				{
					Assert.IsTrue(BasicActions.HasErrorMessageEmailLogin(driver));
					Assert.AreEqual(BasicActions.GetErrorMessageEmailLogin(driver), no_email);
				}
				else
				{
					Assert.IsFalse(BasicActions.HasErrorMessageEmail(driver));
				}
			}

			foreach (var input2 in invalid)
			{
				BasicActions.SetEmailAddressLogin(driver, input2);
				Assert.IsTrue(BasicActions.HasErrorMessageEmailLogin(driver));
				Assert.AreEqual(BasicActions.GetErrorMessageEmailLogin(driver), error_invalid);
			}
		}

		[Test]
		public void Verify_Unregistered_Email()
		{
			BasicActions.SetEmailAddressLogin2(driver, "helllllaaaa@nada.ltd"); //gyxiguka@boximail.com

			BasicActions.ClickSigninsButton(driver);

			Assert.IsTrue(BasicActions.PopupForUnregEmail(driver));
		}

		[Test]
		public void Verify_Can_Create_Login()
		{
			BasicActions.SetEmailAddressLogin2(driver, "gyxiguka@boximail.com"); 

			BasicActions.ClickSigninsButton(driver);

			Thread.Sleep(3000);
			Assert.IsTrue(BasicActions.ResultViewSignin(driver));
			Assert.AreEqual("Magic link is in your inbox", BasicActions.MagicLinkSignin(driver));
			Assert.AreEqual("gyxiguka@boximail.com", BasicActions.GetYourEmailAddressSignin(driver));
			Assert.IsTrue(BasicActions.HasOpenEmailButtonSignin(driver));
		}
	}
}
