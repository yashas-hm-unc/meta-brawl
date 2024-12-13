using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gestureStateHandler : MonoBehaviour
{
    // Start is called before the first frame update
    // 0=>thumbsUpRight, 1=>thumbsUpLeft, 2=>thumbsDownRight, 3=>thumbsDownLeft, 4=>fistRight, 5=>fistLeft, 6=>pointRight, 7=>pointLeft, 8=>clawRight, 9=>clawLeft,
    private bool[] gestureState = { false, false, false, false, false, false, false, false, false, false };
    private GameObject[] gameObjects = { null, null, null, null, null, null, null, null, null, null };

    public GameObject palmHolderLeft;
    public GameObject palmHolderRight;
    public GameObject Rasengan;
    public GameObject Mjolnir;
    public GameObject CameraRig;
    public TMP_Text mainObject;
    private int count = 0;

    void Update()
    {
        string a = "";
        for(int i=0; i< 10; i++)
        {
            if (gestureState[i])
            {
                a += i.ToString()+" ";
            }
            if (gameObjects[i] != null)
            {
                if (i % 2 == 0)
                {
                    gameObjects[i].transform.position = palmHolderRight.transform.position - 0.1f * palmHolderRight.transform.up;
                }
                if (i % 2 == 1)
                {
                    gameObjects[i].transform.position = palmHolderLeft.transform.position + 0.1f * palmHolderLeft.transform.up;
                }
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
            rasengan_right.transform.SetParent(CameraRig.transform);
            rasengan_right.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            count++;
        }
        if (a == 9)
        {
            GameObject rasengan_left = Instantiate(Rasengan, new Vector3(0, 0, 0), Quaternion.identity);
            gameObjects[9] = rasengan_left;
            rasengan_left.transform.SetParent(CameraRig.transform);
            rasengan_left.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            count++;
        }
        if (a == 4)
        {
            GameObject mjolnir_right = Instantiate(Mjolnir, new Vector3(0, 0, 0), Quaternion.identity);
            gameObjects[4] = mjolnir_right;
            mjolnir_right.transform.SetParent(CameraRig.transform);
            mjolnir_right.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            count++;
        }
        if (a == 5)
        {
            GameObject mjolnir_left = Instantiate(Mjolnir, new Vector3(0, 0, 0), Quaternion.identity);
            gameObjects[5] = mjolnir_left;
            mjolnir_left.transform.SetParent(CameraRig.transform);
            mjolnir_left.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
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
        if (a == 4)
        {
            Destroy(gameObjects[4]);
            count--;
        }
        if (a == 5)
        {
            Destroy(gameObjects[5]);
            count--;
        }
    }

    public bool getGestureState(int a)
    {
        return gestureState[a];
    }

}
