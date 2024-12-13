using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestureStateHandle : MonoBehaviour
{
    // Start is called before the first frame update
    // 0=>thumbsUpRight, 1=>thumbsDownRight, 2=>thumbsUpLeft, 3=>thumbsDownLeft, 4=>fistRight, 5=>fistLeft, 6=>pointRight, 7=>pointLeft, 8=>clawRight, 9=>clawLeft,
    private bool[] gestureState = { false, false, false, false, false, false, false, false, false, false };
    // public GameObject mainObject;
    private string a = "";
    void Start()
    {

    }

    void Update()
    {
        a = "";
        for (int i = 0; i < 10; i++)
        {
            if (gestureState[i])
            {
                a += i.ToString();
            }
        }
        //mainObject.text = "a";
    }

    public void updateGestureStateTrue(int a)
    {
        gestureState[a] = true;
    }

    public void updateGestureStateFalse(int a)
    {
        gestureState[a] = false;
    }

    public bool getGestureState(int a)
    {
        return gestureState[a];
    }

}
