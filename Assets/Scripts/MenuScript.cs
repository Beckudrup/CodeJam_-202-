using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject startButton, hornButtons, HUDText, endScreen;
    [SerializeField] Animator cowCamAnimator, grabTextAnimator;
    [SerializeField] int camStartSize = 0, camDefaultSize = 70;
    private int startScreen = 0;
    bool startButtonPressed;
    bool gameFinished;
    public bool gameStarted;
    public bool timeStop;
    void Awake()
    {
        mainCam.fieldOfView = camStartSize;
        HUDText.SetActive(false);
        hornButtons.SetActive(false);
        endScreen.SetActive(false);
    }

    void LateUpdate()
    {
        var threshold = 1;
        if (mainCam.fieldOfView > camDefaultSize - threshold && gameFinished == false)
        {
            HUDText.SetActive(true);
            hornButtons.SetActive(true);
            grabTextAnimator.SetTrigger("StartGame");
        }
    }

    public void StartGame()
    {
        gameFinished = false;
        cowCamAnimator.SetTrigger("StartGame");
        startButton.SetActive(false);
        SoundManager.Instance.BGMSound();
        //Timer.Instance.gameStarted = false;

    }

    public void EndGame()
    {
        if (gameFinished) return;
        cowCamAnimator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        hornButtons.SetActive(false);
        HUDText.SetActive(false);
        endScreen.SetActive(true);
        score.SetScoreOnEndScreen();
        cowCamAnimator.SetTrigger("GameFinish");
        SoundManager.Instance.MooSound();
        SoundManager.Instance.CowbellSound();
        gameFinished = true;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(startScreen);
        Timer.Instance.timeLeft = 10.0f;
        //Timer.Instance.timeStop = false;
        gameFinished = false;

    }
}
