using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Text _restartText;
    private PlayerController PlayerControllerScript;
    private void Awake()
    {
        _restartText = GameObject.FindGameObjectWithTag("RestartText").GetComponent<Text>();
        PlayerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public void Lose()
    {
        _restartText.color = Color.red;
        _restartText.text = "You lose!";
        OffMovement();
        Invoke(nameof(RestartGame), 1f);
    }
    public void Win()
    {
        _restartText.color = Color.red;
        _restartText.text = "You lose!";
        OffMovement();
        Invoke(nameof(RestartGame), 1f);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void OffMovement()
    {
        PlayerControllerScript.enabled = false;
        PlayerControllerScript.PlayerRigidBody.velocity = new Vector2(0, 0);
    }
}
