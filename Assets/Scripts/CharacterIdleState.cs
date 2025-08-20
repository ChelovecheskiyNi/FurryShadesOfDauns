using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : CharacterStateBase
{
    [SerializeField] CharacterWalkState walkState;

    [Space(20)]
    private float timer;
    [SerializeField] private float timeToRollForMove;
    [SerializeField] private int chanceToMove;

    public override void Action()
    {
        timer += Time.deltaTime;
        if (timer >= timeToRollForMove)
        {
            timer = 0;
            int _r = Random.Range(1, 101);
            if (_r <= chanceToMove) stateManager.SetState(walkState);
        }
    }
}