using UnityEngine;

public class SpawnFondo : MonoBehaviour
{
    public GameObject[] fondoPrefabs; 
    public float heightRange = 20.5f;
    public float maxTime = 1.75f;

    public float desTime = 10f;
    private float timer;

    void Start()
    {
        SpawnFondoPrefab();
    }

    void Update()
    {
        if (!GameManager.Instance.isGamerOver)
        {
            timer += Time.deltaTime;

            if (timer > maxTime)
            {
                SpawnFondoPrefab();
                timer = 0;
            }
        }
    }

    void SpawnFondoPrefab()
    {
        if (fondoPrefabs == null || fondoPrefabs.Length == 0)
        {
            Debug.LogError("No hay prefabs de fondo asignados.");
            return;
        }

        GameObject selectedPrefab = fondoPrefabs[Random.Range(0, fondoPrefabs.Length)];

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject newFondo = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        Destroy(newFondo, desTime);
    }

}
