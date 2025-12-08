using UnityEngine;

public class ShootBal : MonoBehaviour
{
    float shootforce = 10f;
    Vector3 shootdirection = new Vector3(1, 0, 0);
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(shootdirection * shootforce);
        }
    }
}
