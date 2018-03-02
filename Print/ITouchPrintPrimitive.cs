using System;
using System.Drawing;
namespace ynhrMemberManage.Print
{
	/// <summary>
	/// Summary description for IPrintPrimitive.
	/// </summary>
	public interface ITouchPrintPrimitive
	{
		// CalculateHeight - work out how tall the primitive is...
		float CalculateHeight(TouchPrintEngine engine, Graphics graphics);

		// Print - tell the primitive to physically draw itself...
		void Draw(TouchPrintEngine engine, float yPos, Graphics graphics, Rectangle elementBounds);

	}
}
