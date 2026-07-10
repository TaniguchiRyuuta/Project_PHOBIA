using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SoundRat")]
public class SoundRat : HorrorGimmicks
{
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip clip1;
    [SerializeField]
    AudioClip clip2;
    public override void Activate(GameObject trigger)
    {
        source.PlayOneShot(clip1);
        trigger.GetComponent<RatDelay>().CorStart();
    }
}
