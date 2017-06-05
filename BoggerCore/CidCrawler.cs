using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BoggerCore
{
    public class CidCrawler
    {
        public async Task<string> GetVideoContentId(string avId)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://www.bilibili.com/video/"),
            };
            
            // Force using Internet Explorer 10's user agent to get the flash version instead of HTML5 version
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (MSIE 10.0; Windows NT 6.1; Trident/5.0)");

            // Get the HTML string
            string rawHtml = await httpClient.GetStringAsync(avId);
            string htmlLineBuffer = string.Empty;
            
            // Find out the line with these contents:
            // <script type='text/javascript'>EmbedPlayer('player', "//static.hdslb.com/play.swf", "cid=15430504&aid=9337458&pre_ad=0");</script>
            var stringReader = new StringReader(rawHtml);
            string cidStr = string.Empty;
            while ((htmlLineBuffer = stringReader.ReadLine()) != null)
            {
                if (htmlLineBuffer.Contains("cid") && htmlLineBuffer.Contains("swf"))
                {
                    cidStr = htmlLineBuffer.Split('\"')[3] // Get "cid=15430504&aid=9337458&pre_ad=0"
                        .Split('&')[0]                     // Get "cid=15430504"
                        .Split('=')[1];                    // Get "1543054"
                    
                    stringReader.Dispose();
                    
                    return cidStr;
                }
            }

            // If CID not found, return an empty string.
            stringReader.Dispose();
            return cidStr;
        }
    }
}