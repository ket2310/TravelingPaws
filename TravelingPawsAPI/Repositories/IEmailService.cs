using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelingPawsAPI.Maps;

namespace TravelingPawsAPI.Repositories
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
