using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchTest : MonoBehaviour
{
    public Text infoText;

    private void Awake()
    {
        //点击返回键，是否退出游戏 ，默认为false
        //Input.backButtonLeavesApp = true;
    }

    private void Update()
    {
        string info = "";
        //每当一个手指触摸屏幕，则Touch对象加一，故TouchCount++
        if (Input.touchCount > 0)
        {
            //Touch 周期的结束不是手指离开屏幕后立即销毁
            //比如在一个手指在同一个位置快速多次点击
            //则不会销毁，且fingerID 不会变

            //上下两种作用效果一样
            //Touch myTouch0 = Input.GetTouch(0);
            Touch myTouch0 = Input.touches[0];
            //var altitude = myTouch0.altitudeAngle;//手指和屏幕的角度，一般是指以观测者的位置为中心
            //var azimuth = myTouch0.azimuthAngle;//手指和屏幕的方位角，从标准方向的北端起,顺时针方向到直线的水平角
            info += "fingerID : " + myTouch0.fingerId + "\n";//手指的唯一标识
            info += "deltaPosition : " + myTouch0.deltaPosition + "\n";//当前位置与上一次位置差距
            info += "deltaTime : " + myTouch0.deltaTime + "\n";//当前位置与上一次时间差
            info += "tapcount : " + myTouch0.tapCount + "\n";//手指点击屏幕次数
            info += "touchPase : " + myTouch0.phase + "\n";//touch对象最后的阶段
            info += "touchCount : " + Input.touchCount + "\n";//touch 的总数量
        }
        infoText.text = info;
    }
}
