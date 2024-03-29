﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timer;
    AudioSource audioSource;
    AudioClip otherClip;
    bool isPaused = false;
    [SerializeField] CharacterAnims plr1;
    [SerializeField] CharacterAnims plr2;
    [SerializeField] AudioClip[] clips;
    [SerializeField] GameObject strikeCanvas;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] Text countdownText;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        strikeCanvas.SetActive(false);
        timer = Random.Range(10, 30);
        plr1.SetTimer(timer);
        plr2.SetTimer(timer);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(clips[0]);
        Countdown();
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = timer.ToString();
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Pause();
            isPaused = !isPaused;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Unpause();
            isPaused = !isPaused;
        }

    }

    void Pause()
    {
        Debug.Log("Paused");
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }

    void Unpause()
    {
        Debug.Log("Un-Paused");
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        audioSource.PlayOneShot(clips[4]);
        SceneManager.LoadSceneAsync(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Countdown()
    {
        Invoke("Strike", timer);
    }

    void Strike()
    {
        strikeCanvas.SetActive(true);
        StartCoroutine(CheckPress());
        audioSource.Stop();
        audioSource.PlayOneShot(clips[5]);
        audioSource.PlayOneShot(clips[1]);
        audioSource.PlayOneShot(clips[2]);
        otherClip = clips[3];
        audioSource.Play();
        audioSource.loop = true;
    }

    IEnumerator CheckPress()
    {
        float difficulty = 0.25f;
        bool success = false;
        while (success == false && difficulty > 0f)
        {
            difficulty -= Time.deltaTime;
            success = Input.GetKeyDown(KeyCode.Space);
            yield return null;
        }
        if (success == false)
        {            
            Debug.Log("Failed");
            strikeCanvas.SetActive(false);
            CharacterAnims.win = false;
            yield return new WaitForSeconds(3);
            loseCanvas.SetActive(true);
            yield break;
        }
        else if (success)
        {            
            Debug.Log("Won");
            strikeCanvas.SetActive(false);
            CharacterAnims.win = true;
            yield return new WaitForSeconds(3);
            winCanvas.SetActive(true);
        }
    }

}