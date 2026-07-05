using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, Header("移動速度")]
        private float speed = 1.5f;

        [Header("カメラ回転設定")]
        [SerializeField] private float snapAngle = 45f;       // 1回の回転角度
        [SerializeField] private float inputThreshold = 0.7f; // スティック入力の閾値
        [SerializeField] private Transform cameraRig;         // OVRCameraRig をアサイン

        [SerializeField, Header("参照（CenterEyeAnchor）")]
        private Transform headTransform;

        [Header("足音")]
        [SerializeField] private AudioClip walkClip;
        [SerializeField][Range(0f, 1f)] private float footstepVolume = 1.0f;
        private AudioSource audioSource;
        private AudioClip currentClip;

        private bool isTurning = false; // 連続入力防止フラグ
        private CharacterController characterController;


        void Start()
        {
            characterController = GetComponent<CharacterController>();

            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.volume = footstepVolume;
        }

        private void Update()
        {
            Move();
            HandleFootsteps();
            SnapTurn();
        }

        void Move()
        {
            Vector2 stick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            Vector3 forward = new Vector3(headTransform.forward.x, 0f, headTransform.forward.z).normalized;
            Vector3 right = new Vector3(headTransform.right.x, 0f, headTransform.right.z).normalized;
            Vector3 moveDirection = forward * stick.y + right * stick.x;

            characterController.Move(moveDirection * Time.deltaTime);
        }

        void HandleFootsteps()
        {
            Vector2 stick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            bool isMoving = stick.magnitude > 0;

            if (isMoving)
            {
                AudioClip targetClip = walkClip;

                if (targetClip != null && currentClip != targetClip)
                {
                    audioSource.clip = targetClip;
                    audioSource.Play();
                    currentClip = targetClip;
                }
                else if (!audioSource.isPlaying && targetClip != null)
                {
                    audioSource.Play();
                }
            }
            else
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                    currentClip = null;
                }
            }
        }

        void SnapTurn()
        {
            Vector2 stickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

            if (!isTurning)
            {
                if (stickInput.x > inputThreshold)
                {
                    PerformSnapTurn(snapAngle);
                    isTurning = true;
                }
                else if (stickInput.x < -inputThreshold)
                {
                    PerformSnapTurn(-snapAngle);
                    isTurning = true;
                }
            }

            if (Mathf.Abs(stickInput.x) < inputThreshold * 0.5f) // スティックがニュートラルに戻ったらフラグリセット
            {
                isTurning = false;
            }
        }

        private void PerformSnapTurn(float angle)
        {
            if (cameraRig == null) return;

            Transform centerEye = cameraRig.GetComponentInChildren<Camera>()?.transform; // カメラ（頭）の位置を軸に回転させる
            Vector3 pivotPoint = centerEye != null ? centerEye.position : cameraRig.position;

            cameraRig.RotateAround(pivotPoint, Vector3.up, angle);
        }
    }
}