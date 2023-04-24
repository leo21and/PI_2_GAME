using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Camera2Vignette : ImageEffectShaderBase
{
   
   public Vector2 offset;
   public float exp;
   public Color vignetteColor;
 


   

   
   
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
     
         exp = 1.2f;
         vignetteColor = Color.red;

        
      
   }

   
}
