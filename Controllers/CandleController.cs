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
    public class CandleController : ApiController
    {
        IMongoClient mongoClient = new MongoClient("mongodb+srv://marikfanarik:KMV1995qwe@cluster0.cpo9m.mongodb.net/test");
        // GET: api/Candle
        public string Get()
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var db = mongoClient.GetDatabase("MeAsk");
            var collection = db.GetCollection<Candle>("Candles");
            var users = collection.Find(x => true).ToList<Candle>();

            string error = "";
            var json = new
            {
                err = error,
                data = users
            };

            return jsonSerialiser.Serialize(json);
        }

        // GET: api/Candle/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Candle
        public string Post(Candle candle)
        {
            JsonResult result = new JsonResult();
            try
            {
                var jsonSerialiser = new JavaScriptSerializer();
                var db = mongoClient.GetDatabase("MeAsk");
                var collection = db.GetCollection<Candle>("Candles");

                collection.InsertOne(candle);
                var candles = collection.Find(x => true).ToList<Candle>();
                string error = "";
                var json = new
                {
                    err = error,
                    data = candles
                };
                return jsonSerialiser.Serialize(json);
            }
            catch
            {
                return "fail to save candle";
            }
        }

        // PUT: api/Candle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Candle/5
        public string Delete(Guid id)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var db = mongoClient.GetDatabase("MeAsk");
            var collection = db.GetCollection<Candle>("Candles");
            collection.DeleteOne(c => c.Id == id);
            var candles = collection.Find(x => true).ToList<Candle>();
            string error = "";
            var json = new
            {
                err = error,
                deleted = "candle - " + id + " has been deleted",
                data = candles
            };
            return jsonSerialiser.Serialize(json);
        }
    }
}
