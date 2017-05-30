using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpiffyGiphy.Models
{
    [JsonObject]
    public class GiphyListResultRoot
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }

    [JsonObject]
    public class Meta
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }
    }

    [JsonObject]
    public class Pagination
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }
    }

    [JsonObject]
    public class Datum
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("bitly_gif_url")]
        public string BitlyGifUrl { get; set; }

        [JsonProperty("bitly_url")]
        public string BitlyUrl { get; set; }

        [JsonProperty("embed_url")]
        public string EmbedUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("content_url")]
        public string ContentUrl { get; set; }

        [JsonProperty("source_tld")]
        public string SourceTld { get; set; }

        [JsonProperty("source_post_url")]
        public string SourcePostUrl { get; set; }

        [JsonProperty("import_datetime")]
        public string ImportDatetime { get; set; }

        [JsonProperty("trending_datetime")]
        public string TrendingDatetime { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }
    }

    [JsonObject]
    public class Images
    {
        [JsonProperty("fixed_height")]
        public FixedHeight FixedHeight { get; set; }

        [JsonProperty("fixed_height_still")]
        public FixedHeightStill FixedHeightStill { get; set; }

        [JsonProperty("fixed_height_downsampled")]
        public FixedHeightDownsampled FixedHeightDownsampled { get; set; }

        [JsonProperty("fixed_width")]
        public FixedWidth FixedWidth { get; set; }

        [JsonProperty("fixed_width_still")]
        public FixedWidthStill FixedWidthStill { get; set; }

        [JsonProperty("fixed_width_downsampled")]
        public FixedWidthDownsampled FixedWidthDownsampled { get; set; }

        [JsonProperty("fixed_height_small")]
        public FixedHeightSmall FixedHeightSmall { get; set; }

        [JsonProperty("fixed_height_small_still")]
        public FixedHeightSmallStill FixedHeightSmallStill { get; set; }

        [JsonProperty("fixed_width_small")]
        public FixedWidthSmall FixedWidthSmall { get; set; }

        [JsonProperty("fixed_width_small_still")]
        public FixedWidthSmallStill FixedWidthSmallStill { get; set; }

        [JsonProperty("downsized")]
        public Downsized Downsized { get; set; }

        [JsonProperty("downsized_still")]
        public DownsizedStill DownsizedStill { get; set; }

        [JsonProperty("downsized_large")]
        public DownsizedLarge DownsizedLarge { get; set; }

        [JsonProperty("original")]
        public Original Original { get; set; }

        [JsonProperty("original_still")]
        public OriginalStill OriginalStill { get; set; }
    }

    [JsonObject]
    public class FixedHeight
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("mp4")]
        public string Mp4 { get; set; }

        [JsonProperty("mp4_size")]
        public string Mp4Size { get; set; }

        [JsonProperty("webp")]
        public string Webp { get; set; }

        [JsonProperty("webp_size")]
        public string WebpSize { get; set; }
    }

    [JsonObject]
    public class FixedHeightStill
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }

    [JsonObject]
    public class FixedHeightDownsampled
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("webp")]
        public string Webp { get; set; }

        [JsonProperty("webp_size")]
        public string WebpSize { get; set; }
    }

    [JsonObject]
    public class FixedWidth
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("mp4")]
        public string Mp4 { get; set; }

        [JsonProperty("mp4_size")]
        public string Mp4Size { get; set; }

        [JsonProperty("webp")]
        public string Webp { get; set; }

        [JsonProperty("webp_size")]
        public string WebpSize { get; set; }
    }

    [JsonObject]
    public class FixedWidthStill
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }

    [JsonObject]
    public class FixedWidthDownsampled
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("webp")]
        public string Webp { get; set; }

        [JsonProperty("webp_size")]
        public string WebpSize { get; set; }
    }

    [JsonObject]
    public class FixedHeightSmall
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("webp")]
        public string Webp { get; set; }

        [JsonProperty("webp_size")]
        public string WebpSize { get; set; }
    }

    [JsonObject]
    public class FixedHeightSmallStill
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }

    [JsonObject]
    public class FixedWidthSmall
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("webp")]
        public string Webp { get; set; }

        [JsonProperty("webp_size")]
        public string WebpSize { get; set; }
    }

    [JsonObject]
    public class FixedWidthSmallStill
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }

    [JsonObject]
    public class Downsized
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }
    }

    [JsonObject]
    public class DownsizedStill
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }

    [JsonObject]
    public class DownsizedLarge
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }
    }

    [JsonObject]
    public class Original
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("frames")]
        public string Frames { get; set; }

        [JsonProperty("mp4")]
        public string Mp4 { get; set; }

        [JsonProperty("mp4_size")]
        public string Mp4Size { get; set; }

        [JsonProperty("webp")]
        public string Webp { get; set; }

        [JsonProperty("webp_size")]
        public string WebpSize { get; set; }
    }

    [JsonObject]
    public class OriginalStill
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }
}
