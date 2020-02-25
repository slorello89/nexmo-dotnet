using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexmo.Api.Request.Credentials
{
    public class CredentialsBasic : CredentialsBase
    {
        public string ApiKey { get; private set; }
        public string ApiSecret { get; private set; }
    }
}
