using System;
using System.Drawing;

namespace ynhrMemberManage.Print
{
	/// <summary>
	/// Summary description for PrintTitleText.
	/// </summary>
	public class PrintSeatText: IPrintPrimitive
	{
		public PrintSeatText()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		// members...
		public String Text;

		public PrintSeatText(String buf)
		{
			Text = buf;
		}
		// CalculateHeight - work out how tall the primitive is...
		public float CalculateHeight(PrintEngine engine, Graphics graphics)
		{
			// return the height...
			return engine.SeatFont.GetHeight(graphics);
		}
		
		// Print - draw the text...
		public void Draw(PrintEngine engine, float yPos, Graphics graphics, Rectangle elementBounds)
		{
			// draw it...HeaderFont
			//			graphics.DrawString(engine.ReplaceTokens(Text), engine.PrintFont,
			//				engine.PrintBrush, elementBounds.Left, yPos, new StringFormat());
//			graphics.DrawString(Text, engine.SeatFont,
//				engine.PrintBrush, 35, yPos, new StringFormat());
			graphics.DrawString(engine.ReplaceTokens(Text), engine.SeatFont,
				engine.PrintBrush, 15, yPos, new StringFormat());
		}
	}
}
