using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatDelay : MonoBehaviour
{
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip clip2;

    private void Start()
    {
        source = GetComponentInChildren<AudioSource>();
    }

    public void CorStart()
    {
        StartCoroutine(DelayAndPlay());
    }

    private IEnumerator DelayAndPlay()
    {
        yield return new WaitForSeconds(2);
        source.PlayOneShot(clip2);
        yield break;
    }
}
