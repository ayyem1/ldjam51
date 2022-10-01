using UnityEngine;
using TMPro;

public class ActionCardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject selectedGameObject;
    private Entity baseAction;

    public void SetBaseAction(Entity baseAction)
    {
        this.baseAction = baseAction;
        //textMeshPro.text = baseAction.GetActionName().ToUpper();

        //button.onClick.AddListener(() =>{
        //    UnitActionSystem.Instance.SetSelectedAction(baseAction);
        //});
    }

    public void UpdateSelectedVisual()
    {
        Entity selectedBaseAction = UnitActionSystem.Instance.GetSelectedAction();
        selectedGameObject.SetActive(selectedBaseAction == baseAction);
    }
}
