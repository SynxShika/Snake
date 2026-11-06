using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int Score { get; private set; }
    public bool IsGameOver { get; private set; }

    public void AddScore(int points) { Score += points; }
    public void GameOver() { IsGameOver = true; }

    void Update()
    {
        if (IsGameOver && Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 40;                 
        style.normal.textColor = Color.white;

        GUI.Label(new Rect(20, 20, 600, 60), "Score: " + Score, style);

        if (IsGameOver)
            GUI.Label(new Rect(20, 80, 900, 60), "GAME OVER - press R to restart", style);
    }
}