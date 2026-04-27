using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private GameObject cameraRig;
    [SerializeField] private GameObject centerEyeAnchor;
    [SerializeField] private float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 stickData = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        Vector3 forward = centerEyeAnchor.transform.forward;
        forward.y = 0;
        
        Vector3 right = centerEyeAnchor.transform.right;
        right.y = 0;
        
        forward = forward.normalized;
        right = right.normalized;

        Vector3 moveDir = (forward * stickData.y) + (right * stickData.x);

        cameraRig.transform.position += moveDir * moveSpeed * Time.deltaTime;

        
    }
}
