using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState
{
    void Init();
    void Action();
    void End();
}
