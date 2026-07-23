using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Gimmick<ChangeTexture>")]
public class ChangeTexture : HorrorGimmicks
{
    [SerializeField] Material hMaterial;
    public override void Activate(GameObject trigger)
    {
        trigger.GetComponentInParent<MeshRenderer>().material = hMaterial;
    }
}
