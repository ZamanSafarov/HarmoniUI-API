namespace Harmoni.UI.DTOs.FAQ
{
    public class FAQ
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int FAQContentId { get; set; }
        public FAQContent FAQContent { get; set; }
    }
}
