using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Transform Playertarget;
    private Transform target;
    public float speed =1.0f;
    public float turnRate;
    private bool canIMove;

    public AudioClip revolverSound;
    public AudioSource sound1;




    // Start is called before the first frame update
    void Start()
    {
        canIMove = true;
        target = GameObject.FindWithTag("enemytarget").transform;
        Playertarget = GameObject.FindWithTag("MainCamera").transform;
        

        sound1 = gameObject.AddComponent<AudioSource>();
        sound1.playOnAwake = false;
        sound1.clip = revolverSound;
        sound1.Stop();

        InvokeRepeating("Shoot", 6f, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (canIMove == true)
        {

            float move = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, move);
            transform.LookAt(Playertarget);



           

        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Gunman")
        {
            

            canIMove = false;


        }
    }

    private void Shoot()
    {
        Playertarget.GetComponent<Player>().damagePlayer();
        sound1.Play();
    }





}
