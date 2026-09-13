using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnActionTutorial : MonoBehaviour
{
    [SerializeField] StartAndTutorial tutorialManager;
    private bool doOnce = true;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("コライダーイン！");
        //Playerじゃなかったらreturn
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (doOnce)
        {
            tutorialManager._isActionTutorial = true;　　//インタラクトアクションのチュートリアル開始
            doOnce = false;
        }
    }
}
