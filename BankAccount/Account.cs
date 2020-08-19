using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
	/// <summary>
	/// Represents a single checking account
	/// </summary>
	public class Account
	{
		private double _balance;

		/// <summary>
		/// Deposits the amount in the bank account
		/// and returns the new balance
		/// </summary>
		/// <param name="amt">The amount to deposit</param>
		public double Deposit(double amt)
		{
			_balance += amt;
			return _balance;
		}

		public double Balance
		{
			get
			{
				return _balance;
			}
		}

		public void Withdraw(double amt)
		{

		}
	}
}
