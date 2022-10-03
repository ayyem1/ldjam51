using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FtueManager : MonoBehaviour
{
    public string FTUETitle = "Notice";
    public string FTUE1Description = "Interact with your coworkers and other items by clicking on their icons.";
    public string FTUE2Description = "Drag skill cards over the enemy you want to attack.";
    public string FTUE3Description = "Don't forget to modify your deck.";

    public bool IsFTUE1Done;
    public bool IsFTUE2Done;
    public bool IsFTUE3Done;

    public void Reset()
    {
        IsFTUE1Done = false;
        IsFTUE2Done = false;
        IsFTUE3Done = false;
    }
}
