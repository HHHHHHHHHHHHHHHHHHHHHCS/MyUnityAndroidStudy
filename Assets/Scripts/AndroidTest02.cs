using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidTest02 : MonoBehaviour
{

    public Text text;

	void Start ()
    {
        //获得类名
        AndroidJavaObject ajo = new AndroidJavaObject("com.hcs.androidstudy01.mylibrarytest02.Test02");
        //调用方法
        text.text = ajo.Call<double>("Add", 2.333d, 3.222d).ToString();
        //调用静态方法
        text.text = ajo.CallStatic<double>("Multiply", 2.333d, 3.222d).ToString();
    }

    public void ChangeColor()
    {
        text.fontSize = 200;
        text.color = Color.black;
    }

}
