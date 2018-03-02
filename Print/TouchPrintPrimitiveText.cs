using System;
using System.Drawing;
namespace ynhrMemberManage.Print
{
	/// <summary>
	/// Summary description for PrintPrimitiveText.
	/// </summary>
	public class TouchPrintPrimitiveText: ITouchPrintPrimitive
	{
		public TouchPrintPrimitiveText()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		// members...
		public String Text;

		public TouchPrintPrimitiveText(String buf)
		{
			Text = buf;
		}
		// CalculateHeight - work out how tall the primitive is...
		public float CalculateHeight(TouchPrintEngine engine, Graphics graphics)
		{
			// return the height...
			return engine.PrintFont.GetHeight(graphics);
		}
		
		// Print - draw the text...
		public void Draw(TouchPrintEngine engine, float yPos, Graphics graphics, Rectangle elementBounds)
		{
			// draw it...HeaderFont
//			graphics.DrawString(engine.ReplaceTokens(Text), engine.PrintFont,
//				engine.PrintBrush, elementBounds.Left, yPos, new StringFormat());
			graphics.DrawString(engine.ReplaceTokens(Text), engine.PrintFont,
				engine.PrintBrush, 15, yPos, new StringFormat());
		}

	}
}
