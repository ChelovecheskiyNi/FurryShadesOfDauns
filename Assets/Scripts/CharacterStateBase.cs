using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStateManager))]
public abstract class CharacterStateBase : MonoBehaviour, ICharacterState
{
    private protected CharacterStateManager stateManager { get; set; }

    public virtual void Start()
    {
        stateManager = GetComponent<CharacterStateManager>();
    }

    public virtual void Init() { }
    public virtual void Action() { }
    public virtual void End() { }
}
