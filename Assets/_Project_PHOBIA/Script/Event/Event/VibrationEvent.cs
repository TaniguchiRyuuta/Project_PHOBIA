using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Haptics;

namespace PJ_PHOBIA
{
    public class VibrationEvent : EventBehaviour
    {
        [SerializeField] private HapticClip clip;
        [SerializeField] private VibrationPoint vibPoint;
        [SerializeField] private bool isInputAction = false;
        private HapticClipPlayer player;

        public override void OnEvent()
        {
            if (isInputAction) return;
            player = new HapticClipPlayer(clip);
            OnVibreation(vibPoint);
        }
        public override void OnInputAction(InputButton state)
        {
            if(!isInputAction) return;
            Debug.Log("[VibrationEvent] InputAction");
            switch (state)
            {
                case InputButton.PrimaryHandTriggerDown:
                    OnVibreation(VibrationPoint.Left);
                    break;
                case InputButton.SecondaryHandTriggerDown:
                    OnVibreation(VibrationPoint.Right);
                    break;
                default:
                    break;
            }
        }

        private void OnVibreation(VibrationPoint hand)
        {
            switch(hand)
            {
                case VibrationPoint.Both:
                    player.Play(Controller.Both); 
                    break;
                case VibrationPoint.Left:
                    player.Play(Controller.Left);
                    break;
                case VibrationPoint.Right:
                    player.Play(Controller.Right);
                    break;
            }
        }
        enum VibrationPoint
        {
            Both,
            Left,
            Right,
        }
    }
}

