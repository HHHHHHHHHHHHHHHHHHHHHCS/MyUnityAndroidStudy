using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidTest01 : MonoBehaviour
{

    public Text text;

	void Start ()
    {
        //获得包名
        AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //获得ajc所代表的类下面的对象
        AndroidJavaObject ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");
        text.text = ajo.Call<double>("Add", 1.1d, 2.2d).ToString();

	}


}
