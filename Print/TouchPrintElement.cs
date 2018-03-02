using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
namespace ynhrMemberManage.Print
{
	/// <summary>
	/// Summary description for PrintElement.
	/// </summary>
	public class TouchPrintElement
	{
		// members...
		private ArrayList _printPrimitives = new ArrayList();
		private ITouchPrintable _printObject;

		public TouchPrintElement(ITouchPrintable printObject)
		{
			_printObject = printObject;
		}
		// AddText - add text to the element...
		public void AddTitle(string buf)
		{
			AddPrimitive(new TouchPrintTitleText(buf));
		}
		public void AddInfo(string buf)
		{
			AddPrimitive(new TouchPrintInfoText(buf));
		}
		public void AddSeat(string buf)
		{
			AddPrimitive(new TouchPrintSeatText(buf));
		}
		public void AddBlack(string buf)
		{
			AddPrimitive(new TouchPrintBlackText(buf));
		}
		public void AddSeatData(String dataName, String dataValue)
		{
			// add this data to the collection...
			if (dataValue.Trim().Length > 0&&dataValue.Trim() != "0"&&dataValue.Trim()!="0.00")
			{
				AddSeat(dataName + ": " + dataValue);
			}			
		}
		public void AddText(String buf)
		{
			// add the text...
			AddPrimitive(new TouchPrintPrimitiveText(buf));
		}

		// AddPrimitive - add a primitive to the list...
		public void AddPrimitive(ITouchPrintPrimitive primitive)
		{
			// add it...
			_printPrimitives.Add(primitive);
		}

		// AddData - add data to the element...
		public void AddData(String dataName, String dataValue)
		{
			// add this data to the collection...
			if (dataValue.Trim().Length > 0&&dataValue.Trim() != "0"&&dataValue.Trim()!="0.00")
			{
				AddText(dataName + ": " + dataValue);
			}			
		}
		public void AddData(String dataName, object dataValue)
		{
			// add this data to the collection...
			if (dataValue.ToString().Trim().Length > 0 && dataValue.ToString().Trim() != "0"&& dataValue.ToString().Trim() != "0.00")
			{
				AddText(dataName + "£º" + dataValue.ToString());
			}			
		}

		// AddHorizontalRule - add a rule to the element...
		public void AddHorizontalRule()
		{
			// add a rule object...
			AddPrimitive(new TouchPrintPrimitiveRule());
		}

		// AddBlankLine - add a blank line...
		public void AddBlankLine()
		{
			// add a blank line...
			AddText("");
		}

		// AddHeader - add a header...
		public void AddHeader(String buf)
		{
			AddText(buf);
			AddHorizontalRule();
		}

		public float CalculateHeight(TouchPrintEngine engine, Graphics graphics)
		{
			// loop through the print height...
			float height = 0;
			foreach(ITouchPrintPrimitive primitive in _printPrimitives)
			{
				// get the height...
				height += primitive.CalculateHeight(engine, graphics);
			}

			// return the height...
			return height;
		}

		// Draw - draw the element on a graphics object...
		public void Draw(TouchPrintEngine engine, float yPos, Graphics graphics, Rectangle pageBounds)
		{
			// where...
			float height = CalculateHeight(engine, graphics);
			Rectangle elementBounds = new Rectangle(pageBounds.Left, (int)yPos, pageBounds.Right - pageBounds.Left, (int)height);

			// now, tell the primitives to print themselves...
			foreach(ITouchPrintPrimitive primitive in _printPrimitives)
			{
				// render it...
				primitive.Draw(engine, yPos, graphics, elementBounds);

				// move to the next line...
				yPos += primitive.CalculateHeight(engine, graphics);
			}
		}

	}
}
