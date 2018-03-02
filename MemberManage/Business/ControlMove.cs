using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
namespace MemberManage.Business
{
	///   <summary>  
	///   �ؼ��϶���  
	///   </summary>  
	public   class   ControlMove  
	{  
		///   <summary>  
		///   �϶��ؼ�  
		///   </summary>  
		private   Control   MControl;  
		///   <summary>  
		///    
		///   </summary>  
		private   Control   HControl;  
		private   bool   IsMouseDown   =   false;  
		private   Point   oPointClicked;  
		///   <summary>  
		///   ����ؼ��϶�����  
		///   </summary>  
		///   <param   name="moveControl">��Ҫ�϶��Ŀؼ�</param>  
		///   <param   name="handleContrl">�߱��϶������Ŀؼ�</param>  
		public   ControlMove(Control   moveControl,Control   handleContrl)  
		{  
			//  
			//   TODO:   �ڴ˴���ӹ��캯���߼�  
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
