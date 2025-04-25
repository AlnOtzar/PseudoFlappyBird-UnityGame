using UnityEngine;
using UnityEngine.Rendering;

public class Spawn : MonoBehaviour
{
    public GameObject[] AparicionTubos; 
    public float heightRange = 20.5f;
    public float maxTime = 1.75f;
    private float timer;

    void Start()
    {
        SpawnPipe();
    }

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

        GameObject selectedPipe = AparicionTubos[Random.Range(0, AparicionTubos.Length)];

        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject newPipe = Instantiate(selectedPipe, spawnPosition, Quaternion.identity);
        Destroy(newPipe, 8f);
    }
}
