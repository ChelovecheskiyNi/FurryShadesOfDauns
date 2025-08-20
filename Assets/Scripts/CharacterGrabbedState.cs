using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterGrabbedState : CharacterStateBase
{
    [SerializeField] private CharacterIdleState idleState;

    [Space(20)]
    [SerializeField] private float yOffset;

    public override void Action()
    {
        Vector2 _mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(_mouseWorldPoint.x, _mouseWorldPoint.y + yOffset, 0);
        if (Input.GetMouseButtonUp(0)) stateManager.SetState(idleState);
    }

    private void OnMouseDown()
    {
        print("Click");
        
        if (!EventSystem.current.IsPointerOverGameObject()) return;

        print("Real click");
        stateManager.SetState(this);
    }
}
