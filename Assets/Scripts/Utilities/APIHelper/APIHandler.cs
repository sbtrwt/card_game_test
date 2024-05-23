using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace CardGame.Utilities.APIHelper
{
    public static class APIHandler
    {
        static public IEnumerator GetRequest(string url, Action<string> callback)
        {
            using UnityWebRequest webRequest = UnityWebRequest.Get(url);
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(string.Format("Connection error found : {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    callback(webRequest.downloadHandler.text);
                    break;

            }
        }

        static public IEnumerator PostRequest(string url, WWWForm form, Action<string> callback)
        {
            using UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(string.Format("Connection error found : {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    callback(webRequest.downloadHandler.text);
                    break;

            }
        }
    }
}
