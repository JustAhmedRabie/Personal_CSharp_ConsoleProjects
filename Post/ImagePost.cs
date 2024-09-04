using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class ImagePost : Post
    {
        static int newPostID;

        protected int ID
        {
            get
            {
                return newPostID;
            }
        }

        public string ImageUrl { get; set; }

        public ImagePost() { }

        public ImagePost(string title, string sender, bool isPublic)
        {
            Title = title;
            Sender = sender;
            IsPublic = isPublic;
        }

        public ImagePost(string title, string sender, bool isPublic, string imageUrl)
        {
            Title = title;
            Sender = sender;
            IsPublic = isPublic;
            ImageUrl = imageUrl;
        }

        public void Update(string title, bool isPublic, string imageUrl)
        {
            Title = title;
            IsPublic = IsPublic;
            ImageUrl = imageUrl;
        }

        public override string PostReturn()
        {
            newPostID++;
            string text;

            if (ImageUrl != null)
            {
                if (IsPublic)
                {
                    text = string.Format("\nPost ID is {0}, sent by {1}, its title is \"{2}\" - public post, image link: {3}", newPostID, Sender, Title, ImageUrl);
                }
                else
                {
                    text = string.Format("\nPost ID is {0}, sent by {1}, its title is \"{2}\" - private post, image link: {3}", newPostID, Sender, Title, ImageUrl);
                }
            }
            else
            {
                if (IsPublic)
                {
                    text = string.Format("\nPost ID is {0}, sent by {1}, its title is \"{2}\" - public post", newPostID, Sender, Title);
                }
                else
                {
                    text = string.Format("\nPost ID is {0}, sent by {1}, its title is \"{2}\" - private post", newPostID, Sender, Title);
                }
            }
            return text;
        }
    }
}
