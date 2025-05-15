using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item 
{
    [SerializeField] Image icon; // sprite dos colet�veis
    [SerializeField] int bateryQtd; // quantidade de baterias
   
    public Item(string name, Image icon, int bateryQtd)
    {
        this.icon = icon; //instancia atual da variavel
        this.bateryQtd = bateryQtd;//instancia atual da variavel
    }

    void Start()
    {
        bateryQtd = 1;// a quantidade de baterias come�a em 1
    }

    public void DescartItem()// fun��o para descartar o item
    {

    }

    public void UseItem() // fun��o para uzar o item
    {
        
    }



}

public abstract class InventoryController : MonoBehaviour
{
    
    [SerializeField] GameObject inventoryPainel = null; // O invent�rio tem um valor nulo
    
    Item item;
    KeyCode openInventory = KeyCode.Q; // Bot�o que abre o invent�rio

    void Awake()
    {        
        inventoryPainel.SetActive(false);// o inventario come�a desativado
        
    }

    void Update()
    {
        if(Input.GetKeyDown(openInventory)) // quando se aperta o bot�o "Q" o invent�rio abre e o tempo para
        {
            inventoryPainel.SetActive(true);
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) // quando se aperta o bot�o "ESC" o invent�rio fecha e o tempo volta ao normal
        {
            inventoryPainel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    

}
