using System.IO;
using System.Net;

namespace Checkpoint4_V2
{
    public class NancyRequest
    {
        string NancyEntryPoint { get => @"http://localhost:1234/"; }

        public string ExecuteRequest(string path, string method)
        {
            string filepath = NancyEntryPoint + path;
            WebRequest request = WebRequest.Create(filepath);
            request.Method = method;
            request.ContentLength = 0;
            request.ContentType = "application/xml";
            WebResponse httpResponse = request.GetResponse();
            string response = ((HttpWebResponse)httpResponse).StatusDescription;
            using (Stream datastream = httpResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(datastream);
                string answer = reader.ReadToEnd();
                response += answer;
            }
            httpResponse.Close();
            return response;
        }
    }
}
