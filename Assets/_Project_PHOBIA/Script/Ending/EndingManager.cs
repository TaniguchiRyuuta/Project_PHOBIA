using PJ_PHOBIA;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : EventBehaviour
{
    [SerializeField] GameObject _creditText; //クレジット表記
    [SerializeField] Collider _endCol;
    public bool isGameClear { get; private set; }
    
    void Start()
    {
        isGameClear = false;
        _creditText.SetActive(false);
        _endCol.enabled = false;
    }

    public void GameClear()
    {
        isGameClear = true;
        _creditText.SetActive(true);
        _endCol.enabled = true;
    }

    public override void OnInputAction(InputButton state)
    {
        if(!isGameClear) return;
        //クリア後、ドアに手をかけた時の最後の処理
        if (isGameClear)
        {
            if (state == InputButton.PrimaryHandTriggerDown || state == InputButton.SecondaryHandTriggerDown)
            {
                SceneManager.LoadScene("Project_PHOBIA");
            }
        }
    }
}
