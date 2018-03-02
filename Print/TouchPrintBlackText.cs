using System;
using System.Drawing;

namespace ynhrMemberManage.Print
{
	/// <summary>
	/// PrintBlackText ��ժҪ˵����
	/// </summary>
	public class TouchPrintBlackText: ITouchPrintPrimitive
	{
		public TouchPrintBlackText()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		// members...
		public String Text;

		public TouchPrintBlackText(String buf)
		{
			Text = buf;
		}
		// CalculateHeight - work out how tall the primitive is...
		public float CalculateHeight(TouchPrintEngine engine, Graphics graphics)
		{
			// return the height...
			return engine.BlackFont.GetHeight(graphics);
		}
		
		// Print - draw the text...
		public void Draw(TouchPrintEngine engine, float yPos, Graphics graphics, Rectangle elementBounds)
		{
			// draw it...HeaderFont
			//			graphics.DrawString(engine.ReplaceTokens(Text), engine.PrintFont,
			//				engine.PrintBrush, elementBounds.Left, yPos, new StringFormat());
			graphics.DrawString(engine.ReplaceTokens(Text), engine.BlackFont,
				engine.PrintBrush, 5, yPos, new StringFormat());
		}
	}
}
