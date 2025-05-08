using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item 
{
    [SerializeField] Sprite icon; // sprite dos colet�veis
    [SerializeField] int bateryQtd; // quantidade de baterias
    [SerializeField] string name; // nome do item

    public Item(string name, Sprite icon, int bateryQtd)
    {
        this.name = name; //instancia atual da variavel
        this.icon = icon; //instancia atual da variavel
        this.bateryQtd = bateryQtd;//instancia atual da variavel
    }

}

public class Inventory : MonoBehaviour, IInventory // Interface do invent�rio
{
    
    [SerializeField] GameObject inventoryPainel = null; // O invent�rio tem um valor nulo
    [SerializeField] List<GameObject> itens; // lista dos itens
   
    

    int qtdOfItens;// quantidade dos itens a ser mostrada
    KeyCode openInventory = KeyCode.Q; // Bot�o que abre o invent�rio

    void Start()
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

    public void DescartItem(string name)// fun��o para descartar o item
    {
        //Item item = itens.Find(x => x.name == name);
       
    }

    public void UseItem(Item item) // fun��o para uzar o item
    {
        
    }

}
