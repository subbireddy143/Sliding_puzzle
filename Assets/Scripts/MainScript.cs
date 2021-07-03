using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    /*
    [SerializeField] private Transform empty_block;

    private Camera _camera;

    //distance between blocks
    [SerializeField] private float distance;

    //List of tiles
    [SerializeField] private BlockScript[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = _camera.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                //if hit
                if (hit)
                {
                    if (Vector2.Distance(a: hit.transform.position, b: empty_block.position) < distance) {

                        //transform the posoitions
                        Vector2 previous_pos = empty_block.position;
                        BlockScript thisblock = hit.transform.GetComponent<BlockScript>(); 
                        empty_block.position = thisblock.target_pos;
                        thisblock.target_pos = previous_pos;

                    }
                }
            }
        }
    }

    public void shuffle() {
        do
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                var last_pos = blocks[i].target_pos;
                int randomIndex = Random.Range(0, blocks.Length);
                blocks[i].target_pos = blocks[randomIndex].target_pos;
                blocks[randomIndex].target_pos = last_pos;

                var block = blocks[i];
                blocks[i] = blocks[randomIndex];
                blocks[randomIndex] = block;
            }
        } while (GetInversions() % 2 != 0);
    }

    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < blocks.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < blocks.Length; j++)
            {
                if (blocks[j] != null)
                {
                    if (blocks[i].number > blocks[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }

 */   
}
