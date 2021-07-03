using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private int tile_pos, num;

    private Vector3 target_pos;
    // Start is called before the first frame update
    void Start()
    {
        set_targetpos(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        set_text(num);
        transform.position = Vector3.Lerp(transform.position,target_pos,0.3f);
        if (tile_pos == num)
        {
            set_color(Color.green);
        }
        else {
            set_color(Color.white);
        }
    }

    public Vector3 get_targetpos() {
        return target_pos;
    }

    public void set_targetpos(Vector3 pos) {
        target_pos = pos;
    }

    public void set_color(Color color) {
        GetComponent<Image>().color = color;
    }

    public int get_tilepos() {
        return tile_pos;
    }

    public void set_tilepos(int pos) {
        tile_pos = pos;
    }

    public void set_text(int num) {
        GetComponentInChildren<Text>().text = num.ToString("0");
    }

    public int get_num() {

        return num;
    }

    public void set_num(int number) {
        num = number;
    }

    public bool inpos() {
        return tile_pos == num;
    }
}
