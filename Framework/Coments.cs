
namespace Lecture8HomeWork.Framework
{
    class Coments
    {
        private int userId;
        private int id;
        private string title;
        private string body;

        public Coments(int userId)
        {
            this.UserId = userId;
        }

        public int UserId { get => userId; set => userId = value; }
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Body { get => body; set => body = value; }
    }
}