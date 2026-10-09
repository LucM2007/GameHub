using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class Footage
    {
        [Key]
        private ObjectId FootageId;
        public bool Image;
        public string Name;
        public string Path;
    }
}
