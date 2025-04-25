using UnityEngine;

public class Scroll1 : MonoBehaviour
{
    public float speed = 80f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if (!GameManager.Instance.isGamerOver) 
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

}
