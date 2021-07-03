using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    [SerializeField] private int minutes,seconds;
    private float total_time;
    private int fbest_time;
    [SerializeField] private Text time_text;
    public bool isrunning = false;

    [SerializeField]
    private GameObject pause_btn;

    [SerializeField]
    private Text current_time, best_time;
    [SerializeField]
    private GameObject WinPanel,Home_btn;

    private int selector;

    // Start is called before the first frame update
    void Awake()
    {
        total_time = 0;
        set_isrunning(false);

        Home_btn.SetActive(false);
        WinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        selector = Board_Selector.board_size;
        if (isrunning) {
            total_time = (total_time + 1 * Time.deltaTime);

            minutes = (int)(total_time / 60);
            seconds = (int)(total_time % 60);
        }
        time_text.text = minutes.ToString("0") + "  :  " + seconds.ToString("0");

        if (Board.iswon) {
            set_isrunning(false);
            Board.iswon = false;
            //Debug.Log(Board_Selector.board_size);
            selector = Board_Selector.board_size;
            //PlayerPrefs.SetInt("TIS3", 10000);
            switch (selector)
            {

                case 3:
                    if (total_time < PlayerPrefs.GetInt("TIS3", 10000))
                        PlayerPrefs.SetInt("TIS3", (int)total_time);
                    fbest_time = (PlayerPrefs.GetInt("TIS3"));
                    break;
                case 4:
                    if (total_time < PlayerPrefs.GetInt("TIS4", 10000))
                        PlayerPrefs.SetInt("TIS4", (int)total_time);
                    fbest_time = (PlayerPrefs.GetInt("TIS4"));
                    break;
                case 5:
                    if (total_time < PlayerPrefs.GetInt("TIS5", 10000))
                        PlayerPrefs.SetInt("TIS5", (int)total_time);
                    fbest_time = (PlayerPrefs.GetInt("TIS5"));
                    break;
            }
                
            
            StartCoroutine("win");
        }
    }

    public void set_isrunning(bool _bool) {
        isrunning = _bool;
        if (isrunning)
        {
            pause_btn.SetActive(true);
        }
        else {
            pause_btn.SetActive(false);
        }
    }

    public void set_totaltime(int _time) {
        total_time = _time;
    }

    IEnumerator win()
    {
        
        WinPanel.SetActive(true);
        Sound_Manager.playSound("BigWin");
        current_time.text = "Current : " + (int)total_time/60 +" : " + (int)total_time % 60;
        yield return new WaitForSeconds(1);
        show_best();
        AdmobAdsScrpit.RequestFullScreenAD();
        Home_btn.SetActive(true);
        yield return null;
    }
    private void show_best() {
        Debug.Log(PlayerPrefs.GetInt("TIS3"));
        best_time.text = "Best : "+(fbest_time/60).ToString("0")+" : "+ (fbest_time % 60).ToString("0");
    }
}
