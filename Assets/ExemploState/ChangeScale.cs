using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : IStrategy
{
    private Agente agente;
    private float time = 0;
    public ChangeScale(Agente a) {
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
            int i = Random.Range(0, 2);
            switch (i) {
                case 0: agente.ChangeState(new ChangeRotation(agente)); break;
                case 1: agente.ChangeState(new ChangeColor(agente)); break;
            }
        }
        float s = Mathf.PingPong(Time.time, 5);
        agente.transform.localScale = new Vector3(s, s, s);
    }
}
