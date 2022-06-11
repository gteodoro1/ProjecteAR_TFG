using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;


public class ItemButtonManager : MonoBehaviour
{

    private string itemName;
    private string itemDescription;
    private Sprite itemImage;
    private GameObject item3DModel;
    private ARInteractionsManager interactionsManager;
    private string urlBundleModel;
    private RawImage imageBundle;

    public string ItemName
    {
        set{
            itemName=value;
        }

    }
   
    
    public string ItemDescription{ set => itemDescription=value;}

    public Sprite ItemImage{ set => itemImage=value;}

    public GameObject Item3DModel { set => item3DModel=value;}

    public string URLBundleModel { set => urlBundleModel = value; }

    public RawImage ImageBundle { get => imageBundle; set => imageBundle = value; }
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemName;
        //transform.GetChild(1).GetComponent<RawImage>().texture=itemImage.texture;
        imageBundle = transform.GetChild(1).GetComponent<RawImage>();

        var d=transform.GetChild(2);
        var e=d.GetComponent<TextMeshPro>();
        if (e!=null){
        var f=e.text;
        f=itemDescription;
        }

        var button= GetComponent <Button>();
        button.onClick.AddListener(GameManager.instance.ARPosition);
        button.onClick.AddListener(Create3DModel);
        interactionsManager = FindObjectOfType <ARInteractionsManager>();

    }

    private void Create3DModel(){
        StartCoroutine(DownLoadAssetBundle(urlBundleModel));
       //interactionsManager.Item3DModel= Instantiate (item3DModel);
    }
    IEnumerator DownLoadAssetBundle(string urlAssetBundle)
    {
        UnityWebRequest serverRequest = UnityWebRequestAssetBundle.GetAssetBundle(urlAssetBundle);
        yield return serverRequest.SendWebRequest();
        if (serverRequest.result == UnityWebRequest.Result.Success) 
        {
            AssetBundle model3D = DownloadHandlerAssetBundle.GetContent(serverRequest);
            if (model3D != null)
            {
                interactionsManager.Item3DModel = Instantiate(model3D.LoadAsset(model3D.GetAllAssetNames()[0]) as GameObject);
            }
            else
            {
                Debug.Log("Not valid");
            }
        }
        else
        {
            Debug.Log("error");
        }
    }
    
}
