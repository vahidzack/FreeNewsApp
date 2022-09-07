using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace NewsApp.Models
{ 

    [Table("article")]
    public class Article
    {
    [JsonIgnore]
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }

    [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("publishedAt")]
        public DateTime PublishedAt { get; set; }
        [ForeignKey(typeof(Source))]
        public int SourceId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        [JsonProperty("source")]
        public Source Source { get; set; }
    }
}
