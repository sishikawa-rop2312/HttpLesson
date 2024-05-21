using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        // URLを指定してコルーチンを開始
        StartCoroutine(GetRequest("https://joytas.net/php/hello.php"));
    }

    IEnumerator GetRequest(string uri)
    {
        // UnityWebRequestを使用してGETリクエストを作成
        using (UnityWebRequest urw = UnityWebRequest.Get(uri))
        {
            // リクエストを送信して待機
            yield return urw.SendWebRequest();

            // エラー
            if (urw.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(urw.error);
            }
            // 成功
            else
            {
                Debug.Log(urw.downloadHandler);
                Debug.Log(urw.downloadHandler.text);
            }
        }
    }
}
