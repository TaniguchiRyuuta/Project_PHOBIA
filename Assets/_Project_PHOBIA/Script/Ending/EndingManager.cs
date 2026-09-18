using PJ_PHOBIA;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : EventBehaviour
{
    [SerializeField] GameObject _creditText; 　　//クレジット表記
    [SerializeField] Collider _endCol;　　　　　　//ゲームクリア判定コライダー
    [SerializeField] Transform _centerEyeAnchor;
    [SerializeField] float _distance = 2f;　　　　//帰ろうテキストを表示する距離
    [SerializeField] GameObject _goHome;　　　　　//帰ろうテキスト
    [SerializeField] TextMeshPro _goHomeText;　　//帰ろうテキスト
    [SerializeField] float _waitTime;
    [SerializeField] float _fadeTime;             //テキストのフェード時間
    [SerializeField] OVRScreenFade _screenFade;   //OVRScreenFadeコンポーネント
    [SerializeField] float _fadeDuration;         //ScreenFadeを待つ時間
    public bool isGameClear { get; private set; }

    
    void Start()
    {
        isGameClear = false;
        _creditText.SetActive(false);
        _endCol.enabled = false;
        _goHome.SetActive(false);
    }

    public void GameClear()
    {
        Debug.Log("フラグ変更");
        PopGoHomeText();
        StartCoroutine(WaitAndFadeOutText(_goHomeText));
        isGameClear = true;
        _creditText.SetActive(true);
        _endCol.enabled = true;
    }

    //帰ろうテキストの表示
    private void PopGoHomeText()
    {
        Vector3 forward = _centerEyeAnchor.forward;  //プレイヤーの正面
        forward.y = 0f;                              //上下は無視
        forward.Normalize();

        _goHome.transform.position = _centerEyeAnchor.position + forward * _distance;     //プレイヤーの水平方向正面に配置
        _goHome.transform.LookAt(_centerEyeAnchor);                                       //プレイヤーにテキストを向ける
        _goHome.transform.Rotate(0, 180f, 0);                                             //後ろを向くので180度回転
        _goHome.SetActive(true);
    }

    public override void OnInputAction(InputButton state)
    {
        if(!isGameClear) return;
        //クリア後、ドアに手をかけた時の最後の処理
        if (isGameClear)
        {
            if (state == InputButton.PrimaryHandTriggerDown || state == InputButton.SecondaryHandTriggerDown)
            {
                StartCoroutine(FadeOutAndLoadScene());
            }
        }
    }

    IEnumerator FadeOutAndLoadScene()
    {
        _screenFade.FadeOut();
        yield return new WaitForSeconds(_fadeDuration);
        SceneManager.LoadScene("Project_PHOBIA");
    }

    IEnumerator WaitAndFadeOutText(TextMeshPro alpha)
    {
        //_waitTimeだけ待ってからフェードアウト処理
        yield return new WaitForSeconds(_waitTime);

        //必ず不透明スタート
        Color c = alpha.color;
        c.a = 1;
        alpha.color = c;

        //fadeの経過時間タイマー
        float timer = 0f;
        while (timer < _fadeTime)
        {
            timer += Time.deltaTime;
            c.a = 1 - Mathf.Clamp01(timer / _fadeTime);
            alpha.color = c;
            yield return null;
        }
        Destroy(alpha.gameObject);
    }
}
