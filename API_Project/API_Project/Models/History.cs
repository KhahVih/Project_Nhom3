﻿namespace API_Project.Models
{
    public class History
    {
        public int Id { get; set; }
        public string? Ip { get; set; }
        public string? Action { get; set; }
        public DateTime? Datetime { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Link { get; set; }
    }
}
