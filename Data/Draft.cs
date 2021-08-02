using System;

namespace Data
{
    public class Draft
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Participants { get; set; }
        public int PlayersDrafted { get; set; }
        public string Sport { get; set; }
    }
}