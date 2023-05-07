using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] Image milkshake;
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject startButton, hornButtons, HUDText, endScreen, scoreUI;
    [SerializeField] Animator cowCamAnimator, grabTextAnimator;
    [SerializeField] int camStartSize = 0, camDefaultSize = 70;

    float milkshakeFillTime;
    bool fillMilkshake, milkshakeFilled, startButtonPressed, gameFinished;

    Color[] milkshakeFlavors = { new(.9f, .8f, .7f), new(.8f, .4f, .6f), new(.5f, .3f, .2f) };
    Image previousMilkshake;

    void Awake()
    {
        mainCam.fieldOfView = camStartSize;
        HUDText.SetActive(false);
        hornButtons.SetActive(false);
        endScreen.SetActive(false);
        scoreUI.SetActive(false);
    }

    void OnEnable()
    {
        GameEvents.GameEnded += GameEnded;
        GameEvents.FinishGameAnimPlayed += FillMilkshake;
    }

    void OnDisable()
    {
        GameEvents.GameEnded -= GameEnded;
        GameEvents.FinishGameAnimPlayed -= FillMilkshake;
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

    void Update()
    {
        MilkshakeFill();
    }

    public void GameStarted()
    {
        gameFinished = false;
        cowCamAnimator.SetTrigger("StartGame");
        startButton.SetActive(false);
        SoundManager.Instance.BGMSound();
    }

    void GameEnded()
    {
        if (gameFinished) return;
        cowCamAnimator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        hornButtons.SetActive(false);
        HUDText.SetActive(false);
        cowCamAnimator.SetTrigger("GameFinish");
        SoundManager.Instance.MooSound();
        SoundManager.Instance.CowbellSound();
        gameFinished = true;
    }

    void FillMilkshake()
    {
        fillMilkshake = true;
    }

    void MilkshakeFill()
    {
        if (milkshakeFilled || !fillMilkshake) return;
        var milkshakeFillStart = 0f;
        var scoreToMilkshake = 1000f;
        var milkshakeFillTarget = Score.Instance.scoreValue / scoreToMilkshake;
        var duration = 2;
        var oneMilkshake = 1;
        milkshakeFillTime += Time.deltaTime;
        scoreUI.SetActive(true);
        SoundManager.Instance.MilkshakeSound();
        
        milkshake.color = milkshakeFlavors[0];
        milkshake.fillAmount = Mathf.Lerp(milkshakeFillStart,milkshakeFillTarget,milkshakeFillTime / duration);
        if (milkshake.fillAmount >= oneMilkshake)
        {
            duration++;
            milkshakeFillTarget--;
            milkshake.fillAmount = Mathf.Lerp(milkshakeFillStart,milkshakeFillTarget,milkshakeFillTime / duration);
            milkshake.color = milkshakeFlavors[1];
            if (milkshake.fillAmount >= oneMilkshake)
            {
                duration++;
                milkshakeFillTarget--;
                milkshake.fillAmount = Mathf.Lerp(milkshakeFillStart,milkshakeFillTarget,milkshakeFillTime / duration);
                milkshake.color = milkshakeFlavors[2];
            }
        }
        Invoke(nameof(MilkshakeHasBeenFilled), duration+milkshakeFillTarget);
    }


    void MilkshakeHasBeenFilled()
    {
        endScreen.SetActive(true);
        SoundManager.Instance.MilkshakeSoundStop();
        milkshakeFilled = true;
    }
    
    public void ResetGame() //Accessed by Reset Button
    {
        SceneManager.LoadScene(0);
    }
}
