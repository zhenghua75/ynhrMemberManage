using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
namespace MemberManage.Business
{
	///   <summary>  
	///   控件拖动类  
	///   </summary>  
	public   class   ControlMove  
	{  
		///   <summary>  
		///   拖动控件  
		///   </summary>  
		private   Control   MControl;  
		///   <summary>  
		///    
		///   </summary>  
		private   Control   HControl;  
		private   bool   IsMouseDown   =   false;  
		private   Point   oPointClicked;  
		///   <summary>  
		///   构造控件拖动对象  
		///   </summary>  
		///   <param   name="moveControl">需要拖动的控件</param>  
		///   <param   name="handleContrl">具备拖动能力的控件</param>  
		public   ControlMove(Control   moveControl,Control   handleContrl)  
		{  
			//  
			//   TODO:   在此处添加构造函数逻辑  
			//  
   
			MControl   =   moveControl;  
			HControl   =   handleContrl;  
			HControl.MouseDown   +=   new   MouseEventHandler(this.handle_MouseDown);  
			HControl.MouseUp   +=   new   MouseEventHandler(this.handle_MouseUp);  
			HControl.MouseMove   +=   new   MouseEventHandler(this.handle_MouseMove);  
   
		}  
		private   void   handle_MouseDown(object   sender,   System.Windows.Forms.MouseEventArgs   e)  
		{  
			IsMouseDown   =   true;  
			oPointClicked   =   new   Point(e.X,e.Y);  
   
		}  
   
		private   void   handle_MouseUp(object   sender,   System.Windows.Forms.MouseEventArgs   e)  
		{  
			IsMouseDown   =   false;  
		}  
		private   Point   GetParentPoint(System.Windows.Forms.Control   control)  
		{  
			Point   point   =   new   Point(0,0);  
			if(control   !=   null)  
			{  
				point.X   =   control.Left;  
				point.Y   =   control.Top;  
				Point   sub   =   GetParentPoint(control.Parent);  
				point.X   +=   sub.X;  
				point.Y   +=   sub.Y;  
			}  
			return   point;  
		}  
   
		private   void   handle_MouseMove(object   sender,   System.Windows.Forms.MouseEventArgs   e)  
		{  
   
			if(IsMouseDown)  
			{  
				Point   offpoint   =     GetParentPoint(MControl.Parent);  
				Point   point   =   MControl.PointToScreen(new   Point(e.X,e.Y));  
				point.Offset((this.oPointClicked.X+offpoint.X+4)*-1   ,(this.oPointClicked.Y   +SystemInformation.CaptionHeight+offpoint.Y   +SystemInformation.BorderSize.Height+3   )*-1);  
				MControl.Location   =   point;  
   
			}  
		}  
   
	}   
}
