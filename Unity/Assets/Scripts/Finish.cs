using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject waypoint;
    [SerializeField] private GameObject Player;
    private AudioSource finishSound;
    [SerializeField] private float speed = 2f;
    private bool isFinished;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
     private void Update()
    {
        if(isFinished){
            transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, Time.deltaTime * speed);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Player"){
            finishSound.Play();
            isFinished =true;
            Player.SetActive(false);
            Invoke("CompleteLevel",6f);
            CompleteLevel();
        }
        
    }
    private void CompleteLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
