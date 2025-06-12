using UnityEngine;

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
        }

        if (other.CompareTag("Ennemy"))
        {
            Debug.Log("You LOST !");
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}