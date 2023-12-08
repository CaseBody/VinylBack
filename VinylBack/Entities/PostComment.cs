namespace VinylBack.Entities
{
    public class PostComment
    {
        public int Id { get; set; }
        public string PosterName { get; set; }
        public string Description { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
