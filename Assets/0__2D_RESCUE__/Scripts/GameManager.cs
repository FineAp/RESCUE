using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text countdownText;  // 카운트 다운 텍스트
    public float totalTime = 10f;  // 카운트 다운 시간
    public GameObject player;
    public GameObject gameOverSm;


    private float currentTime;  // 현재 카운트 다운 시간
    private GameObject gameOverImg;
    private GameObject mainCam;
    private AudioSource gameStartSm;


    void Start()
    {
        currentTime = totalTime;  // 초기화

        gameOverImg = GameObject.Find("IMG_GameOver");
        gameOverImg.SetActive(false);

        mainCam = GameObject.Find("Main Camera");
        gameStartSm = mainCam.GetComponent<AudioSource>();


        // 0.01초마다 UpdateCountdown 함수 호출
        InvokeRepeating("UpdateCountdown", 0f, 1f);
    }

    void UpdateCountdown()
    {
        // 현재 카운트 다운 시간 감소
        currentTime -= 1f;

        // 카운트 다운 종료
        if (currentTime <= 0f)
        {
            currentTime = 0f;
            CancelInvoke("UpdateCountdown");
            GameOver();
            print("0초당");
        }

        // 카운트 다운 텍스트 업데이트
        int seconds = (int)currentTime % 60;
        int milliseconds = (int)(currentTime * 100f) % 100;
        string countdownString = string.Format("{0:00}:{1:00}", seconds, milliseconds);
        countdownText.text = countdownString;
    }

    public void GameOver()
    {
        gameOverImg.SetActive(true);
        player.SetActive(false);
        gameOverSm.SetActive(true);

        gameStartSm.Stop();
        

    }
}
