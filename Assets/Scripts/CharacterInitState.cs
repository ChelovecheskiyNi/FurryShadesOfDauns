using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInitState : CharacterStateBase, ICharacterState
{
    [SerializeField] CharacterIdleState idleState;

    [Space(20)]
    [SerializeField] private Transform placeToWalkTransform;
    [SerializeField] private Transform characterTransform;
    public float minXWalkPosition;
    public float minYWalkPosition;
    public float maxXWalkPosition;
    public float maxYWalkPosition;

    public Vector2 GetRandomPoint()
    {
        return new Vector2(Random.Range(minXWalkPosition, maxXWalkPosition), Random.Range(minYWalkPosition, maxYWalkPosition));
    }

    public override void Init()
    {
        characterTransform = this.transform;
        maxXWalkPosition = (placeToWalkTransform.localScale.x / 2) - (characterTransform.localScale.x / 2) + placeToWalkTransform.position.x;
        minXWalkPosition = -((placeToWalkTransform.localScale.x / 2) - (characterTransform.localScale.x / 2)) + placeToWalkTransform.position.x;
        maxYWalkPosition = (placeToWalkTransform.localScale.y / 2) + placeToWalkTransform.position.y;
        minYWalkPosition = -(placeToWalkTransform.localScale.y / 2) + placeToWalkTransform.position.y;
        characterTransform.transform.position = GetRandomPoint();

        stateManager.SetState(idleState);
    }
}
