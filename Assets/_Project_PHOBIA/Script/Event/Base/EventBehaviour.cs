using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class EventBehaviour:MonoBehaviour
    {
        public virtual void OnEvent() { }
        public virtual void OnInputAction(InputButton state) { }
        public virtual void OnPlayerTrigger(TriggerState state){ }
    }
}
