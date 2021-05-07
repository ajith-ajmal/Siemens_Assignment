using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Siemens.DataIngestion.BackgroundJob.Helper
{
   public class Deserialize<T>
    {
        public static T ToModel(string path)
        {
            return JsonConvert.DeserializeObject<T>(ReadDataTostring(path));
        }

        #region <<Private helper methods>>

        private static string ReadDataTostring(string path)
        {
           string data= File.ReadAllText(path);
            return data;
        }

        #endregion
    }
}
