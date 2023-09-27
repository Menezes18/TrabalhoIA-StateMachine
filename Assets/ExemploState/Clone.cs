using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : IStrategy
{
    private Agente agente;
    private float time = 0;
    public Clone(Agente a) {
        agente = a;
    }
    
    public void Enter() {
        time = Time.time + 5;
    }

    public void Execute(float t) {
        if (Time.time > time)
        {
            GameObject obj = new GameObject();
            obj.AddComponent<MeshRenderer>();
            obj.AddComponent<MeshFilter>();
            obj.transform.position = agente.transform.position;
            obj.GetComponent<MeshFilter>().mesh = agente.GetComponent<MeshFilter>().mesh;
            int i = Random.Range(0, 3);
            switch (i) {
                case 0: agente.ChangeState(new ChangeRotation(agente)); break;
                case 1: agente.ChangeState(new ChangeColor(agente)); break;
                case 2: agente.ChangeState(new ChangeScale(agente)); break;
            }
            
        }
    }
}
