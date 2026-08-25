using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class ItemHandler : EventBehaviour
    {
        [SerializeField] private ItemData targetItem;
        [SerializeField] private ItemManager IM;
        [SerializeField] private ChangeType changeType;
        public override void OnEvent()
        {
            if(changeType == ChangeType.Add)
            {
                IM.AddItem((int)targetItem);
            }
            if(changeType == ChangeType.Remove)
            {
                IM.RemoveItem((int)targetItem);
            }
            
        }

        enum ChangeType
        {
            Add,
            Remove,
        }
    }
}