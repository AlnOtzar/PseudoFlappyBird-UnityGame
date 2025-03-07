using UnityEngine;

public class Puntos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            FindAnyObjectByType<ControlPuntuacion>().ActualizarPuntuacion();
        }
    }
}
