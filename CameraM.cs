using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraM : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 1.0f;

    public GameObject Camera;
    private Spawnsystem spawnSystem;
    Vector3 firstscenetarget = new Vector3(-78, 2, -21);
    Vector3 secondSceneTarget = new Vector3(-54, 2, -21);
    Vector3 thirdSceneTarget = new Vector3(-30, 2, -31);
    Vector3 rightSceneTarget = new Vector3(-26, 2, -53);
    Vector3 leftSceneTarget = new Vector3(-12, 2, -23);
    Vector3 churchScenetarget = new Vector3(-63, 4, -96);
    Vector3 lastSceneTarget = new Vector3(20, 2, -2);



    public GameObject rdyScreen;
    public Transform left_text;
    public Transform right_text;
    public int status;
    private int activeStatus;
    





    // Start is called before the first frame update
    void Start()
    {


        status = 0;
        activeStatus = 0;
        left_text.gameObject.SetActive(false);
        right_text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (status != activeStatus)
        {
            //Invoke("readyToGo", 1.0f);
        }

        switch (status)
        {



            case 1:
                Debug.Log("1");
                activeStatus = status;

                rdyScreen.gameObject.SetActive(false);
                transform.position = Vector3.MoveTowards(transform.position, firstscenetarget, Time.deltaTime * Speed * 4);
                Vector3 to = new Vector3(0, 90, 0);
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime * Speed);



                break;
            case 2:
                Debug.Log("2");
                activeStatus = status;
                transform.position = Vector3.MoveTowards(transform.position, secondSceneTarget, Time.deltaTime * Speed * 4);
                Vector3 three = new Vector3(0, 0, 0);
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, three, Time.deltaTime * Speed);

                break;
            case 3:
                Debug.Log("3");
                activeStatus = status;
                transform.position = Vector3.MoveTowards(transform.position, thirdSceneTarget, Time.deltaTime * Speed * 4);
                Vector3 four = new Vector3(0, 125, 0);
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, four, Time.deltaTime * Speed);

                break;
            case 4:
                Debug.Log("4");
                activeStatus = status;
                left_text.gameObject.SetActive(true);
                right_text.gameObject.SetActive(true);


                break;
            case 5:
                Debug.Log("5");
                activeStatus = status;
                transform.position = Vector3.MoveTowards(transform.position, rightSceneTarget, Time.deltaTime * Speed * 4);
                Vector3 six = new Vector3(0, 200, 0);
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, six, Time.deltaTime * Speed);
                right_text.gameObject.SetActive(false);
                left_text.gameObject.SetActive(false);

                break;
            case 6:
                Debug.Log("6");
                activeStatus = status;
                transform.position = Vector3.MoveTowards(transform.position, leftSceneTarget, Time.deltaTime * Speed * 4);
                Vector3 seven = new Vector3(0, 30, 0);
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, seven, Time.deltaTime * Speed);
                left_text.gameObject.SetActive(false);
                right_text.gameObject.SetActive(false);

                break;
            case 7:
                Debug.Log("7");
                activeStatus = status;
                transform.position = Vector3.MoveTowards(transform.position, churchScenetarget, Time.deltaTime * Speed * 4);
                Vector3 eight = new Vector3(0, 160, 0);
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, eight, Time.deltaTime * Speed);





                break;
            case 9:
                Debug.Log("9");
                activeStatus = status;
                transform.position = Vector3.MoveTowards(transform.position, lastSceneTarget, Time.deltaTime * Speed * 4);
                Vector3 nine = new Vector3(0, 180, 0);
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, nine, Time.deltaTime * Speed);


                break;
            default:
                Debug.Log("dddd");
                break;
        }

    }

    public void readyToGo()
    {


        if (status < 4)
        {
            status++;
        }

        if (status == 5)
        {
            status = 7;
        }

        if (status == 6)
        {
            status = 9;
        }


    }

}

