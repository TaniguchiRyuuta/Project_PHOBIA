using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class SwitchFlashLight : EventBehaviour
    {
        [SerializeField] private bool lightSwitch = false;
        [SerializeField] private Light _light;
        [SerializeField] float intensityValue;
        [SerializeField] private float rangeValue;

        private void Start()
        {
            if(!_light) _light = GetComponentInChildren<Light>();

            if (lightSwitch)_light.intensity = intensityValue;
            else _light.intensity = 0f;

            _light.range = rangeValue;
        }
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
                _light.intensity = intensityValue;
                lightSwitch = true;
            }
        }
    }
}
