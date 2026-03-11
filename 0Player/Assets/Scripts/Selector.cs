using System;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] private Controller activeController;

    [SerializeField] private LayerMask selectableLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            SelectController();
        }
    }

    private void SelectController()
    {

        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D col = Physics2D.OverlapPoint(mouseWorld);

        if (col != null)
        {
            Controller controller = col.GetComponent<Controller>();

            if (controller != null)
            {
                SetActiveController(controller);
                return;
            }
        }

        ClearActiveController();
    }

    void SetActiveController(Controller newController)
    {
        if (activeController == newController)
            return;

        if (activeController != null)
            activeController.SetCurrentController(false);

        activeController = newController;
        activeController.SetCurrentController(true);
    }

    void ClearActiveController()
    {
        if (activeController != null)
        {
            activeController.SetCurrentController(false);
            activeController = null;
        }
    }
}
