using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void comenzarJuego()
    {
        gameObject.active = false;
        GameManager.instance.
        SetPauseGame(false);
        GameManager.instance.startRound();
    }
}
