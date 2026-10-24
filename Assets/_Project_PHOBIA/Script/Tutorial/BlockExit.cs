using PJ_PHOBIA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockExit : MonoBehaviour
{
    [SerializeField] GameObject _blockEventWall;
    [SerializeField] PlayerController _tutoFlag;
    private bool _doOnce;
    private void OnTriggerExit(Collider other)
    {
        //ÉvÉåÉCÉÑÅ[Ç∂Ç·Ç»Ç©Ç¡ÇΩÇÁreturn
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (_doOnce && _tutoFlag._isFinishTutorial)
        {
            _blockEventWall.SetActive(true);
            _doOnce = false;
        }
    }
}
