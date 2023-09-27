using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente : MonoBehaviour
{
    private IStrategy action;

    void Start() {
        ChangeState(new ChangeColor(this));
    }
    
    void FixedUpdate() {
        action.Execute(Time.fixedDeltaTime);
    }

    public void ChangeState(IStrategy a) {
        action = a;
        action.Enter();
    }
}
