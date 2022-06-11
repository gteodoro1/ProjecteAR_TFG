using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public event Action OnMainMenu;
    public event Action OnItemsMenu;
    public event Action OnARPosition;

    public static GameManager instance;

    private void Awake()
    {
        if(instance!= null && instance != this)
        {
            Destroy(gameObject);
        }
        else {
            instance=this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MainMenu();
    }

    // Update is called once per frame
    public void MainMenu(){
        OnMainMenu?.Invoke();
        Debug.Log("Main menu activated");
    }

    public void ItemsMenu(){
        OnItemsMenu?.Invoke();
        Debug.Log("Items menu activated");
    }
    public void ARPosition(){
        OnARPosition?.Invoke();
        Debug.Log("AR position a activated");
    }
    public void CloseAPP(){
        Application.Quit();
    }
}
