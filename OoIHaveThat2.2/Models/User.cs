using Microsoft.EntityFrameworkCore;

namespace OoIHaveThat2._2.Models
{
    public class User
    {

        public User()
        {
            
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public long PhoneNumber { get; set; }

        public string? Password { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        //Foreign Keys
        public List<ToolRequest> ToolRequests { get; set; }

        /* Version 2
        public List<Response> Responses { get; set; }

        public bool WantsToReceiveNotifications { get; set; }

        public bool WantsToReceiveTexts { get; set; }

        public bool WantsToReceiveEmails { get; set; }

        public int RadiusNotifications { get; set; }

        public int RadiusTexts { get; set; }

        public int RadiusEmails { get; set; }

        public double MinPriceNotifications { get; set; }

        public double MinPriceTexts { get; set; }

        public double MinPriceEmails { get; set; }
        */
    }
}
