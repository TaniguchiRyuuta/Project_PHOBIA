using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Gimmick<PlayHorrorSE>")]
public class PlaySound : HorrorGimmicks
{
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip clip;
    public override void Activate(GameObject trigger)
    {
        source = trigger.GetComponentInChildren<AudioSource>();
        source.PlayOneShot(clip);
    }
}
