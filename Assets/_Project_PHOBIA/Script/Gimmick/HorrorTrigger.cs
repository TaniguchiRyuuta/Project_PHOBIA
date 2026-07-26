using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorTrigger : MonoBehaviour
{
    [SerializeField]
    private HorrorGimmicks horrorGimmicks;
    [SerializeField]
    private bool onece = true;

    private bool activated;

    private void OnTriggerEnter(Collider other)
    {
        //activatedフラグtureの場合return(onceのtrueをInspectorで切っておけば何回でもならせる
        if(onece && activated)
        {
            return;
        }

        //tagがPlayerじゃなかったらreturn
        if (!other.CompareTag("Player")) 
        {
            return;
        }

        horrorGimmicks.Activate(gameObject); //ギミック発動

        activated = true;
    }
}
