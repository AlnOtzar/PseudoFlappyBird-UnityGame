using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] AparicionTubos;  // Array para contener diferentes prefabs de tubos
    public float heightRange = 20.5f;
    public float maxTime = 1.75f;
    private float timer;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if (GameManager.Instance.isGamerOver)
            return;

        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
    }

    public void SpawnPipe()
    {
        GameObject selectedPipe = AparicionTubos[Random.Range(0, AparicionTubos.Length)];

        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject newPipe = Instantiate(selectedPipe, spawnPosition, Quaternion.identity);

        StartCoroutine(DestruirSiSigueActivo(newPipe, 10f));
    }

    private System.Collections.IEnumerator DestruirSiSigueActivo(GameObject obj, float delay)
    {
        float elapsed = 0f;

        while (elapsed < delay)
        {
            if (GameManager.Instance.isGamerOver)
                yield break; // No destruye el tubo si el jugador muere

            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(obj);
    }
}
