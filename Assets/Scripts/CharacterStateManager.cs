using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    public ICharacterState currentState { get; private set; }
    public ICharacterState previousState { get; private set; }
    public float changeStateTime;

    [SerializeField] private CharacterInitState startState;

    public virtual void Start()
    {
        currentState = startState;
        currentState.Init();
    }

    public void SetState(ICharacterState _state)
    {
        changeStateTime = Time.time;

        previousState = currentState;
        previousState.End();
        currentState = _state;
        currentState.Init();
    }

    public virtual void Update()
    {
        currentState?.Action();
    }
}
