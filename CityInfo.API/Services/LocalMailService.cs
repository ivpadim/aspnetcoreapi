using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Settings;
using Microsoft.Extensions.Options;

namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
		private readonly string _mailTo;
		private readonly string _mailFrom;

		public LocalMailService(IOptions<MailSettings> mailSettings)
		{
			_mailTo = mailSettings.Value.MailToAddress;
			_mailFrom = mailSettings.Value.MailFromAddress;
		}

		public void Send(string subject, string message)
		{
			// send mail - output to debug window
			Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService.");
			Debug.WriteLine($"Subject: {subject}");
			Debug.WriteLine($"Message: {message}");
		}
    }
}
