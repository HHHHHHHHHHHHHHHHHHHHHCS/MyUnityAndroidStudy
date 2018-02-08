using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoblieInputTest : MonoBehaviour
{

    private void Update()
    {
        Debug.Log(CrossPlatformInputManager.GetAxis("Horizontal"));
    }
}
