using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{

    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == 6){
            animator.Play("Death Animation");
            Invoke("RestartScence", 1);
        }
    }

    void RestartScence(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
