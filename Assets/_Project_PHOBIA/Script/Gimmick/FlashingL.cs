using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingL : MonoBehaviour
{
    [SerializeField] Light playerLight;  //プレイヤーのライトコンポーネント
    [SerializeField] private float intervalTime;  //点滅の間隔

    public void FlashingLight()
    {
        StartCoroutine(Flashing());
    }

    private IEnumerator Flashing()
    {
        //intervalTimeの間隔で、5回点滅させる
        playerLight.enabled = false;
        yield return new WaitForSeconds(intervalTime);
        playerLight.enabled = true;
        yield return new WaitForSeconds(intervalTime);
        playerLight.enabled = false;
        yield return new WaitForSeconds(intervalTime);
        playerLight.enabled = true;
        yield return new WaitForSeconds(intervalTime);
        playerLight.enabled = false;
        yield return new WaitForSeconds(intervalTime);
        playerLight.enabled = true;
    }
}
