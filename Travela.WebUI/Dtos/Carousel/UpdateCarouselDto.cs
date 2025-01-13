namespace Travela.WebUI.Dtos.Carousel
{
    public class UpdateCarouselDto
    {
        public int CarouselId { get; set; }
        public string Title { get; set; }
        public string Title1 { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
        public string UsePage { get; set; } //sonradan ekledim hata olursa sil
    }
}
