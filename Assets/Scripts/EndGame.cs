using UnityEngine;

public class EnGame : MonoBehaviour
{

    public ParticleSystem[] confettis;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("You WON !");
            this.GetComponent<BoxCollider>().enabled = false;
            foreach (var confetti in confettis)
            {
                confetti.Play();
            }
        }

        if (other.tag == "Ennemy")
        {
            Debug.Log("You LOST !");
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
