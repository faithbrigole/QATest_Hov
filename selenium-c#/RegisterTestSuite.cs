using System;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;

namespace QATest_Hov
{
	class RegisterTestSuite : TestBase
	{

		[SetUp]
		public void SetUp()
		{
			BasicActions.ClickRegister(driver);
		}

		[Test]
		public void Verify_FirstName()
		{
			string[] correct = { "Faith", "namenamename"};
			string[] numbers = { "0", "12346479", "name1234", "%%%%" };                     // meant to fail on entering 0 because it gives a validation message - "Last name must be 2 or more characters instead of "Numbers or Special Characters not allowed"
			string must_be_wrong = "namewewrwrwerhweiryewiryeuiryeiuwr";

			string error_number = "Numbers or Special Characters not allowed.";
			string error_required = "First name is required.";
			string error_char = "First name must not exceed to more than 20 characters";

			foreach (var input in correct)
			{
				BasicActions.SetFirstName(driver, input);
				if (input.Equals(string.Empty))
				{
					Assert.IsTrue(BasicActions.HasErrorMessageFirstName(driver));
					Assert.AreEqual(BasicActions.GetErrorMessageFirstName(driver), error_required);
				}
				else
				{
					Assert.IsFalse(BasicActions.HasErrorMessageFirstName(driver));
				}
			}

			foreach (var input2 in numbers)
			{
				BasicActions.SetFirstName(driver, input2);
				Assert.IsTrue(BasicActions.HasErrorMessageFirstName(driver));
				Assert.AreEqual(BasicActions.GetErrorMessageFirstName(driver), error_number);
			}

			BasicActions.SetFirstName(driver, must_be_wrong);
			Assert.AreEqual(BasicActions.GetErrorMessageFirstName(driver), error_char); // meant to fail. No validation message when characters exceed to 20.

		}

		[Test]
		public void Verify_LastName()
		{
			string[] correct = { "Faith", "namenamename" };
			string[] numbers = { "0", "12346479", "name1234", "%%%%" };                 // meant to fail on entering 0 because it gives a validation message - "Last name must be 2 or more characters instead of "Numbers or Special Characters not allowed."
			string must_be_wrong = "namewewrwrwerhweiryewiryeuiryeiuwr";

			string error_number = "Numbers or Special Characters not allowed.";
			string error_required = "Last name is required.";
			string error_char = "Last name must not exceed to more than 20 characters";

			foreach (var input in correct)
			{
				BasicActions.SetLastName(driver, input);
				if (input.Equals(string.Empty))
				{
					Assert.IsTrue(BasicActions.HasErrorMessageLastName(driver));
					Assert.AreEqual(BasicActions.GetErrorMessageLastName(driver), error_required);
				}
				else
				{
					Assert.IsFalse(BasicActions.HasErrorMessageLastName(driver));
				}
			}

			foreach (var input2 in numbers)
			{
				BasicActions.SetLastName(driver, input2);
				Assert.IsTrue(BasicActions.HasErrorMessageLastName(driver));
				Assert.AreEqual(BasicActions.GetErrorMessageLastName(driver), error_number);
			}

			BasicActions.SetLastName(driver, must_be_wrong);
			Assert.AreEqual(BasicActions.GetErrorMessageLastName(driver), error_char); // meant to fail. No validation message when characters exceed to 20.
		}

		[Test]
		public void Verify_Email()
		{
			string[] invalid = { "s", "ss@", "222", "gmail.com", "@gmail.com"};
			string[] valid = { "faithbrigole@gmail.com", "fbi@g.com", };

			string error_invalid = "Email is invalid.";
			string no_email = "Email is required.";

			foreach (var input in valid)
			{
				BasicActions.SetEmailAddress(driver, input);
				if (input.Equals(string.Empty))
				{
					Assert.IsTrue(BasicActions.HasErrorMessageEmail(driver));
					Assert.AreEqual(BasicActions.GetErrorMessageEmail(driver), no_email);
				}
				else
				{
					Assert.IsFalse(BasicActions.HasErrorMessageEmail(driver));
				}
			}

			foreach (var input2 in invalid)
			{
				BasicActions.SetEmailAddress(driver, input2);
				Assert.IsTrue(BasicActions.HasErrorMessageEmail(driver));
				Assert.AreEqual(BasicActions.GetErrorMessageEmail(driver), error_invalid);
			}
		}

		[Test]
		public void Verify_Logo_Above()
		{
			Assert.IsTrue(BasicActions.HasLogo(driver));
		}

		[Test]
		public void Verify_Can_Create_Account()
		{
			BasicActions.SetFirstNameRegister(driver, "trial");
			BasicActions.SetLastNameRegister(driver, "lastname");
			BasicActions.SetEmailAddressRegister(driver, "helloworld@nada.ltd");

			BasicActions.ClickRegisterButton(driver);

			Assert.IsTrue(BasicActions.ResultView(driver));
			Assert.AreEqual("Magic link is in your inbox", BasicActions.MagicLink(driver));
			Assert.AreEqual("helloworld@nada.ltd", BasicActions.GetYourEmailAddress(driver));
			Assert.IsTrue(BasicActions.HasOpenEmailButton(driver));
		}
	}
}
