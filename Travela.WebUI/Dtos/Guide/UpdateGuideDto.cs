namespace Travela.WebUI.Dtos.Guide
{
    public class UpdateGuideDto
    {
        public int GuideId { get; set; }
        public string GuideNameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Designation { get; set; }
        public string? facebookUrl { get; set; }
        public string? twitterUrl { get; set; }
        public string? instagramUrl { get; set; }
        public string? linkedinUrl { get; set; }
    }
}
