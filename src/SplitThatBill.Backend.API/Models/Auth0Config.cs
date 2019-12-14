using System;
using SplitThatBill.Backend.SharedKernel.Models;

namespace SplitThatBill.Backend.API.Models
{
    public class Auth0Config : IAuthConfig
    {
        public Auth0Config()
        {
        }

        public string ClientId { get; set; }
        public string Domain { get; set; }
        public string Audience { get; set; }
    }
}
