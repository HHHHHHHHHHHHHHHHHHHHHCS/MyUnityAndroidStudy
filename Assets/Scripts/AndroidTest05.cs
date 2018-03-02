using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidTest05 : MonoBehaviour
{
    private static System.DateTime selectedDate = System.DateTime.Now;

    [SerializeField]
    private Text text;

    private class DateCallBack : AndroidJavaProxy
    {
        private Text text;

        //接口不能用.  要用$
        public DateCallBack(Text t) : base("android.app.DatePickerDialog$OnDateSetListener")
        {
            text = t;
        }

        private void onDateSet(AndroidJavaObject view, int year, int month, int dayOfoMonth)
        {
            text.color = Color.red;
            //这里的月份要重新加一
            text.text = string.Format("{0}/{1}/{2}", year, month+1, dayOfoMonth);
        }
    }

    private void Start()
    {
        AndroidJavaObject currentActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
            .GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            new AndroidJavaObject("android.app.DatePickerDialog", currentActivity
                , new DateCallBack(text), selectedDate.Year, selectedDate.Month-1, selectedDate.Day).Call("show");
        }));
    }
}
