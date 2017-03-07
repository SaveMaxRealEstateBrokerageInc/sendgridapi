using sendgridapi.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sendgridapi.Controllers
{
    public class SendGridController : ApiController
    {
        public void Get()
        {
            SendgridManager.RegisterationConfirmationMail("receiverEmailId", "templateId");
        }
    }
}
