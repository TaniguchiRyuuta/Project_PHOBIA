using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gimmick<SoundFootsteps>")]
public class SoundFootsteps : HorrorGimmicks
{
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip clip;
    public override void Activate()
    {
        source.PlayOneShot(clip);
    }
}
