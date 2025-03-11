using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class restart_scene : MonoBehaviour { 
    void Update() 
    { if (Input.GetKey("r")) 
        { 
            Restart(); 
        } 
    } 
    
    void Restart() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    } 
}