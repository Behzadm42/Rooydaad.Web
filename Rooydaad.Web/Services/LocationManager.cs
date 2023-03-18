using Rooydaad.Web.Models;
using System.IO;
using System.Net;
using Rooydaad.Web.Models.Json;
using Newtonsoft.Json;


namespace Rooydaad.Web.Services
{
    public interface ILocationManager
    {
        Models.Location GetLocation();
    }
    public class LocationManager : ILocationManager
    {
        public Location GetLocation()
        {
            string url1 = "https://de.proxyarab.com/index.php?q=m6rXoZ5nkZfSyo_Vpp6hkNOh1qCX21-hqJtknquqkdSirZGb16fQ";

            HttpWebRequest request =(HttpWebRequest) HttpWebRequest.Create(url1);
            var response=request.GetResponse();
            var stream=response.GetResponseStream();
            StreamReader streamReader=new StreamReader(stream);
            string jsonstring=streamReader.ReadToEnd();
            LocationModel model=JsonConvert.DeserializeObject<LocationModel>(jsonstring);
            Location result=new Location() { Lat=model.IssPosition.Latitude, Long=model.IssPosition.Longitude};
            return result;
        }
    }
}
