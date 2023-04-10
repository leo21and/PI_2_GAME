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
      if (playerDamage.playerLife == 1000)
      {
        // exp = 0;
      }
      else if (playerDamage.playerLife < 1000 && playerDamage.playerLife > 990)
      {
         exp = 0.5f;
      }
      else if (playerDamage.playerLife < 990 && playerDamage.playerLife > 950)
      {
         exp = 0.9f;
      }
      else if (playerDamage.playerLife < 950 && playerDamage.playerLife > 900)
      {
         exp = 1.2f;
      }
      //else está morto 
   }






}

