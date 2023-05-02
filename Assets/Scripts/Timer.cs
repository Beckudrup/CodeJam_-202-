using System;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float timeLeft = 10.0f;
    [SerializeField] GameObject leftButton, rightButton, grabText;
    [SerializeField] public HornButtons hornButtons;
    [SerializeField] public MenuScript menu;

    //    public bool gameStarted;
    //    public bool timeStop;

    public static Timer Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);

        }
        timer.alpha = 0;

    }

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void FixedUpdate()
    {
        if (menu.timeStop) return;
        if (hornButtons.leftHornButton && hornButtons.rightHornButton)
        {
            grabText.SetActive(false);

            timer.alpha = 1;
            menu.gameStarted = true;

        }

        if (menu.gameStarted)
        {
            
            timer.text = timeLeft.ToString("0.0"); 
            timeLeft -= Time.deltaTime;
        }

        if (timeLeft <= 0)
        {
            SoundManager.Instance.CowbellSound();
            timeLeft = 0;
            timer.text = "Time is up!\n\nStop shaking!";
            hornButtons.leftHornButton = false;
            hornButtons.rightHornButton = false;
            leftButton.SetActive(false);
            rightButton.SetActive(false);
            menu.timeStop = true;
        }
    }
    /*
    public void restartTime() {

        timeLeft = 10.0f;
    }
    */


}
