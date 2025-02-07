using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColicionadorTubos : MonoBehaviour
{
    private GameObject[] grupotubos;
    private float distacia = 6.49f;
    private float ultimaXTubo;
    private float yminTubo = -2.0f; // Calibrar respecto al editor
    private float ymaxTubo = 2.0f;  // Se corrigió el valor para que sea diferente de yminTubo
    public SpriteRenderer pipeRenderer;
    public Sprite[] pipeTextures;
    public float changeInterval = 2f;
    private int currentTextureIndex=0;
    private float timer=0f;

    void Awake()
    {
        grupotubos = GameObject.FindGameObjectsWithTag("grupotubos");

        for (int i = 0; i < grupotubos.Length; i++)
        {
            Vector3 temp = grupotubos[i].transform.position;
            temp.y = Random.Range(yminTubo, ymaxTubo);
            grupotubos[i].transform.position = temp;
        }

        ultimaXTubo = grupotubos[0].transform.position.x;

        for (int i = 1; i < grupotubos.Length; i++)
        {
            if (ultimaXTubo < grupotubos[i].transform.position.x)
            {
                ultimaXTubo = grupotubos[i].transform.position.x;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "tubosgrupo")
        {
            Vector3 temp = obj.transform.position;
            temp.x = ultimaXTubo + distacia;
            temp.y = Random.Range(yminTubo, ymaxTubo);
            obj.transform.position = temp;
            ultimaXTubo = temp.x;
        }
    }

    void Start()
    {
        if(pipeTextures.Length > 0 && pipeRenderer !=null)
        {
            pipeRenderer.sprite = pipeTextures[currentTextureIndex];
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= changeInterval)
        {
            timer = 0f;
            ChangeTexture();
        }
    }

    void ChangeTexture()
    {
        currentTextureIndex = (currentTextureIndex + 1) % pipeTextures.Length;
        pipeRenderer.sprite = pipeTextures[currentTextureIndex];
    }
}
