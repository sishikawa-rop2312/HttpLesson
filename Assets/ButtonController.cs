using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class ButtonController : MonoBehaviour
{
    public TMP_InputField inputX;
    public TMP_InputField inputY;
    public TextMeshProUGUI result;

    public void CalcNumber()
    {
        StartCoroutine(PostRequest());
    }

    IEnumerator PostRequest()
    {
        string uri = "https://joytas.net/php/calc.php";
        WWWForm form = new WWWForm();
        form.AddField("x", inputX.text);
        form.AddField("y", inputY.text);
        using (UnityWebRequest uwr = UnityWebRequest.Post(uri, form))
        {
            yield return uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                result.text = uwr.downloadHandler.text;
            }
        }
    }
}
