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

                try
                {
                    _facebookAppId = Environment.GetEnvironmentVariable("UNIQODEWEB_FACEBOOK_APPID");
                }
                catch (Exception)
                {
                    //suppress
                }

                try
                {
                    if (string.IsNullOrEmpty(_facebookAppId))
                        _facebookAppId = ConfigurationManager.AppSettings["facebook:AppId"];
                }
                catch (Exception)
                {
                    //suppress
                }

                return _facebookAppId;
            }
        }

        private static string _googleApiKey;

        public static string GoogleApiKey
        {
            get
            {
                if (!string.IsNullOrEmpty(_googleApiKey))
                    return _googleApiKey;

                try
                {
                    _googleApiKey = Environment.GetEnvironmentVariable("UNIQODEWEB_GOOGLE_APIKEY");
                }
                catch (Exception)
                {
                    //suppress
                }

                try
                {
                    if (string.IsNullOrEmpty(_googleApiKey))
                        _googleApiKey = ConfigurationManager.AppSettings["google:ApiKey"];
                }
                catch (Exception)
                {
                    //suppress
                }

                return _googleApiKey;
            }
        }
    }
}