using System;
using System.Configuration;

namespace UniQode.Services
{
    public static class AppSettings
    {
        private static string _facebookAppId;
        public static string FacebookAppId
        {
            get
            {
                if (!string.IsNullOrEmpty(_facebookAppId))
                    return _facebookAppId;

                _facebookAppId = Environment.GetEnvironmentVariable("UNIQODEWEB_FACEBOOK_APPID");

                if (string.IsNullOrEmpty(_facebookAppId))
                    _facebookAppId = ConfigurationManager.AppSettings["facebook:AppId"];

                return _facebookAppId;
            }
        } 
    }
}