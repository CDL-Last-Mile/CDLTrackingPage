namespace CDLTracker.Service.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    [Keyless]
    public class OrdersBase
    {

        public string DCity { get; set; }
        public string DState { get; set; }
        public string DZip { get; set; }
        public string PCity { get; set; }
        public string PState { get; set; }
        public string PZip { get; set; }
    }
}
