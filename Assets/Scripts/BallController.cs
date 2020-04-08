using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Digunakan untuk mengakses komponen-komponen untuk UI.

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    int scoreP1, scoreP2;
    Text scoreUIP1, scoreUIP2, txWinner;
    GameObject finishPanel;
    AudioSource audio;
    public AudioClip hitSound; //Menyimpan berkas audio.

    // Start is called before the first frame update
    void Start()
    {
     audio =GetComponent<AudioSource>();
     rigid = GetComponent<Rigidbody2D>();
     Vector2 arrow = new Vector2 (2, 0).normalized;
     rigid.AddForce (arrow*force);   
     scoreP1 = 0;
     scoreP2 = 0;
     scoreUIP1 = GameObject.Find ("Score 1").GetComponent<Text> ();
     scoreUIP2 = GameObject.Find ("Score 2").GetComponent<Text> ();
     finishPanel = GameObject.Find("FinishPanel");
     //Memanggil GameObject PanelSelesai yang terdapat di Hierarchy. Kemudian memastikan dalam keadaaan nonaktif.
     finishPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll){
            audio.PlayOneShot(hitSound); //Menjalankan sebuah audio.
            if (coll.gameObject.name == "Margin Right"){
                scoreP1 += 1;
                ShowScore();  
                //Jika score paddle 1 more than 5, makan game over layer will be activated
                if (scoreP1 == 5){
                    finishPanel.SetActive(true);
                    txWinner = GameObject.Find("Winner").GetComponent<Text>();
                    txWinner.text = "Blue Player Wins!";
                    Destroy(gameObject); //menghilangkan bola
                    return; //kode selesai dan tidak dilanjutkan
                }
                resetBall();
                Vector2 arrow = new Vector2 (2, 0).normalized;
                rigid.AddForce (arrow*force); 
            }if (coll.gameObject.name == "Margin Left"){
                scoreP2 += 1;
                ShowScore();
                //Jika score paddle 2 more than 5, makan game over layer will be activated
                if (scoreP2 == 5){
                    finishPanel.SetActive(true);
                    txWinner = GameObject.Find("Winner").GetComponent<Text>();
                    txWinner.text = "Red Player Wins!";
                    Destroy(gameObject); //menghilangkan bola
                    return; //kode selesai dan tidak dilanjutkan
                }
                resetBall();
                Vector2 arrow = new Vector2 (-2, 0).normalized;
                rigid.AddForce (arrow*force);   
            }if (coll.gameObject.name == "Paddle 1" || coll.gameObject.name == "Paddle 2"){
                float corner = (transform.position.y - coll.transform.position.y)*5f; //Menghitung seberapa kemiringan yang diberikan ke bola.
                Vector2 arrow = new Vector2(rigid.velocity.x, corner).normalized; //Menentukan arah bola yang akan dipantulkan.
                rigid.velocity = new Vector2(0,0); //Reset gerak bola (dengan kode ini, bola akan diam).
                //Implementasikan arah, kekuatan lontar dan kecepatan setelah bola menyentuh
                // Paddle. Di bagian ini Anda dapat memodifikasi untuk bola semakin cepat dengan menambahkan kelipatan setiap menjalankan kode ini.
                rigid.AddForce(arrow*force*2);    
            }
        }       

    void resetBall(){
        transform.localPosition = new Vector2 (0,0);
        rigid.velocity = new Vector2(0,0);
    }    
    void ShowScore(){
        Debug.Log("Score P1: " + scoreP1 + " Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
    } 
}