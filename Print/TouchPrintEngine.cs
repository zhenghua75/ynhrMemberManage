//using statements:
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ynhrMemberManage.Print
{
	/// <summary>
	/// Summary description for PrintEngine.
	/// </summary>
	public class TouchPrintEngine: PrintDocument
	{
		
		// members...
		private ArrayList _printObjects = new ArrayList();

		public Font PrintFont = new Font("Arial", 8);
		public Font TitleFont = new Font("Arial", 15);
		public Font SeatFont = new Font("Arial",15,FontStyle.Bold);
		public Font InfoFont = new Font("Arial",7,FontStyle.Bold);

//		public Font PrintFont = new Font("Arial", 8);
//		public Font TitleFont = new Font("Arial", 15);
//		public Font SeatFont = new Font("Arial",15,FontStyle.Bold);
		public Font BlackFont = new Font("Arial",10,FontStyle.Bold);
		public Brush PrintBrush =Brushes.Black;
		public TouchPrintElement Header;
		public TouchPrintElement Footer;
		private ArrayList _printElements;
		private int _printIndex = 0;
		private int _pageNum = 0;
		public TouchPrintEngine()
		{
			// create the header...
			Header = new TouchPrintElement(null);
			Header.AddTitle("云南人才市场");
			//Header.AddText("Page: [pagenum]");
			Header.AddHorizontalRule();
			//Header.AddBlankLine();

			// create the footer...
//			Footer = new PrintElement(null);
//			Footer.AddBlankLine();
//			Footer.AddHorizontalRule();
			//Footer.AddText("Confidential");
		}
		// ShowPreview - show a print preview...
		public void ShowPreview()
		{
			// now, show the print dialog...
			PrintPreviewDialog dialog = new PrintPreviewDialog();
			dialog.Document = this;

			// show the dialog...
			dialog.ShowDialog();
		}
		// OnBeginPrint - called when printing starts
		protected override void OnBeginPrint(PrintEventArgs e)
		{
			// reset...
			_printElements = new ArrayList();
			_pageNum = 0;
			_printIndex = 0;

			// go through the objects in the list and create print elements for each one...
			foreach(ITouchPrintable printObject in _printObjects)
			{
				// create an element...
				TouchPrintElement element = new TouchPrintElement(printObject);
				_printElements.Add(element);

				// tell it to print...
				//element.Print();
				printObject.Print(element);
			}
		}

		
		// OnPrintPage - called when printing needs to be done...
		protected override void OnPrintPage(PrintPageEventArgs e)
		{
            float headerHeight = Header.CalculateHeight(this, e.Graphics);
            Header.Draw(this, 10, e.Graphics, e.MarginBounds);
			Rectangle pageBounds = new Rectangle(15,
				(int)(e.MarginBounds.Top + headerHeight), e.MarginBounds.Width,
				(int)(e.MarginBounds.Height - headerHeight));
            float yPos = 50;//pageBounds.Top;
			// ok, now we need to loop through the elements...
			//bool morePages = false;
			int elementsOnPage = 0;
			while(_printIndex < _printElements.Count)
			{
				// get the element...
				TouchPrintElement element = (TouchPrintElement)_printElements[_printIndex];
				// how tall is the primitive?
				float height = element.CalculateHeight(this, e.Graphics);

				// will it fit on the page?
//				if(yPos + height > pageBounds.Bottom)
//				{
//					// we don't want to do this if we're the first thing on the page...
//					if(elementsOnPage != 0)
//					{
//						morePages = true;
//						break;
//					}
//				}
				// now draw the element...
				element.Draw(this, yPos, e.Graphics, pageBounds);

				// move the ypos...
				yPos += height;

				// next...
				_printIndex++;
				elementsOnPage++;
			}
			
			// do we have more pages?
			//e.HasMorePages = morePages;
		}

		// ReplaceTokens - take a string and remove any tokens replacing them with values...
		public String ReplaceTokens(String buf)
		{
			// replace...
			buf = buf.Replace("[pagenum]", _pageNum.ToString());

			// return...
			return buf;
		}
		public void ShowPageSettings()
		{
			PageSetupDialog setup = new PageSetupDialog();
			PageSettings settings = DefaultPageSettings;
			setup.PageSettings = settings;

			// display the dialog and,
			if(setup.ShowDialog() == DialogResult.OK)
				DefaultPageSettings = setup.PageSettings;
		}
		// ShowPrintDialog - display the print dialog...
		public void ShowPrintDialog()
		{
			// create and show...
			PrintDialog dialog = new PrintDialog();
			dialog.PrinterSettings = PrinterSettings;
			dialog.Document = this;
			if(dialog.ShowDialog() == DialogResult.OK)
			{
				// save the changes...
				PrinterSettings = dialog.PrinterSettings;

				// do the printing...
				Print();
			}
		}
		// AddPrintObject - add a print object the document...
		public void AddPrintObject(ITouchPrintable printObject)
		{
			_printObjects.Add(printObject);
		}		
	}
}
