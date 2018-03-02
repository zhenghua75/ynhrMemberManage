using System;
using System.Drawing;
namespace ynhrMemberManage.Print
{
	/// <summary>
	/// Summary description for PrintPrimitiveRule.
	/// </summary>
	public class PrintPrimitiveRule: IPrintPrimitive
	{
		public PrintPrimitiveRule()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		// CalculateHeight - work out how tall the primitive is...
		public float CalculateHeight(PrintEngine engine, Graphics graphics)
		{
			// we're always five units tall...
			return 5;
		}
		// Print - draw the rule...
		public void Draw(PrintEngine engine, float yPos, Graphics graphics, Rectangle elementBounds)
		{
			// draw a line...
			Pen pen = new Pen(engine.PrintBrush, 1);
//			graphics.DrawLine(pen, elementBounds.Left, yPos + 2,
//				elementBounds.Right, yPos + 2);
			graphics.DrawLine(pen, 0, yPos + 2,
				300, yPos + 2);
			
		}


	}
}
