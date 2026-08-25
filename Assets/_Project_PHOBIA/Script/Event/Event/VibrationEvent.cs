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
        private HapticClipPlayer player;

        public override void OnEvent()
        {
            player = new HapticClipPlayer(clip);
            OnVibreation();
        }
        public override void OnInputAction(InputButton state)
        {
            if (InputButton.PrimaryIndexTrigger != state ||
                InputButton.PrimaryHandTrigger!=state) return;
            player.Play(Controller.Left);
        }

        private void OnVibreation()
        {
            switch(vibPoint)
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

