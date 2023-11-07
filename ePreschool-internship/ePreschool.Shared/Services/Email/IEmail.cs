using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Shared.Services.Email
{
    public interface IEmail
    {
        Task Send(string subject, string body, string toAddress, string name);
    }
}
