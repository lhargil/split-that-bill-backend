using System;
namespace SplitThatBill.Backend.SharedKernel.Models
{
    public interface IAuthConfig
    {
        public string ClientId { get; set; }
        public string Domain { get; set; }
        public string Audience { get; set; }
    }
}
