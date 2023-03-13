using System.ComponentModel.DataAnnotations.Schema;

namespace OoIHaveThat2._2.Models
{
    public class ToolRequest
    {
        public ToolRequest() {
            
        }
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? TimeNeededFor { get; set; }

        public double PriceFirstOffer { get; set; }

        //Navigation Properties
        [ForeignKey("User")]
        public User User { get; set; }


        /*Version 2
        public DateTime CreatedAt { get; set; }

        public string? PictureUrl { get; set; }

        public byte[]? PictureAsByteArr { get; set; }
        */
    }
}
