using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Post
    {
        public string Title { set; get; }
        public string Sender { set; get; }
        public bool IsPublic { set; get; }

        public Post()
        {
            Title = "";
            Sender = "user";
            IsPublic = true;
        }

        public Post(string title, string sender, bool isPublic)
        {
            Title = title;
            Sender = sender;
            IsPublic = isPublic;
        }

        public void Update(string title, bool isPublic)
        {
            Title = title;
            IsPublic = IsPublic;
        }

        public string GetTitle() { return Title; }

        public virtual string PostReturn()
        {
            return string.Format("sent by {0}, its title is {1} - {2} public", Sender, Title, IsPublic);

        }


    }
}
