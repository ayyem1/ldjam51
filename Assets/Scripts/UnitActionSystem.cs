using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance {get; private set;}
    public event EventHandler OnSelectedUnitChanged;
    public event EventHandler OnSelectedActionChanged;
    public event EventHandler<bool> OnBusyChanged;
    public event EventHandler OnActionStarted;
    //[SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;
    private Entity selectedAction;
    private bool isBusy;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one UnitActionSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (isBusy)
        {
            return;
        }
        if (!TurnSystem.Instance.IsPlayerTurn())
        {
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(TryHandleUnitSelection())
        {
            return;
        }

        HandleSelectedAction();


    }

    private void HandleSelectedAction()
    {
        if (InputManager.Instance.IsMouseButtonDownThisFrame())
        {
            /*
            if (!selectedUnit.TrySpendActionPointsToTakeAction(selectedAction))
            {
                return;
            }
            */
            
            SetBusy();
            //selectedAction.TakeAction(ClearBusy);

            OnActionStarted?.Invoke(this,EventArgs.Empty);            
        }
    }    

    private void SetBusy()
    {
        isBusy = true;

        OnBusyChanged?.Invoke(this, isBusy);
    }

    private void ClearBusy()
    {
        isBusy = false;

        OnBusyChanged?.Invoke(this, isBusy);
    }
    private bool TryHandleUnitSelection()
    {
        if (InputManager.Instance.IsMouseButtonDownThisFrame())
        {
            Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.GetMouseScreenPosition());
            if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask))
           {
             /*
             if(raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
             {
                 return true;
             }
             */
           }
        }
        
        return false;
    }

    public void SetSelectedAction(Entity baseAction)
    {
        selectedAction = baseAction;
        OnSelectedActionChanged?.Invoke(this,EventArgs.Empty);
    }

    public Entity GetSelectedAction()
    {
        return selectedAction;
    }
}
