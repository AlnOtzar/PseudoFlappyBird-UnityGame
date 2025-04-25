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


        GameObject selectedPrefab = fondoPrefabs[Random.Range(0, fondoPrefabs.Length)];

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject newFondo = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        StartCoroutine(DestruirSiSigueActivo(newFondo, desTime));

    }

    private System.Collections.IEnumerator DestruirSiSigueActivo(GameObject obj, float delay)
{
    float elapsed = 0f;

    while (elapsed < delay)
    {
        if (GameManager.Instance.isGamerOver)
            yield break; 

        elapsed += Time.deltaTime;
        yield return null;
    }

    Destroy(obj);
}


}
