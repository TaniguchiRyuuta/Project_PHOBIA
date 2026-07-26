using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Gimmick<SoundRat>")]
public class SoundRat : HorrorGimmicks
{
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip clip1;
    public override void Activate(GameObject trigger)
    {
        source = trigger.GetComponentInChildren<AudioSource>(); //子についてるAudioSource取得
        source.PlayOneShot(clip1);
        trigger.GetComponent<RatDelay>().CorStart();　　　　　　//RatDelayのコルーチンスタート
    }
}
