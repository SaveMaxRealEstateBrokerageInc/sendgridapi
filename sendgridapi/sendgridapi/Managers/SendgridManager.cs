using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sendgridapi.Managers
{
    class SendgridManager
    {
        public static void SendMail(string toEmailId)
        {
            Execute(toEmailId).Wait();
        }

        static async Task Execute(string toEmailId)
        {
            dynamic sg = new SendGridAPIClient(ConfigurationManager.AppSettings["sendGridApiKey"]);
            string data = @"{
              'personalizations':
                [
                    {
                        'to': 
                        [
                            {
                              'email': '" + toEmailId + @"'
                            }
                        ],
                        'substitutions':
                        {
                            '-name-': 'Example User',
                            '-city-': 'Denver'
                        },
                        'subject': 'I\'m replacing the subject tag'
                    }
              ],
              'from':
                {
                    'email': '" + ConfigurationManager.AppSettings["fromEmailId"] + @"'
                },
              'content': 
                [
                    {
                      'type': 'text/html',
                      'value': '<h1>Welcome</h1>'
                    }
                ],      
                'template_id': '" + ConfigurationManager.AppSettings["templateIdForEmailConfirmation"] + @"',     
            }";

            Object json = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(data);
            dynamic response = await sg.client.mail.send.post(requestBody: json.ToString());
        }
    }
}
