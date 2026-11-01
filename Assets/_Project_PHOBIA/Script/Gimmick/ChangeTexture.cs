using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Gimmick<ChangeTexture>")]
public class ChangeTexture : HorrorGimmicks
{
    [SerializeField] Material _hMaterial;
    private AudioSource _audioSource;
    [SerializeField] private float _pitch;
    [SerializeField] AudioClip _clip;
    public override void Activate(GameObject trigger)
    {
        trigger.GetComponentInParent<MeshRenderer>().material = _hMaterial;
        _audioSource = trigger.GetComponentInChildren<AudioSource>();
        _audioSource.pitch = _pitch;                                       //ピッチ変更
        _audioSource.PlayOneShot(_clip);
    }
}
