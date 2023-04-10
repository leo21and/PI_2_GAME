using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageEffectShaderBase : MonoBehaviour
{

    public Shader effectShader;
    internal Material m_effectMaterial;


    private void OnEnable()
    {
        if (effectShader == null)
        {
            enabled = false;
            return;
        }

        m_effectMaterial = new Material(effectShader);
    }


    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
       Graphics.Blit(src, dest, m_effectMaterial); 
    }

   
}
