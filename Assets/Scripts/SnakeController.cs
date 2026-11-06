using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] Transform segmentPrefab;
    [SerializeField] float tickTime = 0.15f;
    [SerializeField] int gridSize = 10;

    Vector2Int dir = Vector2Int.right, nextDir = Vector2Int.right;
    readonly List<Transform> segments = new List<Transform>();
    int pendingGrowth;
    float timer;

    void Start() { segments.Add(transform); }

    public void Grow(int amount) { pendingGrowth += amount; }

    void Update()
    {
        if (GameManager.Instance.IsGameOver) return;

        if (Input.GetKeyDown(KeyCode.W) && dir != Vector2Int.down) nextDir = Vector2Int.up;
        if (Input.GetKeyDown(KeyCode.S) && dir != Vector2Int.up) nextDir = Vector2Int.down;
        if (Input.GetKeyDown(KeyCode.A) && dir != Vector2Int.right) nextDir = Vector2Int.left;
        if (Input.GetKeyDown(KeyCode.D) && dir != Vector2Int.left) nextDir = Vector2Int.right;

        timer += Time.deltaTime;
        if (timer >= tickTime) { timer = 0; Step(); }
    }

    void Step()
    {
        dir = nextDir;
        Vector3 tailPos = segments[segments.Count - 1].position;

        for (int i = segments.Count - 1; i > 0; i--)
            segments[i].position = segments[i - 1].position;

        transform.position += new Vector3(dir.x, dir.y, 0);

        if (pendingGrowth > 0)
        {
            segments.Add(Instantiate(segmentPrefab, tailPos, Quaternion.identity));
            pendingGrowth--;
        }

        Vector2Int head = Vector2Int.RoundToInt(transform.position);

        if (Mathf.Abs(head.x) > gridSize || Mathf.Abs(head.y) > gridSize)
        { GameManager.Instance.GameOver(); return; }

        for (int i = 1; i < segments.Count; i++)
            if (Vector2Int.RoundToInt(segments[i].position) == head)
            { GameManager.Instance.GameOver(); return; }

        Food food = FruitSpawnManager.Instance.Current;
        if (food != null && Vector2Int.RoundToInt(food.transform.position) == head)
            food.OnEaten(this);
    }
}