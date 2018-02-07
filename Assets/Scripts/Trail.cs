using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trail : MonoBehaviour
{
    public GameObject trailPrefab;
    public Text text;
    private Transform markTS;


    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t0 = Input.touches[0];
            switch (t0.phase)
            {
                //当手指刚按下的时候，对应的Touch 对象的状态是Began
                case TouchPhase.Began:
                    if (markTS)
                    {
                        Destroy(markTS.gameObject);
                    }
                    //position是手指所对应屏幕的实时坐标
                    //rawPosition是手指所对应屏幕的 初始坐标，即刚按下的时候
                    markTS = Instantiate(trailPrefab, Camera.main.ScreenToWorldPoint(new Vector3(t0.position.x, t0.position.y, 10)), Quaternion.identity).transform;
                    break;
                //手指移动
                case TouchPhase.Moved:
                    markTS.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(t0.position.x, t0.position.y, 10));
                    break;
                //当手指按住不动的时候
                case TouchPhase.Stationary:
                    markTS.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(t0.position.x, t0.position.y, 10));
                    break;
                //当手指离开屏幕的时候
                case TouchPhase.Ended:
                    {
                        Vector2 endPos = t0.position;
                        Vector2 dir = endPos - t0.rawPosition;
                        if(Mathf.Abs(dir.magnitude)>1f)
                        {
                            text.text = dir.ToString();
                        }
                        else
                        {
                            text.text = "Stand";
                        }
                        Destroy(markTS.gameObject);
                        break;
                    }

                //当手指因为某些原因出现问题的时候，多半是系统原因，取消对某个手指的追踪
                case TouchPhase.Canceled:
                    {
                        Vector2 endPos = t0.position;
                        Vector2 dir = endPos - t0.rawPosition;
                        if (Mathf.Abs(dir.magnitude) > 1f)
                        {
                            text.text = dir.ToString();
                        }
                        else
                        {
                            text.text = "Stand";
                        }
                        Destroy(markTS.gameObject);
                        break;
                    }
                default:
                    break;
            }
        }
    }
}