using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class SoundEffectEvent : EventBehaviour
    {
        [SerializeField] AudioSource source;
        [SerializeField] AudioClip clip;
        public override void OnEvent()
        {
            if(source == null || clip == null)
            {
                Debug.LogError("[SoudEffectEvent] SourceまたはClipがアタッチされていません");
                return;
            }
            source.PlayOneShot(clip);
        }
    }
}