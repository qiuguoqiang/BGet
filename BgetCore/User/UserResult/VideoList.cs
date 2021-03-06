﻿using Newtonsoft.Json;

namespace BgetCore.User.UserResult
{
    public class VideoList
    {
        [JsonProperty("comment")]
        public int Comment { get; set; }

        [JsonProperty("typeid")]
        public int TypeId { get; set; }

        [JsonProperty("play")]
        public int Play { get; set; }

        [JsonProperty("pic")]
        public string Pic { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("review")]
        public int Review { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("mid")]
        public string MId { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("length")]
        public string Length { get; set; }

        [JsonProperty("video_review")]
        public int VideoReview { get; set; }

        [JsonProperty("favorites")]
        public int Favorites { get; set; }

        [JsonProperty("aid")]
        public string ContentId { get; set; }

        [JsonProperty("hide_click")]
        public bool HideClick { get; set; }
    }
}
