using UnityEngine;
using TMPro;
public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float shootingInterval = 1f;

    public float velocity = 3f;

    
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI distanceText;

    void Start()
    {
        // Invoke the ShootProjectile method every shootingInterval seconds, starting after 1 second.
        InvokeRepeating("ShootProjectile", 1f, shootingInterval);
    }

    void ShootProjectile()
    {
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        projectile.GetComponent<Destroy>().report=this;
        // Get the Rigidbody component of the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Check if the Rigidbody component is present
        if (rb != null)
        {
            // Set the velocity of the projectile to move in the X direction
            rb.velocity = new Vector2(projectileSpeed, velocity);
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on the projectile prefab.");
        }
    }

    public void Report(float t)
    {
        timeText.text = "Time: "+t.ToString("F2") + "s";
        float a=1.1f;
        float du=t*projectileSpeed*a;
        distanceText.text = "Distance: "+du.ToString("F2") + "m";
    }
}
