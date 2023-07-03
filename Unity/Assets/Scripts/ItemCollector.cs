 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int itemCount = 0;
    [SerializeField] private Text appleTexts;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            itemCount++;
            // Debug.Log("itemCount:"+itemCount);
            appleTexts.text = "Apple :"+itemCount;
        }    
    }
}
