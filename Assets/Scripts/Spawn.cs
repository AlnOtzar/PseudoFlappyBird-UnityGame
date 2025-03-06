using UnityEngine;
using UnityEngine.Rendering;

public class Spawn : MonoBehaviour
{
    public GameObject[] AparicionTubos;  // Array para contener diferentes prefabs de tubos
    public float heightRange = 20.5f;
    public float maxTime = 1.75f;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGamerOver)
        {
            timer += Time.deltaTime;

            if (timer > maxTime)
            {
                SpawnPipe();
                timer = 0;
            }
        }
    }

    public void SpawnPipe()
    {
        if (AparicionTubos == null || AparicionTubos.Length == 0)
        {
            Debug.LogError("AparicionTubos no ha sido asignado o está vacío en el Inspector.");
            return;
        }

        // Seleccionar aleatoriamente un prefab de la lista AparicionTubos
        GameObject selectedPipe = AparicionTubos[Random.Range(0, AparicionTubos.Length)];

        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject newPipe = Instantiate(selectedPipe, spawnPosition, Quaternion.identity);
        Destroy(newPipe, 5f);
    }
}
