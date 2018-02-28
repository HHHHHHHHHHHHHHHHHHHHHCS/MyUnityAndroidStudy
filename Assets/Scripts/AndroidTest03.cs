using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidTest03 : MonoBehaviour
{
    private static int dialogCb = 123;

    class CycClickListener : AndroidJavaProxy
    {

        public CycClickListener() : base("android.content.DialogInterface$OnClickListener") { }
        void onClick(AndroidJavaObject dialogInterface, int arg1)
        {

            Debug.Log("ClickListener ---- arg1:" + arg1);
            dialogCb = arg1;
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(15, 15, 450, 75), "cd:" + dialogCb.ToString()))
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");

            activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject builder = new AndroidJavaObject("android.app.AlertDialog$Builder", activity);
                builder.Call<AndroidJavaObject>("setTitle", "cyc title");
                builder.Call<AndroidJavaObject>("setMessage", "cyc this is test dialog msg");
                builder.Call<AndroidJavaObject>("setPositiveButton", "sure:)", new CycClickListener());

                AndroidJavaObject dialog = builder.Call<AndroidJavaObject>("create");
                dialog.Call("show");

            }));
        }
    }

}
