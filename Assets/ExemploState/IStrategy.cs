using UnityEngine;

public interface IStrategy
{
    public void Enter();
    public void Execute(float delta);
}
