using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using App.Data.Contracts;
using App.Model;

namespace App.Web.Controllers
{
    public class FriendsController : ApiControllerBase
    {
        public FriendsController(IAppUow uow)
        {
            Uow = uow;
        }

        public List<FriendModel> Get()
        {
            var friends = new List<FriendModel> { 
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/1/", username = "UserName1" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/2/", username = "UserName2" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/3/", username = "UserName3" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/4/", username = "UserName4" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/5/", username = "UserName5" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/6/", username = "UserName6" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/7/", username = "UserName7" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/8/", username = "UserName8" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/1/", username = "UserName1" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/2/", username = "UserName2" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/3/", username = "UserName3" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/4/", username = "UserName4" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/5/", username = "UserName5" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/6/", username = "UserName6" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/7/", username = "UserName7" },
                new FriendModel { avatar = "http://lorempixel.com/40/40/sports/8/", username = "UserName8" }
            };

            return friends;
        }

    }

    public class FriendModel {
        public string username { get; set; }
        public string avatar { get; set; }
    }
}
