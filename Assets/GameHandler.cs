using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestureHandler : MonoBehaviour
{
    // 0 => Thumbs up left, 1 => Thumbs down left, 2 => Nin left
    // 3 => Thumbs up right, 4 => Thumbs down right, 5 => Nin right
    private bool[] gestureState = { false, false, false, false, false };

    private int stage = -1;

    public int frameLimit = 500;
    private int frames = 0;
    private bool stop = false;
    private int gameState = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void updateState()
    {
        if (gestureState[3])
        {
            gameState = 1;
            // go to viewer mode
            SceneManager.LoadScene("yashas");
        }
        if (gestureState[4])
        {
            gameState = 0;
            // go to player mode
            SceneManager.LoadScene("yashas");
        }
    }

    public void updateGestureStateTrue(int a)
    {
        gestureState[a] = true;
    }

    public void updateGestureStateFalse(int a)
    {
        gestureState[a] = false;
    }

    public int getGameState() {
        return gameState;
    }

    void FixedUpdate()
    {
        frames += 1;
        if (frames >= frameLimit)
        {
            frames = 0;
            stage = -1;
        }
        updateState();
    }
}
