using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalkState : CharacterStateBase
{
    [SerializeField] private CharacterIdleState idleState;

    [Space(20)]
    [SerializeField] private Transform characterTransform;
    [SerializeField] private float speed;
    [SerializeField] private CharacterInitState minMaxPositions;
    private Vector2 pointToMove;

    public override void Init()
    {
        pointToMove = minMaxPositions.GetRandomPoint();
    }

    public override void Action()
    {
        characterTransform.position = Vector2.MoveTowards(characterTransform.position, pointToMove, speed * Time.deltaTime);
        if (Mathf.Abs(characterTransform.position.x - pointToMove.x) < 0.1f && Mathf.Abs(characterTransform.position.y - pointToMove.y) < 0.1f)
            stateManager.SetState(idleState);
    }
}
