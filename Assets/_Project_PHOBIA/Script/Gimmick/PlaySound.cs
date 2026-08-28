using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Gimmick<PlayHorrorSE>")]
public class PlaySound : HorrorGimmicks
{
    [SerializeField]
    private AudioSource _source;

    [SerializeField]
    private AudioClip _clip;
    public override void Activate(GameObject trigger)
    {
        //q‚ÌAudio_source‚ğæ“¾‚µ‚Ä–Â‚ç‚·
        _source = trigger.GetComponentInChildren<AudioSource>();@
        _source.PlayOneShot(_clip);
    }
}
