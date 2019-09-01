using System;
namespace SplitThatBill.Backend.API.Options
{
    public class NswagOptions
    {
        public NswagOptions()
        {
        }
        public NswagOptionsInfo Info { get; set; }
    }

    public class NswagOptionsInfo
    {
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TermsOfService { get; set; }
        public NswagOptionsContact Contact { get; set; }
    }

    public class NswagOptionsContact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
    }
}
