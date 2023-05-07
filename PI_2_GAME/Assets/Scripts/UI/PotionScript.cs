using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionScript : MonoBehaviour
{

    public Sprite potion_100, potion_80, potion_60, potion_40, potion_20, potion_0;
    Image potionImage;
   

    private void Awake()
    {
        potionImage = GetComponent<Image>();
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
            Debug.Log(valor);
        }
        //potionImage.sprite = potion_40;
    }
}
