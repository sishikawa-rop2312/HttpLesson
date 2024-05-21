using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetRequest("https://joytas.net/php/man.jpg"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                Texture texture = DownloadHandlerTexture.GetContent(uwr);
                Sprite sp = Sprite.Create(
                    (Texture2D)texture,
                    new Rect(0, 0, texture.width, texture.height), // スプライトのサイズ（今回は画像の大きさで設定）
                    new Vector2(0.5f, 0.5f) // 中心点
                );
                Image image = GetComponent<Image>();

                image.rectTransform.sizeDelta = new Vector2(
                    sp.rect.width,
                    sp.rect.height
                );
                image.sprite = sp;
            }
        }
    }
}
