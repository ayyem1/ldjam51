using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FtueLauncher : MonoBehaviour
{
    public FTUEDialog Dialog;
    public bool launchFirst;
    public bool launchSecond;
    public bool launchThird;

    private void Start()
    {
        if (launchFirst && !GameInstance.Instance.Ftue.IsFTUE1Done)
        {
            Dialog.Initialize(GameInstance.Instance.Ftue.FTUETitle, GameInstance.Instance.Ftue.FTUE1Description);
            Dialog.gameObject.SetActive(true);
            GameInstance.Instance.Ftue.IsFTUE1Done = true;
        }
        else if (launchSecond && GameInstance.Instance.Ftue.IsFTUE1Done && !GameInstance.Instance.Ftue.IsFTUE2Done)
        {
            Dialog.Initialize(GameInstance.Instance.Ftue.FTUETitle, GameInstance.Instance.Ftue.FTUE2Description);
            Dialog.gameObject.SetActive(true);
            GameInstance.Instance.Ftue.IsFTUE2Done = true;
        }
        else if (launchThird && GameInstance.Instance.Ftue.IsFTUE1Done && GameInstance.Instance.Ftue.IsFTUE2Done && !GameInstance.Instance.Ftue.IsFTUE3Done)
        {
            Dialog.Initialize(GameInstance.Instance.Ftue.FTUETitle, GameInstance.Instance.Ftue.FTUE3Description);
            Dialog.gameObject.SetActive(true);
            GameInstance.Instance.Ftue.IsFTUE3Done = true;
        }
    }
}
