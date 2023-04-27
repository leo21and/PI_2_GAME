using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class Vignette : ImageEffectShaderBase
{
   public Vector2 offset;
   public float exp;
   public Color vignetteColor;
   public PlayerDamage playerDamage;

   private bool startShake;

   
   
   private void OnRenderImage(RenderTexture src, RenderTexture dest)
   {
      m_effectMaterial.SetFloat("_OffsetX", offset.x);
      m_effectMaterial.SetFloat("_OffsetY", offset.y);
      m_effectMaterial.SetFloat("_Exponential", exp);
      m_effectMaterial.SetColor("_Color", vignetteColor);
    
      
      Graphics.Blit(src, dest, m_effectMaterial); 
   }

   public void Start()
   {
      offset = new Vector2(1f, -0.5f);
      vignetteColor = Color.magenta;
      startShake = false;
   }

   public void Update()
   {
      OnDamage();
      StartShake();
   }

   public void OnDamage()
   {
      //isto e para ser substituido por current life aquando de fazer a regen , ainda esta em hard code
      if (playerDamage.currentHealth == playerDamage.playerLife || playerDamage.currentHealth > playerDamage.playerLife - 10)
      {
         exp = 0;
      }
      // else if (playerDamage.currentHealth < playerDamage.playerLife && playerDamage.currentHealth < playerDamage.playerLife - 10)
      // {
      //    Debug.Log(playerDamage.playerLife);
      //    exp = 0.5f;
      // }
      else if ( playerDamage.currentHealth < playerDamage.playerLife - 10 && playerDamage.currentHealth > playerDamage.playerLife - 30)
      {
         exp = 0.5f;
         vignetteColor = Color.magenta;


         
      }
      else if (playerDamage.currentHealth < playerDamage.playerLife - 30 && playerDamage.currentHealth > playerDamage.playerLife - 60)
      {
         exp = 0.9f;
         vignetteColor = Color.magenta;

      }
      else if (playerDamage.currentHealth < playerDamage.playerLife - 60 && playerDamage.currentHealth >= playerDamage.playerLife - 92)
      {
         exp = 1.2f;
         vignetteColor = Color.red; //red a aparecer na ultima perda de vida
      }
      
      //acrescentar outra fase de perda de vida
    
      //else está morto  e mudar a cor para vermelho ou preto
      //por som no toxic aqui
      //provavel mexer na intensidade
   }

   
   public IEnumerator Shake(float duration, float magnitude)
   {
      
      startShake = true;

      Vector3 originalPos = transform.localPosition;
   
      float elapsed = 0f;

      while (elapsed < duration)
      {
         
         float x = UnityEngine.Random.Range(-2f, 2f) * magnitude;


         transform.localPosition = new Vector3(x, originalPos.y, originalPos.z);
         
         elapsed += Time.deltaTime;

         
         yield return null;
      }

      
      transform.localPosition = originalPos;
      
      
   
      startShake = false;


   }

   public void StartShake()
   {
      if (!startShake && playerDamage.startTakingLife)
      {
         if (playerDamage.currentHealth == playerDamage.playerLife - 10 ||
             playerDamage.currentHealth == playerDamage.playerLife - 30 ||
             playerDamage.currentHealth == playerDamage.playerLife - 60)
         {
            StartCoroutine(Shake(.3f,.2f));
         }
      }
   }

}

