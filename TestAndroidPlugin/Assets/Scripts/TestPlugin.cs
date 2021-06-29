using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlugin : MonoBehaviour
{
    public GameObject txt;
    private AndroidJavaClass plugin;
    AndroidJavaClass unityClass;
    AndroidJavaObject unityActivity;
    AndroidJavaObject _pluginInstance;


    // Start is called before the first frame update

    void Start()
    {
        InitializePlugin("com.example.battery.PluginJavaLibrary");       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializePlugin(string pluginName)
    {
        unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        _pluginInstance = new AndroidJavaObject(pluginName);
        if(_pluginInstance == null)
        {
            Debug.Log("Plugin Instance Error");
        }
        _pluginInstance.CallStatic("receiveUnityActivity", unityActivity);
    }    

    public void Toast()
    {
        if(_pluginInstance != null )
        {
            Debug.Log("Chamando toast");
            _pluginInstance.Call("Toast", "HI HI HI HI");
        }
    }

    public void GetBattery()
    {
        if (_pluginInstance != null)
        {
            Debug.Log("Chamando battery");
            txt.GetComponent<Text>().text = _pluginInstance.Call<float>("getBatteryPct").ToString();
        }
    }
}
