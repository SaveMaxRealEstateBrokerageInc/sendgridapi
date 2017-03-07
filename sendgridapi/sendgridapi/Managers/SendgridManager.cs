using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sendgridapi.Managers
{
    class SendgridManager
    {
        public static void RegisterationConfirmationMail(string toEmailId, string templateId)
        {
            Execute(toEmailId, templateId).Wait();
        }
        public static void RegistrationThanksMail(string toEmailId, string templateId)
        {
            Execute(toEmailId, templateId).Wait();
        }
        public static void SaveSearchMail(string toEmailId, string templateId)
        {
            Execute(toEmailId, templateId).Wait();
        }
        public static void FavouriteSearchMail(string toEmailId, string templateId)
        {
            Execute(toEmailId, templateId).Wait();
        }
        public static void VisitMail(string toEmailId, string templateId)
        {
            Execute(toEmailId, templateId).Wait();
        }

        static async Task Execute(string toEmailId, string templateId)
        {
            dynamic sg = new SendGridAPIClient("sendgridapiKey");
            string data = @"{
              'personalizations': [
                {
                  'to': [
                    {
                      'email': '" + toEmailId + @"'
                    }
                  ],
                  'substitutions': {
                    '-name-': 'Example User',
                    '-city-': 'Denver'
                  },
                  'subject': 'I\'m replacing the subject tag'
                }
              ],
              'from': {
                'email': 'senderEmail'
              },
              'content': [
                {
                  'type': 'text/html',
                  'value': 'I\'m replacing the <strong>body tag</strong>'
                }
              ],
                 'template_id': '" + templateId + @"',
              
            }";

            Object json = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(data);
            dynamic response = await sg.client.mail.send.post(requestBody: json.ToString());
        }
    }
}
