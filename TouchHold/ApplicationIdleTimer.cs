using System;
using System.Windows;
using System.Windows.Forms;
namespace TouchHold
{
	/// <summary>
	/// ApplicationIdleTimer provides a convenient way of
	/// processing events only during application dormancy.
	/// Why use this instead of the Application.Idle event?
	/// That event gets fired EVERY TIME the message stack
	/// is exhausted, which basically means it fires very
	/// frequently.  With this, you only get events when 
	/// the application is actually idle.
	/// </summary>
	public class ApplicationIdleTimer_Test: IMessageFilter
	{
			
		#region Static Members and Events
		
		/// <summary>
		/// EventArgs for an ApplicationIdle event.
		/// </summary>
		public class ApplicationIdleEventArgs : EventArgs
		{
			// time of last idle
			private DateTime _idleSince;
			// duration of "idleness"
			private TimeSpan _idleTime;
			
			/// <summary>
			/// Internal constructor
			/// </summary>
			/// <param name="idleSince">Time app was declared idle</param>
			internal ApplicationIdleEventArgs(DateTime idleSince) : base()
			{
				_idleSince = idleSince;
				_idleTime = new TimeSpan(DateTime.Now.Ticks - idleSince.Ticks);
			}
			
			/// <summary>
			/// Timestamp of the last time the application was "active".
			/// </summary>
			public DateTime IdleSince
			{
				get { return _idleSince; }
			}
			
			/// <summary>
			/// Duration of time the application has been idle.
			/// </summary>
			public TimeSpan IdleDuration
			{
				get { return _idleTime; }
			}
		}
		/// <summary>
		/// ApplicationIdle event handler.
		/// </summary>
		public delegate void ApplicationIdleEventHandler( ApplicationIdleEventArgs e );
		
		/// <summary>
		/// Hook into the ApplicationIdle event to monitor inactivity.
		/// It will fire AT MOST once per second.
		/// </summary>
		public  event ApplicationIdleEventHandler ApplicationIdle;
		#endregion
	
		public bool PreFilterMessage(ref Message m) 
		{
			// Blocks all the messages relating to the left mouse button.
			if (m.Msg >= 0x0100 && m.Msg <= 0x010F||
				m.Msg >= 0x0200 && m.Msg <= 0x020A
				) 
			{
				//Console.WriteLine("Processing the messages : " + m.Msg);
				//_timer.Stop();
				isIdle = false;
				//return true;
			}
			return false;
		}

		#region Private Members
		private System.Timers.Timer _timer; 
		private System.DateTime lastAppIdleTime;	
		public System.DateTime LastAppIdleTime
		{
			set{lastAppIdleTime = value;}
		}
		private bool isIdle;
		#endregion

		#region Constructors
		/// <summary>
		/// Private constructor.  One instance is plenty.
		/// </summary> 
		public ApplicationIdleTimer_Test()
		{
			// Initialize counters
			isIdle = false;
			lastAppIdleTime = DateTime.Now;			

			// Set up the timer and the counters
			_timer = new System.Timers.Timer(500); // every half-second.
			_timer.Enabled = true;
			_timer.Start();
			
			// Hook into the events
			_timer.Elapsed += new System.Timers.ElapsedEventHandler(Heartbeat);
			System.Windows.Forms.Application.Idle += new EventHandler(Application_Idle);
			//System.Windows.Forms.Application.AddMessageFilter(this);
		}
		#endregion

		#region Private Methods
		
		private void Heartbeat(object sender, System.Timers.ElapsedEventArgs e)
		{						
			if(isIdle)
			{
				OnApplicationIdle();				
			}
			else
			{
				lastAppIdleTime = DateTime.Now;
			}
		}
		private void Application_Idle(object sender, EventArgs e)
		{
			//_timer.Start();
			if (!isIdle)
			{
				isIdle = true;
				lastAppIdleTime = DateTime.Now;
			}
			
		}
		private void OnApplicationIdle()
		{
			// Check to see if anyone cares.
			if (ApplicationIdle == null) return;
			
			// Build the message
			ApplicationIdleEventArgs e = new ApplicationIdleEventArgs(this.lastAppIdleTime);
						
			// Iterate over all listeners
			foreach( MulticastDelegate multicast in ApplicationIdle.GetInvocationList() )
			{
				// Raise the event
				multicast.DynamicInvoke( new object[] { e } );
			}
		}
		#endregion
	}
}
