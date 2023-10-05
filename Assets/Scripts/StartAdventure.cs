using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAdventure : MonoBehaviour
{
   
    ParticleSystem burst;
    [SerializeField]
    ParticleSystem continuous;
    SpriteRenderer spriteRenderer;




    void Start()
    {
        burst = GetComponent<ParticleSystem>();
        continuous.Play(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   public void burstAndFadeButton() 
    
    {

        continuous.Stop(false,ParticleSystemStopBehavior.StopEmitting);
        burst.Play();
        StartCoroutine(ButtonFading());
    }

    IEnumerator ButtonFading() 
    
    { while (true)
        {
            yield return new WaitForEndOfFrame();

            float alpha = spriteRenderer.color.a;
            alpha -= Time.deltaTime;

            Color newColor = new Color(1, 1, 1, alpha);
            spriteRenderer.color = newColor;
        }
    }
  
}
