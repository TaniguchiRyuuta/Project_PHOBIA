using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gimmick<SoundLaughter>")]
public class SoundLaughter : HorrorGimmicks
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
