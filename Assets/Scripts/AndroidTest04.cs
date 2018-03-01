using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidTest04 : MonoBehaviour
{
    private void Start()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
            toast.CallStatic<AndroidJavaObject>("makeText", context, "Send From Unity", toast.GetStatic<int>("LENGTH_LONG")).Call("show");
        }));
    }
}
