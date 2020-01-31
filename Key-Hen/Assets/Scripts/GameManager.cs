using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject _pausePanel;
    public GameObject _deathPanel;
    private bool _paused = false;
    private bool _gameOver = false;

    public AudioSource _musicManager;

    public TextMeshProUGUI _txtTiempo;

    private List<GameObject> _listadoTeclas;

    public float _startWait;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        _listadoTeclas = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetPauseGame(false);
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(_startWait);
        //TODO: Logica de juego, referencia a Pajaro para iniciar su movimiento y el del juegador
        Time.timeScale = 1;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SetPauseGame(!_paused);
    }

    public void SetGameOver(bool gameOver)
    {
        _gameOver = gameOver;
        Time.timeScale = gameOver ? 0 : 1;
        _deathPanel.SetActive(gameOver);
        GetComponent<AudioSource>().Stop();
    }
    public void SetPauseGame(bool pause)
    {
        if (!_deathPanel.activeSelf)
        {
            _paused = pause;
            Time.timeScale = pause ? 0 : 1;
            _pausePanel.SetActive(pause);
        }
    }

    public bool IsGamePaused()
    {
        return _paused;
            }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
