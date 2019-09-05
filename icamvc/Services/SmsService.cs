using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ICAMVC.Services
{
    public class SmsService
    {
        public static void SendMessage(string content)
        {

            string accountSid = "ACcf47966e280d3c55505619acb0f6a410";
            string authToken = "c4911a3786e652b078e41e94cf71b9a8";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: content,
                from: new Twilio.Types.PhoneNumber("+46790644265"),
                to: new Twilio.Types.PhoneNumber("+46761840599")
            );
        }
    }
}
