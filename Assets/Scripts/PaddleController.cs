using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed, marginTop, marginBottom;
    public string axis; //untuk mengatur input keyboard)
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        /*Untuk memperoleh seberapa besar untuk pergerakan paddle dari Input.GetAxis yang 
        memperoleh nilai diantara -1 sampai 1 yang dikalikan kecepatan dan selisih waktu (Time.deltaTime) 
        supaya dapat berjalan dengan baik di berbagai perangkat.*/
        float movePaddle =  Input.GetAxis(axis) * speed * Time.deltaTime; 
        //memberi batasan margin top dan bottom
        float nextPos = transform.position.y + movePaddle;
        if (nextPos > marginTop){
            movePaddle = 0;
        }
        if (nextPos < marginBottom){
            movePaddle = 0;
        }
        //Implementasi perpindahan terdahap Paddle
        transform.Translate(0, movePaddle, 0); 
    }
}
