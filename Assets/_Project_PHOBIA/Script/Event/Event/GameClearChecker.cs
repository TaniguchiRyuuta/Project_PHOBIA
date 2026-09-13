using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class GameClearChecker : EventBehaviour
    {
        [SerializeField] ItemManager IM;
        //エンディング用のboolを参照
        public override void OnEvent()
        {
            if(IM.ContainsItem(ItemData.Phone)&&IM.ContainsItem(ItemData.Key))
            {
                Debug.Log("[GameClearChecker] gameClear");
                //エンディング用のboolをtrue
            }
        }
    }
}

