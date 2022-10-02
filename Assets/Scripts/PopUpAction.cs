using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpAction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private Image uiImage;
    private float disappearTimer;
    private Color textColor;

    public void Setup(float amount, Sprite icon)
    {
        textMesh.SetText(amount.ToString());
        uiImage.sprite = icon;
        disappearTimer = 1f;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {
            gameObject.SetActive(false);
        }
    }



}
