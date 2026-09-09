using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class OpenableDoorEvent : EventBehaviour
    {
        [SerializeField] private Transform pivot;
        [SerializeField] private Transform target;
        [SerializeField] private Transform startPos;
        [SerializeField] private Transform endPos;
        private Transform player = null;

        private Vector3 start;
        private Vector3 direction;
        private float length;

        [SerializeField] private bool isOpen = false;

        private void Awake()
        {
            start = startPos.localPosition;

            var end = endPos.localPosition;

            var startToEnd = end - start;

            length = startToEnd.magnitude;

            direction = startToEnd.normalized;
        }
        public override void OnInputAction(InputButton state)
        {
            Debug.Log("[OpenableDoorEvent] InputAction");
            if(state == InputButton.PrimaryHandTriggerDown ||
               state == InputButton.SecondaryHandTriggerDown)
            {
                if (!isOpen) { isOpen = true; Debug.Log("[OpenableDoorEvent] isOpen:true"); }
            }
            else if(state == InputButton.PrimaryHandTriggerUp ||
                    state == InputButton.SecondaryHandTriggerUp)
            {
                if (isOpen) { isOpen = false; Debug.Log("[OpenableDoorEvent] isOpen:false"); }
            }
        }

        private void Update()
        {
            OpenDoor();
        }
        
        private void OpenDoor()
        {

            Debug.Log("[OpenableDoorEvent] OpenDoor:stop");

            if (player == null) return;
            if(!isOpen) return;
            Debug.Log("[OpenableDoorEvent] OpenDoor:start");

            var playerLocalPos = pivot.InverseTransformPoint(player.position);

            var startToPlayer = playerLocalPos - start;

            var distanceAlongAxis = Vector3.Dot(startToPlayer, direction);

            distanceAlongAxis = Mathf.Clamp(distanceAlongAxis, 0f, length);

            float t = distanceAlongAxis/length;
            
            target.localPosition = Vector3.Lerp(startPos.localPosition, endPos.localPosition, t);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Hand"))
            {
                Debug.Log("[OpenableDoorEvent] player");
                    player = other.gameObject.GetComponent<Transform>();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Hand"))
            {
                player = null;
                isOpen = false;
            }
        }
    }
}