using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystemUI : MonoBehaviour
{
    [SerializeField] private Button endTurnBtn;
    [SerializeField] private TextMeshProUGUI TurnText;

    private void Start()
    {
        endTurnBtn.onClick.AddListener(() =>
        {
            TurnSystem.Instance.NextTurn();
        });

    }

    private void Update()
    {
        UpdateTurnText();
        UpdateEndTurnVisibility();   
    }

    private void UpdateTurnText()
    {
        if (TurnSystem.Instance.IsPlayerTurn())
        {
            TurnText.text = "Player Turn";
        }
        else
        {
            TurnText.text = "Enemy Turn";
        }
    }
    private void UpdateEndTurnVisibility()
    {
        endTurnBtn.gameObject.SetActive(TurnSystem.Instance.IsPlayerTurn());
    }
}
