using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] RawImage rawimage;
    [SerializeField] AudioClip[] audioClip;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        StartCoroutine(GetTextures("https://www.opinionnews.co.kr/news/photo/201701/5161_3322_21.jpg"));
    }

    public void Search()
    {
        GameObject objectSearched = GameObject.Find("Drone");
        objectSearched.transform.GetChild(0).gameObject.SetActive(true);
        AudioSource.PlayClipAtPoint(audioClip[0],objectSearched.transform.position);
    }

    public void Signal()
    {
        audioSource.PlayOneShot(audioClip[1]);
    }

    IEnumerator GetTextures(string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            rawimage.texture = texture;
        }
    }
}
