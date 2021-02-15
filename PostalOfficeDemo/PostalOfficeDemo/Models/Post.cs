using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PostalOfficeDemo
{
    public class Post
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("id")]
        [Key]
        public int Id { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        public string ImageUrl { get; set; }
    }
}
