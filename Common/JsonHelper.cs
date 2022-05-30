using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
#pragma warning disable 0436
namespace Common
{
    /// <summary>
    /// json 解析 序列 类
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// 解析json 返回dict对象
        /// </summary>
        /// <param name="jsonstr"></param>
        /// <returns></returns>
        public static Dictionary<string, object> DeserializeObject(string jsonstr)
        {
            List<object> list = new List<object>();
            
                if (!string.IsNullOrEmpty(jsonstr))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    object d = jss.DeserializeObject(jsonstr);
                    return (Dictionary<string, object>)d;
                }
          
            return null;

        }

        /// <summary>
        ///  解析json 返回object 数组
        /// </summary>
        /// <param name="jsonstr"></param>
        /// <returns></returns>
        public static object[] Deserialize(string jsonstr)
        {
            
                if (!string.IsNullOrEmpty(jsonstr))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    object d = jss.DeserializeObject(jsonstr);
                    return (object[])d;
                }
          
            return null;

        }

        /// <summary>
        /// 解析json 返回对应的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonstr"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string jsonstr)
        {
           
                if (!string.IsNullOrEmpty(jsonstr))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    return jss.Deserialize<T>(jsonstr);
                }
          
            return default(T);
        }

        /// <summary>
        /// 将类序列化成 字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            
                JavaScriptSerializer jss = new JavaScriptSerializer();
                return jss.Serialize(obj);
            
        }
    }
}
