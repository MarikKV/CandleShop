using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CandleShop.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CandleShop.Controllers
{
    public class UserController : ApiController
    {
        IMongoClient mongoClient = new MongoClient("mongodb+srv://marikfanarik:KMV1995qwe@cluster0.cpo9m.mongodb.net/test");
        // GET: api/User
        public string Get()
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var db = mongoClient.GetDatabase("MeAsk");
            var collection = db.GetCollection<User>("Users");
            var users = collection.Find(x => true).ToList<User>();

            string error = "";
            var json = new
            {
                err = error,
                data = users
            };
            return jsonSerialiser.Serialize(json);
        }


        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public string Post(User user)
        {
            JsonResult result = new JsonResult();
            try
            {
                var jsonSerialiser = new JavaScriptSerializer();
                var db = mongoClient.GetDatabase("MeAsk");
                var collection = db.GetCollection<User>("Users");

                collection.InsertOne(user);
                var users = collection.Find(x => true).ToList<User>();
                string error = "";
                var json = new
                {
                    err = error,
                    data = users
                };
                return jsonSerialiser.Serialize(json);
            }
            catch
            {
                return "fail to send";
            }
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/5
        public string Delete(Guid id)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var db = mongoClient.GetDatabase("MeAsk");
            var collection = db.GetCollection<User>("Users");
            collection.DeleteOne(u => u.Id == id);
            var users = collection.Find(x => true).ToList<User>();
            string error = "";
            var json = new
            {
                err = error,
                deleted = "user - " + id + " has been deleted",
                data = users
            };
            return jsonSerialiser.Serialize(json);
        }
    }
}
