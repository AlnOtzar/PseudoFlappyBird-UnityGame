using UnityEngine;

public class repeat : MonoBehaviour
{
    private float spriteWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.bounds.size.x; // Obtiene el tamaño real del sprite
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -spriteWidth * 1.1f) // Ajusta el 1.1 según sea necesario
        {
            ResetPosition();
        }
    }
    private void ResetPosition()
    {
        float maxX = -Mathf.Infinity;

        // Busca el fondo más a la derecha
        foreach (GameObject fondo in GameObject.FindGameObjectsWithTag("fondo"))
        {
            if (fondo.transform.position.x > maxX)
            {
                maxX = fondo.transform.position.x;
            }
        }

        // Mueve el fondo actual justo detrás del último
        transform.position = new Vector3(maxX + spriteWidth, transform.position.y, transform.position.z);
    }


}

