using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DisableIntro : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("DisableIntroCanvas");
    }

    IEnumerator DisableIntroCanvas()
	{
        yield return new WaitForSeconds(6);
        gameObject.SetActive(false);
    }
}
