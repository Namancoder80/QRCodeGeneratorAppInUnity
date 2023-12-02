using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class qrcodeGenerator : MonoBehaviour
{
    [SerializeField] private RawImage qrCode ;
    [SerializeField] private TMP_InputField qrLink;
    [SerializeField] private Button generateQrCode;
    void Start()
    {
        generateQrCode.onClick.AddListener(()=>{
            StartCoroutine(loadQrCode(GenerateLink));
        });
    }

    IEnumerator loadQrCode(string Api){
        UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(Api);
        yield return unityWebRequest.SendWebRequest();

        qrCode.texture= DownloadHandlerTexture.GetContent(unityWebRequest);
    }

    private string GenerateLink{
        get{
            string qrApi ="https://api.qrserver.com/v1/create-qr-code/?size=150x150&data="+qrLink.text;
            return qrApi;
        }      
    }
}
