using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class SwitchFlashLight : EventBehaviour
    {
        [SerializeField] bool lightSwitch = false;
        [SerializeField] Light _light;
        public override void OnEvent()
        {
            if(lightSwitch)
            {
                Debug.Log("Light:Off");
                _light.intensity = 0f;
                lightSwitch = false;
            }
            else
            {
                Debug.Log("Light:On");
                _light.intensity = 1f;
                lightSwitch = true;
            }
        }
    }
}
