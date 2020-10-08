
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    
    public List<Image> AllHearts;

    public void BuildHearts(int AmoutFull,int AmountEmpty)
    {
        for (int i=0;i<AllHearts.Count;i++)
        {
            if (i < AmoutFull)
            {
                AllHearts[i].enabled = true;
                AllHearts[i].sprite = FullHeart;
            }
            else if (AmoutFull <= i && i < AmoutFull + AmountEmpty)
            {
                AllHearts[i].enabled = true;
                AllHearts[i].sprite = EmptyHeart;
            }
            else
            {
                AllHearts[i].enabled = false;
                AllHearts[i].sprite = EmptyHeart;
            }
        }
    }
    public void IncreasePool(int amount)//how much to increase number of hearts(amount+(existing amount))
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        int index=AllHearts.FindIndex(x=>x.enabled==false);
        
        
        while (-1<index&&index<AllHearts.Count && amount>0)
        {
            
            AllHearts[index].enabled = true;
            AllHearts[index].sprite = EmptyHeart;
            amount -= 1;
            index += 1;

        }
    }
    public void DecreasePool(int amount)//how much to Decrease number of hearts((existing amount)-amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        int index = AllHearts.FindIndex(x => x.enabled == false);

        if (index != -1)
        {
            index -= 1;
        }
        else if (index == -1)
        {
            index = AllHearts.Count - 1;
        }
        
        while (-1 < index && index < AllHearts.Count && amount > 0)
        {
            
            AllHearts[index].enabled = false;
            AllHearts[index].sprite = null;
            amount -= 1;
            index -= 1;

        }
    }
    public void IncreaseFullHearts(int amount)//increas hearts without adding more slots for hearts
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        for (int index = 0; amount>0&&index < AllHearts.Count; index++)
        {
            
            if (AllHearts[index].enabled == true&&AllHearts[index].sprite.Equals(EmptyHeart))
            {
                AllHearts[index].sprite = FullHeart;
                amount--;
            }
            
        }
    }
    public void DecreaseFullHearts(int amount)//Decreas hearts without subtractinging  slots for hearts
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        for (int index = AllHearts.Count-1; amount > 0 && index >=0; index--)
        {

            if (AllHearts[index].enabled == true && AllHearts[index].sprite.Equals(FullHeart))
            {
                AllHearts[index].sprite = EmptyHeart;
                amount--;
            }

        }

    }

}

