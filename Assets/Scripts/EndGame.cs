using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the end game logic, including triggering confetti and restarting the level.
/// </summary>
public class EndGame : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] confettis;

    /// <summary>
    /// Handles the trigger event when an object enters the collider.
    /// </summary>
    /// <param name="other">The collider that triggered the event.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            foreach (var confetti in confettis)
            {
                confetti.Play();
            }
            Invoke("QuitGame", 5f);
        }

        if (other.CompareTag("Ennemy"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            Invoke("RestartLevel", 5f);
        }
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    private void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Restarts the current level.
    /// </summary>
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}