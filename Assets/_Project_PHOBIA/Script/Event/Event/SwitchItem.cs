using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class SwitchItem : EventBehaviour
    {
        [SerializeField] private ItemManager IM;

        public override void OnEvent() { }

        public override void OnInputAction(InputButton state)
        {
            if(state == InputButton.A)
            {
                Debug.Log("[SwitchItem] A Button");
                IM.SwitchItem(1);
            }
            if (state == InputButton.B)
            {
                Debug.Log("[SwitchItem] B Button");
                IM.SwitchItem(-1);
            }
        }
    }
}