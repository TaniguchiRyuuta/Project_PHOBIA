using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class InvokeCurrentItemAction : EventBehaviour
    {
        [SerializeField] ItemManager IM;

        public override void OnEvent()
        {
            IM.UseItem(IM.CurrentItemID);
        }
    }
}