using Meta.XR.Acoustics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class ObjectSwitch : EventBehaviour
    {
        [SerializeField] private GameObject[] targets;
        [SerializeField] private ForceType forceType;
        [SerializeField] private bool onlyOnce = false;

        public override void OnEvent()
        {
            foreach (var target in targets)
                if (target)
                    target.SetActive(ConvertSwitch(target));
            if(onlyOnce) enabled = false;
        }

        enum ForceType
        {
            None,
            True,
            False,
        }
        bool ConvertSwitch(GameObject target)
        {
            if (forceType == ForceType.True) return true;
            else if (forceType == ForceType.False) return false;
            else if (forceType == ForceType.None)
            {
                return !target.activeSelf;
            }
            return false;
        }
    }
}