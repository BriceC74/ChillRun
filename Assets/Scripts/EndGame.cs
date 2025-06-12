using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] ParticleSystem[] confettis;

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You WON !");
            this.GetComponent<BoxCollider>().enabled = false;
            foreach (var confetti in confettis)
            {
                Debug.Log(confetti);
                confetti.Play();
            }
            Invoke("QuitGame", 5f);
        }

        if (other.CompareTag("Ennemy"))
        {
            Debug.Log("You LOST !");
            this.GetComponent<BoxCollider>().enabled = false;
            Invoke("RestartLevel", 5f);
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}