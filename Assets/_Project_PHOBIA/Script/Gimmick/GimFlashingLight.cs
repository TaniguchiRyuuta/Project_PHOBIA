using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Gimmick<FlashingLight>")]
public class GimFlashingLight :HorrorGimmicks
{
    public override void Activate(GameObject trigger)
    {
        trigger.GetComponent<FlashingL>().FlashingLight();
    }
}
