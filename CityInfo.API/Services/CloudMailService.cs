using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
	{
		private string _mailTo = "ventas@matchdata.com.mx";
		private string _mailFrom = "monkey@matchdata.com.mx";

		public void Send(string subject, string message)
		{
			// send mail - output to debug window
			Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with CloudMailService.");
			Debug.WriteLine($"Subject: {subject}");
			Debug.WriteLine($"Message: {message}");
		}
	}
}
