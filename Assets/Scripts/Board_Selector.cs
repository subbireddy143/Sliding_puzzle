using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board_Selector : MonoBehaviour
{
    
    [SerializeField]
    private GameObject[] Boards;

    [SerializeField]
    private GameObject[] Play_Time_objects;

    [SerializeField]
    private GameObject Timer,pause_button;

    public static int board_size;

    void Awake() {
        Inactivating_Boards();
    }

    void Start() {

    }

    private void Inactivating_Boards() {
        for (int i = 0; i < Boards.Length; i++) {
            Boards[i].SetActive(false);
        }
    }
    public void board_Selector(GameObject _Board) {
        //_Board.transform.GetComponent<Board>().shuffle();
        Inactivating_Boards();
        Sound_Manager.playSound("Block_Moment");
        _Board.SetActive(true);
    }

    public void close_panel(GameObject panel) {
        Sound_Manager.playSound("Block_Moment");
        panel.SetActive(false);
    }

    public void open_panel(GameObject panel)
    {
        Sound_Manager.playSound("Block_Moment");
        panel.SetActive(true);
    }

    public void change_timer(bool isrunning) {
        Sound_Manager.playSound("Block_Moment");
        if (isrunning)
        {
            pause_button.SetActive(true);
        }
        else {
            pause_button.SetActive(false);
        }
        Timer.transform.GetComponent<TimerScript>().set_isrunning(isrunning);
    }

    public void reset_time(int _time)
    {
        Sound_Manager.playSound("Block_Moment");
        Timer.transform.GetComponent<TimerScript>().set_totaltime(_time);
    }

    public void load_scene(int num = 0) {
        SceneManager.LoadScene(num);
    }

    public void set_boardsize(int size) {
        board_size = size;
    }
}
