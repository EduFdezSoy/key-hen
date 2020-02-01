using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject _pausePanel;
    public GameObject _deathPanel;
    private bool _paused = false;
    private bool _gameOver = false;

    private int _keyInPad = 0;
    private int _maxKeyInPad = 8;
    private int _keysOut = 0;
    private int _maxKeysOut = 12;
    
    private float _health = 3f;

    public AudioSource _musicManager;

    public TextMeshProUGUI _txtTiempo;

    private List<GameObject> _listadoTeclas;

    public float _startWait;
    public Image imageHealth;

    public int KeyInPad { get => _keyInPad; set => _keyInPad = value; }
    public int MaxKeyInPad { get => _maxKeyInPad; set => _maxKeyInPad = value; }
    public int KeysOut { get => _keysOut; set => _keysOut = value; }
    public int MaxKeysOut { get => _maxKeysOut; set => _maxKeysOut = value; }
    
    public float Health { get => _health; set => _health = value; }

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

    public bool isPadFull()
    {
        return KeyInPad >= MaxKeyInPad;
    }

    public bool isOutFull()
    {
        return KeysOut >= MaxKeysOut;
    }

    public void addKeytoPad()
    {
        KeyInPad++;
        KeysOut--;
    }

    public void addKeyOut()
    {
        KeysOut++;
    }

    public void takeDamage()
    {
        Debug.Log(Health);
        Health--;
        Debug.Log(Health);
        updateUI();
    }

    private void updateUI()
    {
        imageHealth.fillAmount = Health / 3;

        Debug.Log(Health/3f);

        //TODO: Actualizar teclas tambien aqui y reutilizamos codigo
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
