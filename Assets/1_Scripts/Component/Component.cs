using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Component
{
    //Component 인터페이스 형태 
    void UpdateState(GameState state);
}
