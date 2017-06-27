using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// karol@4experience.co
// core controller of the app
public class AppController : MonoBehaviour
{

    // simple event
    public System.Action onInitialized = delegate { };

    // half singleton
    public static AppController Instance { get; private set; }
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    // Use this for initialization
    void Start()
    {
        //
        LoadSetup();
    }

    //
    void LoadSetup()
    {
        #if LOG_ENGINE
        Debug.Log("AppController : Load Specific Setup");
        #endif

        //
        StartCoroutine(LoadSetupCoroutine());
    }

    //
    IEnumerator LoadSetupCoroutine()
    {

        #if LOG_ENGINE
        Debug.Log("AppController : Load Async Setup");
        #endif

        // TU POWINNO SIE CALY ASYNC TRZYMAC W LADOWANIU

        yield return new WaitForEndOfFrame();
        // 
        OnInitialized();

        #if LOG_ENGINE
        Debug.Log("AppController : Load Menu Scene");
        #endif

        SceneLoadingController.Instance.LoadScene(GameScene.Menu, false);
    }

    //
    void OnInitialized()
    {
        #if LOG_ENGINE
        Debug.Log("AppController : Call OnInitialized Event");
        #endif

        onInitialized();
    }
}
