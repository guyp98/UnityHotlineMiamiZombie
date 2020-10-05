using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    
    public void show()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.gameObject.SetActive(true);
        
      
    }
   
    
}
