using PJ_PHOBIA;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartAndTutorial : EventBehaviour
{
    //チュートリアル時に表示する説明テキストUI
    [SerializeField] TextMeshPro _title;
    [SerializeField] TextMeshPro _title2;
    [SerializeField] TextMeshPro _lightText;
    [SerializeField] TextMeshPro _moveText;
    [SerializeField] TextMeshPro _actionText;
    [SerializeField] TextMeshPro _itemChangeText;
    [SerializeField] TextMeshPro _forgotText;
    [SerializeField] TextMeshPro _rotateText;
    [SerializeField] float _fadeTime;
    [SerializeField] PlayerController _flag;  //PlayerController側のフラグ

    private bool _isStartTutorial;  //チュートリアルスタート実行可能フラグ
    private bool _isMoveTutorial;   //移動チュートリアル実行可能フラグ
    public bool _isActionTutorial; //アクションチュートリアルs実行可能フラグ
    private bool _isforgotText;
    private bool _isRotateTutorial; //カメラローテートチュートリアル実行可能フラグ
    private bool _isFinishTutorial;

    [SerializeField] private float _waitTime = 4f;

    void Start()
    {
        _isStartTutorial = false;
        _isMoveTutorial = false;
        _isActionTutorial = false;
        _isforgotText = false;
        _isRotateTutorial = false;
        _isFinishTutorial = false;
    }

    // Update is called once per frame
    void Update()
    {
        //点滅処理()は肉付けで…
        if (!_isStartTutorial)
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                _isStartTutorial = true;
                StartCoroutine(StartTutorial());
                
                
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

        //インタラクトアクションのチュートリアル コライダーでtrueにする
        if (_isActionTutorial)
        {
            StartCoroutine(FadeInText(_itemChangeText));
            if(OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.B))
            {
                StartCoroutine(WaitFadeOut(_itemChangeText, _actionText));
                _isActionTutorial = false;
            }
        }

        //カメラローテートチュートリアル
        if (_isRotateTutorial)
        {
            var secondInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            if (secondInput.x < 0 || secondInput.x > 0)
            {
                StartCoroutine(WaitDestroy(_rotateText));
                _isRotateTutorial= false;
                _flag._isFinishTutorial = true;
            }
        }

        if (_isFinishTutorial)
        {
            Destroy(this.gameObject);
        }
    }


    public override void OnInputAction(InputButton state)
    {
        if (state == InputButton.PrimaryHandTriggerDown ||  state == InputButton.SecondaryHandTriggerDown)
        {
            //ドアに手にかけた時に表示する、落し物あるから取りに帰ろうテキストの表示
            if (!_isforgotText)
            {
                StartCoroutine(FadeOutText(_actionText));
                StartCoroutine(FadeInText(_forgotText));
                StartCoroutine(WaitFadeForgotText());
            }
        }
        
    }

    //ゲーム開始直後用コルーチン  いらなければ全部そのまま書く　　（移動チュートリアルテキストの表示までの処理）
    IEnumerator StartTutorial()
    {
        StartCoroutine(FadeOutText(_title));
        StartCoroutine(FadeOutText(_title2));
        yield return FadeOutText(_lightText);
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(FadeInText(_moveText));
        _isMoveTutorial = true;                               //移動チュートリアル開始
        _flag._isGameStart = true;
    }

    //_forgotTextの表示時間経過後、自動フェードアウト用
    IEnumerator WaitFadeForgotText()
    {
        yield return new WaitForSeconds(_waitTime);
        yield return StartCoroutine(FadeOutText(_forgotText));
        StartCoroutine(FadeInText(_rotateText));
        _isRotateTutorial = true;  //カメラローテートチュートリアル開始
    }
    IEnumerator WaitFadeOut(TextMeshPro fadeOut, TextMeshPro fadeIn)
    {
        yield return StartCoroutine(FadeOutText(fadeOut));
        StartCoroutine(FadeInText(fadeIn));
    }
    IEnumerator WaitDestroy(TextMeshPro waitText)
    {
        yield return StartCoroutine(FadeOutText(waitText));
        _isFinishTutorial = true;
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
