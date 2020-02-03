using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public const int KEYBOARDCONTROLLER = 1;
    public const int POSITIONCONTROLLER = 2;

    //Singleton
    public static GameManager instance;
    //Panel of paused states and states boolens
    public GameObject _pausePanel;
    public GameObject _deathPanel;
    public GameObject _howToPanel;
    private bool _paused = false;
    private bool _gameOver = false;
    //Game Health
    private float _health = 3f;
    //Current time of sesion
    private int gameTime;
    //MusicManager
    public AudioSource _musicManager;
    //Listado de teclas en juego
    private List<GameObject> _listadoTeclas;
    //Time to wait before start
    public float _startWait;
    //UI elements
    public Image imageHealth;
    public TextMeshProUGUI _txtTiempo;
    public TextMeshProUGUI _txtPoints;
    //Points of sesion
    private float _points;
    private float timeScale = 1;
    private bool juegoEmpezado = false;

    public float Health { get => _health; set => _health = value; }
    public float Points { get => _points; set => _points = value; }

    //First method to be called
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        _listadoTeclas = new List<GameObject>();
    }

    public void startRound()
    {
        StartCoroutine(StartGame());
    }


    //Add points
    public void addPoints()
    {
        Points++;
        updateUI();
    }
    //Minus -1 health when called
    public void takeDamage(int OYENINODEQUIENERE, Key key)
    {
        if (OYENINODEQUIENERE == KEYBOARDCONTROLLER)
        {
            PositionControler pc = GameObject.Find("fatherPositions").GetComponent<PositionControler>();
            Debug.Log(pc.hasSpace());
            if (!pc.hasSpace())
            {
                damaged();
                key.outOfGame();
            }
        }
        else if (OYENINODEQUIENERE == POSITIONCONTROLLER)
        {
            PadManager pm = GameObject.Find("Teclado").GetComponent<PadManager>();
            if (!pm.hasSpace())
            {
                damaged();
                key.outOfGame();
            }
        }
    }

    private void damaged()
    {
        Health--;
        updateUI();
        if (Health == 0)
        {
            SetGameOver(true);
        }
    }

    /*
     * Update the info in the UI
     */
    private void updateUI()
    {
        imageHealth.fillAmount = Health / 3;
        // Debug.Log(Health/3f);
        _txtTiempo.text = gameTime.ToString() + " s";
        _txtPoints.text = Points + " pts";
    }
    //This corustine called when game is gonna start
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(_startWait);
        juegoEmpezado = true;
        //TODO: Logica de juego, referencia a Pajaro para iniciar su movimiento y el del juegador
        Time.timeScale = 1;
        StartContador();
    }
    //Starts the counter
    private void StartContador()
    {
        gameTime = 0;
        StartCoroutine(TimeCounter());
    }
    //Adds +1 to the counter every seconds except 
    IEnumerator TimeCounter()
    {
        if (Time.timeScale == 0)
        {
            yield return new WaitForSecondsRealtime(0f);
        }
        else
        {
            updateUI();
            yield return new WaitForSecondsRealtime(1f);
            gameTime++;
            if (gameTime % 10 == 0)
            {
                timeScale += 1f;
                Time.timeScale = timeScale;
            }
        }
        StartCoroutine(TimeCounter());
    }
    //Updates, you know. That one
    void Update()
    {
        if (juegoEmpezado)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetPauseGame(!_paused);
            }
        }
    }
    //Sets the game to game over, pausing time 
    public void SetGameOver(bool gameOver)
    {
        _gameOver = gameOver;
        Time.timeScale = gameOver ? 0 : timeScale;
        _deathPanel.SetActive(gameOver);
    }
    //Pauses game
    public void SetPauseGame(bool pause)
    {
        if (!_deathPanel.activeSelf)
        {
            _paused = pause;
            Time.timeScale = pause ? 0 : timeScale;
            _pausePanel.SetActive(pause);
        }
    }
    //Ask if game is paused
    public bool IsGamePaused()
    {
        return _paused;
    }
    //Return the time to 1
    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
