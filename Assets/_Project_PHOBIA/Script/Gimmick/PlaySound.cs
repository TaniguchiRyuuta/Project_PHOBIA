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
        //q‚ÌAudioSource‚ğæ“¾‚µ‚Ä–Â‚ç‚·
        source = trigger.GetComponentInChildren<AudioSource>();@
        source.PlayOneShot(clip);
    }
}
