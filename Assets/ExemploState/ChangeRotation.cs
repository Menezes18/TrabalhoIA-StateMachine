using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRotation : IStrategy {
    private Agente agente;
    private float time;
    public ChangeRotation(Agente a) {
        agente = a;
    }
    public void Enter() {
        time = Time.time + 3;
    }
    public void Execute(float t) {
        if (Time.time > time) {
            agente.ChangeState(new ChangeColor(agente));
        }
        agente.transform.Rotate(0, 30 * t, 0);
    }
}
