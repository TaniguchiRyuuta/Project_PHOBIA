using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gimmick<DoorOpen>")]
public class DoorOpen : HorrorGimmicks
{
    [SerializeField]
    private AudioSource _source;

    [SerializeField]
    private AudioClip _clip;
    public override void Activate(GameObject trigger)
    {
        _source = trigger.GetComponentInChildren<AudioSource>();
        _source.PlayOneShot(_clip);
    }
}
