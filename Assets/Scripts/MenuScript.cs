using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject startButton, hornButtons, HUDText, endScreen;
    [SerializeField] Animator cowCamAnimator;
    [SerializeField] int camStartSize = 0, camDefaultSize = 70, camEndGameSize = 25;

    bool startButtonPressed;
    bool gameFinished;

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
        }
    }

    public void StartGame()
    {
        gameFinished = false;
        cowCamAnimator.SetTrigger("StartGame");
        startButton.SetActive(false);
        SoundManager.Instance.BGMSound();
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
        SceneManager.LoadScene(0);
    }
}
