using UnityEngine;
using UnityEngine.AI;

public class repeat : MonoBehaviour
{
    private float spriteWidth;
    void Start()
    {
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        spriteWidth = groundCollider.bounds.size.x; 
    }


    void Update()
    {
        if (transform.position.x < -spriteWidth * 0.445) 
        {
            ResetPosition();
        }
    }
    private void ResetPosition()
    {
        transform.Translate(new Vector3(2 * spriteWidth, 0f, 0f));
    }
}

