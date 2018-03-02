using System;
using System.Drawing;

namespace ynhrMemberManage.Print
{
	/// <summary>
	/// PrintBlackText 的摘要说明。
	/// </summary>
	public class PrintBlackText: IPrintPrimitive
	{
		public PrintBlackText()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		// members...
		public String Text;

		public PrintBlackText(String buf)
		{
			Text = buf;
		}
		// CalculateHeight - work out how tall the primitive is...
		public float CalculateHeight(PrintEngine engine, Graphics graphics)
		{
			// return the height...
			return engine.BlackFont.GetHeight(graphics);
		}
		
		// Print - draw the text...
		public void Draw(PrintEngine engine, float yPos, Graphics graphics, Rectangle elementBounds)
		{
			// draw it...HeaderFont
			//			graphics.DrawString(engine.ReplaceTokens(Text), engine.PrintFont,
			//				engine.PrintBrush, elementBounds.Left, yPos, new StringFormat());
			graphics.DrawString(engine.ReplaceTokens(Text), engine.BlackFont,
				engine.PrintBrush, 15, yPos, new StringFormat());
		}
	}
}
