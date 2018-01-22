using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurumsalProjem.Northwind.MvcWebUI.ExtensionMethods
{
    public static class SessionExtensionMethods
    {
        //sessiona değer ataması yapıyoruz
        public static void SetObject(this ISession session,string key,object value)
        {
            //gelen value object tipinde, burada valuenın string versiyonunu elde ediyoruz.
            string objectString = JsonConvert.SerializeObject(value);
            //burada yeni bir session oluşturuyoruz.Değer ataması yapıyoruz
            session.SetString(key,objectString);
        }

        //sessiondan veri çekiyoruz
        public static T GetObject<T>(this ISession session,string key) where T:class{

            //gelen key değerinin string karşılığını verir
            string objectString = session.GetString(key);

            //sessionun dolumu boşmu olduğunu kontrol ediyoruz.Eğer boşsa null değer dönüyor.
            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }
            //string karşılığı alınan değeri gelen nesne tipine çevirir.
            T value = JsonConvert.DeserializeObject<T>(objectString);
            return value;
        }
    }
}
