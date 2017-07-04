using FacebookRestApiConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookRestApiClient.Models
{
    public class FacebookAccountViewModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public List<FbFriend> friends { get; set; }
        public List<FbPost> posts { get; set; }
        public List<FbPhoto> photos { get; set; }

        public FacebookAccountViewModel()
        {
            friends = new List<FbFriend>();
            posts = new List<FbPost>();
            photos = new List<FbPhoto>();
        }

        public void updateModel(FbAccount newModel)
        {
            if (newModel != null)
            {
                Name = newModel.name;
                Id = newModel.id;
                Email = newModel.email;
                ImageUrl = newModel.picture.data.url;

                if (newModel.friends != null && newModel.friends.data != null)
                {
                    foreach (var friend in newModel.friends.data)
                    {
                        var temp = new FbFriend()
                        {
                            Id = friend.id,
                            ImageUrl = friend.picture.data.url
                        };

                        friends.Add(temp);
                    }

                    if(newModel.posts != null && newModel.posts.data != null)
                    {
                        foreach(var post in newModel.posts.data)
                        {
                            if(post.message != null)
                            {
                                string time = (DateTime.ParseExact(post.created_time, "yyyy-MM-ddTHH:mm:ss+0000", System.Globalization.CultureInfo.InvariantCulture)).ToString("dd-MM-yyyy HH:mm:ss");
                                posts.Add(new FbPost() { Message = post.message, Time = time });
                            }
                        }
                    }

                    if(newModel.photos != null && newModel.photos.data != null)
                    {
                        foreach(var photo in newModel.photos.data)
                        {
                            if(photo != null)
                            {
                                photos.Add(new FbPhoto() { ImageUrl = photo.picture, Id = photo.id });
                            }
                        }
                    }
                }
            }
        }
    }

    public class FbFriend
    {
        public string Id { get; set; }
        public string ImageUrl {get;set;}
    }

    public class FbPost
    {
        public string Message { get; set; }
        public string Time { get; set; }
    }

    public class FbPhoto
    {
        public string ImageUrl { get; set; }
        public string Id { get; set; }
    }
}