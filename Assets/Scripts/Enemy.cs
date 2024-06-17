using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject particleEffect;

    public float health = 4f;

    public static int EnemiesAlive = 0;
    private void Start()
    {
        EnemiesAlive++;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.relativeVelocity.magnitude > health)  // other = Ball
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(particleEffect);
        EnemiesAlive--;
        if(EnemiesAlive <= 0)
        {
            //SceneManager.LoadScene(0);
        }
        Destroy(gameObject);
    }
}
