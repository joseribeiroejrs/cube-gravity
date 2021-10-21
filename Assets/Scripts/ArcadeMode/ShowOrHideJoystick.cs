using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOrHideJoystick : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        #if UNITY_ANDROID
            gameObject.SetActive(true);
        #endif
    }
}
