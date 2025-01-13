namespace Travela.WebUI.Dtos.Testimonial
{
    public class ResultTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string NameSurname { get; set; }
        public string Comment { get; set; }
        public string CommenterLocation { get; set; }
        public string ImageUrl { get; set; }
        public int CountStar { get; set; }
        public string Country { get; set; }
    }
}
