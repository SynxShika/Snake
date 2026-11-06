using UnityEngine;

public abstract class Food : MonoBehaviour
{
    public abstract int Points { get; }

    public virtual void OnEaten(SnakeController snake)
    {
        GameManager.Instance.AddScore(Points);
        snake.Grow(1);
        FruitSpawnManager.Instance.OnFruitEaten(this);
    }
}

