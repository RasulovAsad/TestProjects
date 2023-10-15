namespace VKApiTesting.Constants
{
    public static class Endpoints
    {
        public const string VkRequest = "method/{0}&access_token={1}&v={2}";
        public const string CreatePost = "wall.post?message={0}";
        public const string EditPost = "wall.edit?post_id={0}&message={1}&attachments=photo{2}_{3}";
        public const string DeletePost = "wall.delete?post_id={0}";
        public const string CreateComment = "wall.createComment?post_id={0}&message={1}";
        public const string IsLiked = "likes.isLiked?user_id={0}&item_id={1}&type={2}";
        public const string GetUploadServer = "photos.getUploadServer?album_id={0}";
        public const string SavePhoto = "photos.save?{0}";
        public const string GetUsers = "users.get?";
        public const string GetPhoto = "photos.getById?photos={0}_{1}";
        public const string GetAlbums = "photos.getAlbums?owner_id={0}";
        public const string SendPhotoToServer = "server={0}&album_id={1}&photos_list={2}&hash={3}";
    }
}