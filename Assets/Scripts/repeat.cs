using UnityEngine;
using UnityEngine.AI;

public class repeat : MonoBehaviour
{
    private float spriteWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        spriteWidth = groundCollider.bounds.size.x; // Obtiene el tamaño real del sprite
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -spriteWidth * 0.485) // Ajusta el 1.1 según sea necesario
        {
            ResetPosition();
        }
    }
    private void ResetPosition()
    {
        transform.Translate(new Vector3(2 * spriteWidth, 0f, 0f));
    }
}

