using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// Add this as a component to any of the "tv" objects to be able to fetch an online image and display it on the screen

public class WebImageOnScreen : MonoBehaviour
{
    public string imageUrl = "https://example.org/static/test.jpg";
    public Renderer targetRenderer; // put the same tv screen here when adding the component
    public int materialIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownloadAndApplyTexture());
    }

    IEnumerator DownloadAndApplyTexture()
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Image Download Failed: " + uwr.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
                targetRenderer.materials[materialIndex].mainTexture = texture;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
