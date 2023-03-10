﻿using BrokersPortalsV1.Enum;
using BrokersPortalsV1.Session;
using Newtonsoft.Json;
using System.Data;

namespace BrokersPortalsV1.Class
{
    public class Base64
    {

        //encoding
        public  string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        //decoding
        public  string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }
}
