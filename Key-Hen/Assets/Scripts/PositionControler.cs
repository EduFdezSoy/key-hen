using UnityEngine;

public class PositionControler : MonoBehaviour
{
    GameObject _fatherPositions;
    public Transform[] positions;
    protected bool[] filledPositions = new bool[10];
    protected string[] filledKeycode = new string[10];
    public KeyboardController keyboardController;
    public PadManager padManager;

    private GameObject[] keyboardArray;
    private void Start()
    {
        while (!keyboardController.hasArrayReady())
        {

        }
        keyboardArray = keyboardController.getArray();
    }

    public int isFilledOut(Key keycode)
    {
        while (true)
        {
            if (hasSpace())
            {
                int r = UnityEngine.Random.Range(0, filledPositions.Length);
                
                if (!filledPositions[r])
                {
                    fillSpace(r);
                    fillKeyCode(r, keycode._name);
                    keycode.moveTo(positions[r].position);

                    return r;
                }
            } 
            else
            {
                return -1;
            }
        }
    }

    public bool hasSpace()
    {
        for (int i = 0; i < filledPositions.Length; i++)
        {
            if (!filledPositions[i])
            {
                return true;
            }
        }
        return false;
    }

    private void fillKeyCode(int pos, string keycode)
    {
        filledKeycode[pos] = keycode;
    }

    public void fillSpace(int pos)
    {
        filledPositions[pos] = true;
    }

    public void takeLetter(Key keycode)
    {
        for (int i = 0; i < filledKeycode.Length; i++)
        {

            if (filledKeycode[i] != null && filledKeycode[i].Equals(keycode._name))
            {
                filledPositions[i] = false;
                // if -1 mata la pieza
                int valor = padManager.isFilledOut(keycode);
                if (valor == -1)
                {
                    GameManager.instance.takeDamage(GameManager.POSITIONCONTROLLER, keycode);
                }
                else
                {
                    keycode.moveToPad();
                }
                break;
            }
        }
    }
}
