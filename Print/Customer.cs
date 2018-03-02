using System;

namespace ynhrMemberManage.Print
{
	/// <summary>
	/// Summary description for Customer.
	/// </summary>
	public class Customer: IPrintable
	{
		public Customer()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		// members...
		public int Id;
		public String FirstName;
		public String LastName;
		public String Company;
		public String Email;
		public String Phone;
		// Print...
		public void Print(PrintElement element)
		{
			// tell the engine to draw a header...
			element.AddHeader("Customer");

			// now, draw the data...
			element.AddData("Customer ID", Id.ToString());
			element.AddData("Name", FirstName + " " + LastName);
			element.AddData("Company", Company);
			element.AddData("E-mail", Email);
			element.AddData("Phone", Phone);

			// finally, add a blank line...
			element.AddBlankLine();
		}
	}
}
