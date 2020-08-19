using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
	[TestClass()]
	public class AccountTests
	{
		private Account acc;

		[TestInitialize]
		public void Initialize()
		{
			acc = new Account();
		}

		[TestMethod]
		[DataRow(10_000)]
		[DataRow(11_234.12)]
		[DataRow(10_001)]
		[TestCategory("Deposit")]
		public void Deposit_TooLarge_ThrowsArgumentException(double tooLargeDeposit)
		{
			Assert.ThrowsException<ArgumentException>(() => acc.Deposit(tooLargeDeposit));
		}

		[TestMethod()]
		[DataRow(100)]
		[DataRow(.01)]
		[DataRow(9999.99)]
		[TestCategory("Deposit")]
		public void Deposit_PositiveAmount_AddsToBalance(double initialDeposit)
		{
			// AAA - Arange Act Assert

			// Arrange - Create variables
			const double startBalance = 0;

			// Act - Execute method under test
			acc.Deposit(initialDeposit);

			// Assert - Check a condition
			Assert.AreEqual(startBalance + initialDeposit, acc.Balance);
		}

		[TestMethod]
		[TestCategory("Deposit")]
		public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
		{
			const double initialBalance = 0;
			const double depositAmount = 10.55;

			double result = acc.Deposit(depositAmount);

			const double expectedBalance = initialBalance + depositAmount;
			Assert.AreEqual(expectedBalance, result);
		}

		[TestMethod]
		[TestCategory("Deposit")]
		public void Deposit_MultipleAmounts_ReturnsAccumulatedBalance()
		{
			double deposit1 = 10;
			double deposit2 = 25;
			double expectedBalance = deposit1 + deposit2;

			acc.Deposit(deposit1);
			acc.Deposit(deposit2);

			Assert.AreEqual(expectedBalance, acc.Balance);
		}

		[TestMethod]
		[TestCategory("Deposit")]
		public void Desposit_NegativeAmounts_ThrowsArgumentException()
		{
			double negativeDeposit = -1;

			Assert.ThrowsException<ArgumentException>
				(
					() => acc.Deposit(negativeDeposit)
				);
		}

		[TestMethod]
		[DataRow(100,50)]
		[DataRow(50, 50)]
		[DataRow(9.99, 9.99)]
		[TestCategory("Withdraw")]
		public void Withdraw_PositiveAmount_SubtractsFromBalance(double initialDeposit, double withdrawAmount)
		{
			double expectedBalance = initialDeposit - withdrawAmount;

			acc.Deposit(initialDeposit);
			acc.Withdraw(withdrawAmount);

			Assert.AreEqual(expectedBalance, acc.Balance);
		}

		[TestMethod]
		[DataRow(0.1,1)]
		[DataRow(50,50.1)]
		[DataRow(0.17, 150)]
		[TestCategory("Withdraw")]
		public void Withdraw_MoreThanBalance_ThrowsArgumentException(double initialDeposit, double withdrawAmount)
		{
			acc.Deposit(initialDeposit);

			Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
		}

		[TestMethod]
		[DataRow(0)]
		[DataRow(-0.1)]
		[DataRow(-9999)]
		[TestCategory("Withdraw")]
		public void Withdraw_NegativeAmount_ThrowsArgumentException(double withdrawAmount)
		{
			Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
		}
	}
}