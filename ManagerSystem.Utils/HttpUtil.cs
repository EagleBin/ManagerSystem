using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace ManagerSystem.Utils
{
    /// <summary>
    /// Http访问
    /// </summary>
    public class HttpUtil
    {
        // 请求的基础 URL
        //private static string absoluteUrl = "http://localhost:44304/";
        private static string absoluteUrl = "http://localhost:35779/";

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="url">请求的相对路径</param>
        /// <param name="parameters">包含请求参数的字典</param>
        /// <returns></returns>
        public static string Get(string url, Dictionary<string, object> parameters)
        {
            try
            {
                // 将参数拼接成查询字符串 p
                string p = string.Empty;
                if (parameters!=null && parameters.Count>0)
                {
                    foreach (var item in parameters)
                    {
                        if (item.Value != null)
                        {
                            p += $"{item.Key}={item.Value}&";
                        }
                    }

                }
                // 去除末尾的 & 符号
                if (!string.IsNullOrEmpty(p))
                {
                    p = p.TrimEnd('&');
                }
                var httpClient = new HttpClient();
                // 使用 GetAsync 方法发送 GET 请求，并等待响应。
                var response = httpClient.GetAsync($"{absoluteUrl}{url}?{p}",HttpCompletionOption.ResponseContentRead).Result;
                string strJson = response.Content.ReadAsStringAsync().Result;
                return strJson;
            }
            catch (HttpListenerException ex)
            {
                return $"HTTP 请求出错：{ex.Message}";
            }
            catch (Exception ex)
            {
                return $"发生未知错误：{ex.Message}";
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string Delete(string url, Dictionary<string, string> parameters)
        {
            try
            {
                string p = string.Empty ;
                if (parameters!= null && parameters.Count > 0)
                {
                    foreach (var item in parameters)
                    {
                        if (item.Value!=null)
                        {
                            p += $"{item.Key}={item.Value}&";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(p))
                {
                    p = p.TrimEnd('&');
                }

                var httpClient = new HttpClient ();
                var response = httpClient.DeleteAsync($"{absoluteUrl}{url}?{p}").Result;
                var strJson = response.Content.ReadAsStringAsync().Result;
                return strJson;
            }
            catch (HttpListenerException ex)
            {
                return $"HTTP 请求出错：{ex.Message}";
            }
            catch (Exception ex)
            {
                return $"发生未知错误：{ex.Message}";
            }

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string Put<T>(string url, T t)
        {
            try
            {
                // 序列化
                var content = JsonConvert.SerializeObject(t);

                var httpContent = new StringContent(content, Encoding.UTF8, "application/Json");
                var httpClient = new HttpClient();
                var response = httpClient.PutAsync($"{absoluteUrl}{url}", httpContent).Result;
                var strJson = response.Content.ReadAsStringAsync().Result;
                return strJson;
            }
            catch (HttpListenerException ex)
            {
                return $"HTTP 请求出错：{ex.Message}";
            }
            catch (Exception ex)
            {
                return $"发生未知错误：{ex.Message}";
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public static string Post<T>(string url, T t)
        {
            try
            {
                string content = JsonConvert.SerializeObject(t);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/Json");
                var httpClient = new HttpClient();
                var response = httpClient.PostAsync($"{absoluteUrl}{url}",httpContent).Result;
                var strJson = response.Content.ReadAsStringAsync().Result;
                return strJson;
            }
            catch (HttpListenerException ex)
            {
                return $"HTTP 请求出错：{ex.Message}";
            }
            catch (Exception ex)
            {
                return $"发生未知错误：{ex.Message}";
            }
        }

        /// <summary>
        /// 反序列化（字符串转对象）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T StrToObject<T>(string str)
        {

            var t = JsonConvert.DeserializeObject<T>(str);
            return t;

        }

    }
}
