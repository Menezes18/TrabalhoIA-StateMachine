using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : IStrategy
{
    private Agente agente;
    private float time = 0;
    public ChangeColor(Agente a) {
        agente = a;
    }
    
    public void Enter() {
        Color c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        agente.GetComponent<MeshRenderer>().material.color = c;
        time = Time.time + 5;
    }

    public void Execute(float t) {
        if (Time.time > time)
        {
            agente.ChangeState(new Clone(agente));
            
        }
    }
}
