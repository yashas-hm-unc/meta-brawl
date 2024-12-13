using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gestureStateHandler : MonoBehaviour
{
    // Start is called before the first frame update
    // 0=>thumbsUpRight, 1=>thumbsDownRight, 2=>thumbsUpLeft, 3=>thumbsDownLeft, 4=>fistRight, 5=>fistLeft, 6=>pointRight, 7=>pointLeft, 8=>clawRight, 9=>clawLeft,
    private bool[] gestureState = { false, false, false, false, false, false, false, false, false, false };
    private GameObject[] gameObjects = { null, null, null, null, null, null, null, null, null, null };

    public GameObject palmHolderLeft;
    public GameObject palmHolderRight;
    public GameObject Rasengan;
    public TMP_Text mainObject;
    private int count = 0;

    void FixedUpdate()
    {
        string a = "";
        for(int i=0; i< 10; i++)
        {
            if (gestureState[i])
            {
                a += i.ToString()+" ";
            }
        }
        mainObject.text = a + count.ToString() + "gestures made";

    }

    public void updateGestureStateTrue(int a)
    {
        gestureState[a] = true;
        if (a == 8)
        {
            GameObject rasengan_right = Instantiate(Rasengan, new Vector3(0, 0, 0), Quaternion.identity);
            gameObjects[8] = rasengan_right;
            rasengan_right.transform.SetParent(palmHolderRight.transform);
            rasengan_right.transform.localPosition = new Vector3(0, -0.1f, 0);
            rasengan_right.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            count++;
        }
        if (a == 9)
        {
            GameObject rasengan_left = Instantiate(Rasengan, new Vector3(0, 0, 0), Quaternion.identity);
            gameObjects[9] = rasengan_left;
            rasengan_left.transform.SetParent(palmHolderLeft.transform);
            rasengan_left.transform.localPosition = new Vector3(0, 0.1f, 0);
            rasengan_left.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            count++;
        }
    }

    public void updateGestureStateFalse(int a)
    {
        gestureState[a] = false;
        if (a == 8)
        {
            Destroy(gameObjects[8]);
            count--;
        }
        if (a == 9)
        {
            Destroy(gameObjects[9]);
            count--;
        }
    }

    public bool getGestureState(int a)
    {
        return gestureState[a];
    }

}
