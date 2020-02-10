using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ERPProject.Infrastructure
{
    public class UserDataModel
    {

        public string UserName { get; set; }

        public DateTime YearStart { get; set; }
        public DateTime YearEnd { get; set; }

        public UserDataModel()
        {

        }

        public UserDataModel(int Userid, string username, DateTime yearStart, DateTime yearEnd)
        {
            UserName = username;
            YearStart = yearStart;
            YearEnd = yearEnd;

        }

        public string ToJson()
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                 DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateParseHandling = DateParseHandling.DateTimeOffset,
                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind
            };

            string json = JsonConvert.SerializeObject(this, jsonSerializerSettings);
            return json; 
        }

        public static UserDataModel CreateUserData(string userData)
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };

            UserDataModel userModel = JsonConvert.DeserializeObject<UserDataModel>(userData, jsonSerializerSettings);
            return userModel;
        }
        
    }
}