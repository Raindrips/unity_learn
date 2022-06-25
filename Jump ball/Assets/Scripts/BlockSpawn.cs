using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockSpawn : MonoBehaviour
{

    public const int BLOCK_NUM = 20;
    public GameObject blockPrefab;
    public float moveSpeed = 6f;

    private List<GameObject> list;

    private void Awake()
    {
        list = new List<GameObject>();
        InitBlock();
      
    }

    private void Start()
    {
        GameManager.Current.OnGameStart += OnGameStart;
    }

    void Update()
    {

    }

 

    private void FixedUpdate()
    {
        if (GameManager.Current.currentState != GameState.Start)
        {
            return;
        }
        foreach (GameObject block in list)
        {
            block.transform.Translate(new Vector3(moveSpeed*Time.deltaTime, 0, 0));
        }
    }

    public void OnGameStart(GameState gameState)
    {
       
    }

    void InitBlock()
    {
        for (int i = 0; i < BLOCK_NUM; i++)
        {
            GameObject block = Instantiate(blockPrefab);
            if (block)
            {
                block.transform.SetParent(transform);
                block.transform.position = new Vector3(i * 2, 0, 0);
                if (i < 3)
                {
                    Vector3 scale = block.transform.localScale;
                    scale.x = 2;
                    block.transform.localScale = scale;
                }
                else
                {
                    ResetBlock(block);
                }

                list.Add(block);
            }
        }
    }

    void ResetBlock(GameObject block)
    {
        Vector3 scale = block.transform.localScale;
        scale.x = Random.Range(0.5f, 1.5f);
        block.transform.localScale = scale;

        Vector3 position = block.transform.localPosition;
        position.y = Random.Range(-0.5f, 0.5f);
        block.transform.position = position;
    }

    void Respawn()
    {
        GameObject block= list[list.Count-1];
        Vector3 position = block.transform.position;
        position.x  += 2 + Random.Range(1.5f,2f);
        GameObject first = list[0];
        first.transform.position = position;
        ResetBlock(first);
        list.RemoveAt(0);
        list.Add(first);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            Respawn();
        }
    }
}
