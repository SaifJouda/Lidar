using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Shoot report;
    private float spawnTime;
    

    private void Start()
    {
        // Record the time when the projectile is spawned
        spawnTime = Time.time;
    }
    private void OnCollisionEnter(Collision collision)
    {

        float timeAlive = Time.time - spawnTime;

        report.Report(timeAlive);
  

        Destroy(gameObject); 

    }
}
