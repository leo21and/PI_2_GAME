using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionScript : MonoBehaviour
{
    public Image oldImage;
    public Sprite potion_100, potion_80, potion_60, potion_40, potion_20, potion_0;
    Image potionImage;
   

    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPotionValue(int valor)
    {

        if (valor < 100)
        {
            if (valor < 20) {
                oldImage.sprite = potion_0;
            } else if (valor < 40)
            {
                oldImage.sprite = potion_20;
            } else if (valor < 60)
            {
                oldImage.sprite = potion_40;
            } else if (valor < 80)
            {
                oldImage.sprite = potion_60;
            } else if (valor < 100)
            {
                oldImage.sprite = potion_80;
            } else if (valor == 100)
            {
                oldImage.sprite = potion_100;
            }


        }
        

    }
}
