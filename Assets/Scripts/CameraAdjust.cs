using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于自适应， 只对正交相机有用， 权重是 宽度
/// </summary>
public class CameraAdjust : MonoBehaviour
{
    public float initOrthoSize, initWidth, initHeight;
    private float factOrthSize, factWidth, factHeight;

    private void Update()
    {
        factWidth = Screen.width;
        factHeight = Screen.height;
        factOrthSize = (initOrthoSize * (initWidth / initHeight)) / (factWidth / factHeight);
        GetComponent<Camera>().orthographicSize = factOrthSize;
    }

}
