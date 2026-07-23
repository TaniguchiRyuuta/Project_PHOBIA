using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSprite : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite nomal;
    [SerializeField]
    private Sprite horror;

    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = nomal;
    }
    public void ChangeImage()
    {
        image.sprite = horror;
    }
}
