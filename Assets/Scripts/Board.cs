using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static bool iswon=false;

    [SerializeField]
    private int Emp_Tile_Pos;

    [SerializeField]
    private Transform Empty_Block;

    //[SerializeField]
    private float distance;

    [SerializeField]
    private Transform[] Tile_transforms;

    [SerializeField]
    private Tile[] Tiles;

    private Vector3[] targets;

    // Start is called before the first frame update
    void Start()
    {
        targets_setter();
        shuffle();

        iswon = false;

        distance = Vector2.Distance(a: targets[1], b: targets[2]) + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                //if hit
                if (hit)
                {
                    Debug.Log(Vector2.Distance(a: hit.transform.position, b: Empty_Block.position));
                    if (Vector2.Distance(a: hit.transform.position, b: Empty_Block.position) < distance)
                    {
                        Sound_Manager.playSound("Block_Moment");
                        moment(hit);
                        wincheck();
                    }
                }
            }
        }
    }

    public void targets_setter() {
        targets = new Vector3[Tile_transforms.Length + 1];
        for (int i = 0; i < Tile_transforms.Length; i++)
        {
            //Debug.Log(Tile_transforms[i].position);
            targets[i] = Tile_transforms[i].position;
        }
    }

    private void moment(RaycastHit2D hit) {
        //Moving Tile
        Tile tile = hit.transform.GetComponent<Tile>();
        Debug.Log(Emp_Tile_Pos);
        tile.set_targetpos(targets[Emp_Tile_Pos - 1]);

        //Moving Empty tile
        Empty_Block.position = targets[tile.get_tilepos() - 1];

        //Changing Tile pos values
        var temp = tile.get_tilepos();
        tile.set_tilepos(Emp_Tile_Pos);
        Emp_Tile_Pos = temp;
    }

    public void shuffle() {
        do {
            for (int i = 0; i < Tiles.Length; i++)
            {
                int randomIndex = Random.RandomRange(0,Tiles.Length);
                var last_num = Tiles[i].get_num();
                Tiles[i].set_num(Tiles[randomIndex].get_num());
                Tiles[randomIndex].set_num(last_num);
            }
        } while (inversion()%2 != 0);

        //Debug.Log("Shuffled");
        arrange();
    }

    void arrange() {
        for (int i = 0; i < Tiles.Length; i++) {
            Tile_transforms[i].position = targets[i];
            //Tiles[i].set_targetpos(targets[Tiles[i].get_tilepos()]); 
        }
    }

    private int inversion() {

        int inversionsSum = 0;
        for (int i = 0; i < Tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < Tiles.Length; j++)
            {
                if (Tiles[j] != null)
                {
                    if (Tiles[i].get_num() > Tiles[j].get_num())
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }

    private void wincheck() {
        bool won = true;
        foreach (Tile i in Tiles) {
            if (i.inpos())
            {
                continue;
            }
            else {
                won = false;
                break;
            }
        }
        if (won) {
            iswon = true;
            //shuffle();
            Debug.Log("Won");
        }
    }

}
