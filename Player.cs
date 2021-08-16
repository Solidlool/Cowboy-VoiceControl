using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public  int Health;
    public GameObject Died;
    public GameObject Hearth;
    public GameObject Hearth2;
    public GameObject Hearth3;
    public Transform left_text;
    public Transform right_text;
    public CameraM Kamera;


  

    
    
    public AudioClip revolverSound;
    public AudioSource sound1;
    public AudioClip reloadsound;
    public AudioSource sound2;
    
    
    public float ammo;
    public Transform ammo_text;

    public GameObject Reloadtext;

    // Start is called before the first frame update
    void Start()
    {


        ammo = 6;
        Died.gameObject.SetActive(false);
        Health = 3;
        Reloadtext.gameObject.SetActive(false);
        left_text.gameObject.SetActive(false);
        right_text.gameObject.SetActive(false);
        



        GameObject g = GameObject.FindGameObjectWithTag("MainCamera");
        Kamera = g.GetComponent<CameraM>();

        sound1 = gameObject.AddComponent<AudioSource>();
        sound1.playOnAwake = false;
        sound1.clip = revolverSound;
        sound1.Stop();

        sound2.playOnAwake = false;
        sound2.clip = reloadsound;
        sound2.Stop();




    }

    // Update is called once per frame
    void Update()
    {

        ammo_text.GetComponent<Text>().text = ammo.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown("r"))
        {
            Reload();
        }
      

        
        if (Health == 2)
        {
            Hearth3.gameObject.SetActive(false);
        }

        if(Health < 2)
        {
            Hearth2.gameObject.SetActive(false);
        }

        if (Health >= 3)
        {
            Hearth3.gameObject.SetActive(true);
            Hearth2.gameObject.SetActive(true);
        }

       
    }
    public void damagePlayer()
    {
        if (Health >= 1)
        {
            Health -= 1;



       }

        if(Health <= 0)
        {
            Hearth.gameObject.SetActive(false);
            Died.gameObject.SetActive(true);
            SceneManager.LoadScene("Wild_West_Demo_Scene");
            
        }
        



    }

    public void Shoot()

    {
        if (ammo >= 1)
        {
            ammo -= 1;
            sound1.Play();


            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit))

            {
               
                    PrintName(hit.transform.gameObject);
                {


                    if (hit.transform.tag == "Gunman")
                    {

                        Destroy(hit.transform.gameObject);
                    }

                    if (hit.transform.tag == "Healthpack")
                    {
                        Heal();

                    }



                }
            }

            if (ammo <= 0)
            {
                Reloadtext.gameObject.SetActive(true);
                
            }
        }

    }
    private void PrintName(GameObject go)
    {
        print(go.name);
    }


    public void Heal()
    {
        Health = 3;
    }

    public void Reload()
    {
        Reloadtext.gameObject.SetActive(false);
        ammo = 6;
        sound2.Play();
    }
}
