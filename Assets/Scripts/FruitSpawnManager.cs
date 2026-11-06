using UnityEngine;

public class FruitSpawnManager : Singleton<FruitSpawnManager>
{
    [SerializeField] FruitFactory appleFactory;
    [SerializeField] FruitFactory goldenFactory;
    [SerializeField] int gridSize = 10;

    public Food Current { get; private set; }

    void Start() { SpawnFruit(); }

    public void SpawnFruit()
    {
        FruitFactory factory = Random.value < 0.2f ? goldenFactory : appleFactory;
        Vector2 pos = new Vector2(Random.Range(-gridSize, gridSize + 1),
                                  Random.Range(-gridSize, gridSize + 1));
        Current = factory.Create(pos);
    }

    public void OnFruitEaten(Food food)
    {
        Destroy(food.gameObject);
        SpawnFruit();
    }
}