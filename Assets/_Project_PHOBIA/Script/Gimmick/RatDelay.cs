using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatDelay : MonoBehaviour
{
    [SerializeField]
    AudioSource _source;
    [SerializeField]
    AudioClip _clip2;

    private void Start()
    {
        _source = GetComponentInChildren<AudioSource>();
    }

    public void CorStart()
    {
        StartCoroutine(DelayAndPlay());
    }

    private IEnumerator DelayAndPlay()
    {
        yield return new WaitForSeconds(2);　//2秒待つ
        _source.PlayOneShot(_clip2);　　　　　 //2秒後にならす
        yield break;
    }
}
