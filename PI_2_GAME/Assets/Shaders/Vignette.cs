using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vignette : ImageEffectShaderBase
{
   public Vector2 offset;
   public float exp;
   public Color vignetteColor;
   public PlayerDamage playerDamage;

   
   
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
   }

   public void Update()
   {
      OnDamage();
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
      }
      else if (playerDamage.currentHealth < playerDamage.playerLife - 30 && playerDamage.currentHealth > playerDamage.playerLife - 60)
      {
         exp = 0.9f;
      }
      else if (playerDamage.currentHealth < playerDamage.playerLife - 60 && playerDamage.currentHealth > playerDamage.playerLife - 100)
      {
         exp = 1.2f;
      }
      //else está morto  e mudar a cor para vermelho ou preto
      //por som no toxic aqui
      //provavel mexer na intensidade
   }






}

