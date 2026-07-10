using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gimmick<DoorOpen>")]
public class DoorOpen : HorrorGimmicks
{
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip clip;
    public override void Activate(GameObject trigger)
    {
        source.PlayOneShot(clip);
    }
}
