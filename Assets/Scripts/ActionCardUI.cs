using UnityEngine;
using TMPro;

public class ActionCardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject selectedGameObject;
    private BaseAction baseAction;

    public void SetBaseAction(BaseAction baseAction)
    {
        this.baseAction = baseAction;
        textMeshPro.text = baseAction.GetActionName().ToUpper();

        //button.onClick.AddListener(() =>{
        //    UnitActionSystem.Instance.SetSelectedAction(baseAction);
        //});
    }

    public void UpdateSelectedVisual()
    {
        BaseAction selectedBaseAction = UnitActionSystem.Instance.GetSelectedAction();
        selectedGameObject.SetActive(selectedBaseAction == baseAction);
    }
}
