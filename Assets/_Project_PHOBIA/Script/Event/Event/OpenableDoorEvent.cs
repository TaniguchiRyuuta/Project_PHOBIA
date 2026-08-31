using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class OpenableDoorEvent : EventBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Transform startPos;
        [SerializeField] private Transform endPos;
        private float posDistance;
        private Transform player = null;

        [SerializeField] private bool isOpen = false;

        private void Awake()
        {
            posDistance = (startPos.position - endPos.position).magnitude;
        }
        public override void OnInputAction(InputButton state)
        {
            if(state == InputButton.PrimaryHandTriggerDown ||
               state == InputButton.SecondaryHandTriggerDown)
            {
                if (!isOpen) { isOpen = true; Debug.Log("[OpenableDoorEvent] isOpen:true"); }
            }
            else if(state == InputButton.PrimaryHandTriggerUp ||
                    state == InputButton.SecondaryHandTriggerUp)
            {
                if (isOpen) { isOpen = false; Debug.Log("[OpenableDoorEvent] isOpen:false"); }
                player = null;
            }
        }

        private void Update()
        {
            if (!isOpen) return;
            OpenDoor();
            
        }
        
        private void OpenDoor()
        {
            Debug.Log("[OpenableDoorEvent] OpenDoor:stop");
            if (player == null) return;
            Debug.Log("[OpenableDoorEvent] OpenDoor:start");
            if (target.position.x <= posDistance && target.position.x >= startPos.position.x)
            {
                var dis = (player.position - startPos.position).magnitude;
                var pos = target.position.x - dis;
                target.position = new Vector3(dis,target.position.y,target.position.z);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Hand"))
            {
                Debug.Log("[OpenableDoorEvent] player");
                    player = other.gameObject.GetComponent<Transform>();
            }
        }
    }
}