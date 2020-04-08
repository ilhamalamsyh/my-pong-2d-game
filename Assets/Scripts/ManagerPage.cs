using UnityEngine;
using UnityEngine.SceneManagement; //Digunakan untuk mengakses method-method mengelola scene.

public class ManagerPage : MonoBehaviour{
    public bool isEscapeToExit;//Digunakan untuk menentukan fungsi tombol Escape untuk kembali ke Menu atau ke Main (Gameplay).
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     //Ketika menekan tombol Escape, jika nilai isEscapeToExit bernilai benar maka akan keluar dari Game dan jika tidak maka akan kembali ke Menu.
     if (Input.GetKeyUp(KeyCode.Escape)){
         if (isEscapeToExit){
             Application.Quit();
         }else{
             backToMenu();
         }
     }   
    }

    public void startGame(){
        SceneManager.LoadScene("Main");
    }

    public void backToMenu(){
        SceneManager.LoadScene("Menu");
    }
}
