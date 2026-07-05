using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        if(onece && activated)
        {
            return;
        }

        if (!other.CompareTag("Player"))
        {
            return;
        }

        horrorGimmicks.Activate();

        activated = true;
    }
}
