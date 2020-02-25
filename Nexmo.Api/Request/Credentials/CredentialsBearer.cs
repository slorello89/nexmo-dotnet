using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexmo.Api.Request.Credentials
{
    public class CredentialsBearer : CredentialsBase
    {
        public string ApplicationId { get; private set; }
        public string PrivateKey { get; private set; }
    }
}
