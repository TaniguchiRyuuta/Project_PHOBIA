using PJ_PHOBIA;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartAndTutorial : MonoBehaviour
{
    //チュートリアル時に表示する説明テキストUI
    [SerializeField] TextMeshPro _title;
    [SerializeField] TextMeshPro _title2;
    [SerializeField] TextMeshPro _lightText;
    [SerializeField] TextMeshPro _moveText;
    [SerializeField] TextMeshPro _actionText;
    [SerializeField] TextMeshPro _forgotText;
    [SerializeField] TextMeshPro _rotateText;
    [SerializeField] float _fadeTime;
    [SerializeField] PlayerController _flag;  //PlayerController側のフラグ

    private bool _isStartTutorial;  //チュートリアルスタート実行可能フラグ
    private bool _isMoveTutorial;   //移動チュートリアル実行可能フラグ
    private bool _isActionTutorial; //アクションチュートリアル実行可能フラグ
    private bool _isforgotText;
    private bool _isRotateTutorial; //カメラローテートチュートリアル実行可能フラグ

    [SerializeField] private float _waitTime = 4f;

    void Start()
    {
        //StartCoroutine(StartTutorial());
        _isStartTutorial = false;
        _isMoveTutorial = false;
        _isActionTutorial = false;
        _isforgotText = false;
        _isRotateTutorial = false;
    }

    // Update is called once per frame
    void Update()
    {
        //点滅処理()は肉付けで…
        if (!_isStartTutorial)
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                StartCoroutine(StartTutorial());
                _flag._isGameStart = true;
                _isStartTutorial = true;
                _isMoveTutorial= true;   //移動チュートリアル開始
                Debug.Log("移動チュートリアル開始");
            }
        }

        //移動チュートリアル
        if (_isMoveTutorial)
        {
            var input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            if (input.x > 0 || input.y > 0)
            {
                Debug.Log("移動入力確認！");
                StartCoroutine(FadeOutText(_moveText));
                _isMoveTutorial = false;
            }
        }

        //インタラクトアクションのチュートリアル
        if (_isActionTutorial)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                //ドアに手にかけた時に表示する、落し物あるから取りに帰ろうテキストの表示
                if (!_isforgotText)
                {
                    StartCoroutine(FadeOutText(_actionText));
                    StartCoroutine(FadeInText(_forgotText));
                    StartCoroutine(WaitFadeText());
                    _isRotateTutorial = true;  //カメラローテートチュートリアル開始
                }  
            }
        }

        //カメラローテートチュートリアル
        if (_isRotateTutorial)
        {
            _flag._isFinishTutorial = true;
            var secondInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            if (secondInput.x < 0 || secondInput.x > 0)
            {
                StartCoroutine(FadeOutText(_rotateText));
                _isRotateTutorial= false;
            }
        }
    }

    //door前チュートリアルテキスト表示
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("コライダーイン！");
        //Playerじゃなかったらreturn
        if (!other.CompareTag("Player"))
        {
            return;
        }
        StartCoroutine(FadeInText(_actionText));
        _isActionTutorial = true;　　//インタラクトアクションのチュートリアル開始
    }

    //ゲーム開始直後用コルーチン  いらなければ全部そのまま書く　　（移動チュートリアルテキストの表示までの処理）
    IEnumerator StartTutorial()
    {
        StartCoroutine(FadeOutText(_title));
        StartCoroutine(FadeOutText(_title2));
        yield return FadeOutText(_lightText);
        StartCoroutine(FadeInText(_moveText));
    }

    IEnumerator WaitFadeText()
    {
        yield return new WaitForSeconds(_waitTime);
        StartCoroutine(FadeOutText(_forgotText));
        StartCoroutine(FadeInText(_rotateText));
    }
    //チュートリアルテキストのフェードイン用コルーチン（引数はフェードさせるTextMeshPro　※UGUI×）
    IEnumerator FadeInText(TextMeshPro alpha)
    {
        //必ず透明スタート
        Color c = alpha.color;
        c.a = 0;
        alpha.color = c;

        //fadeの経過時間タイマー
        float timer = 0f;
        while(timer < _fadeTime)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Clamp01(timer /_fadeTime);
            alpha.color = c;
            yield return null;
        }
    }

    //フェードアウト用コルーチン
    IEnumerator FadeOutText(TextMeshPro alpha)
    {
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
