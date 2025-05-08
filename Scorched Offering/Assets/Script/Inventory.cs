using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item 
{
    [SerializeField] Sprite icon; // sprite dos coletáveis
    [SerializeField] int bateryQtd; // quantidade de baterias
    [SerializeField] string name; // nome do item

    public Item(string name, Sprite icon, int bateryQtd)
    {
        this.name = name; //instancia atual da variavel
        this.icon = icon; //instancia atual da variavel
        this.bateryQtd = bateryQtd;//instancia atual da variavel
    }

}

public class Inventory : MonoBehaviour, IInventory // Interface do inventário
{
    
    [SerializeField] GameObject inventoryPainel = null; // O inventário tem um valor nulo
    [SerializeField] List<GameObject> itens; // lista dos itens
   
    

    int qtdOfItens;// quantidade dos itens a ser mostrada
    KeyCode openInventory = KeyCode.Q; // Botão que abre o inventário

    void Start()
    {        
        inventoryPainel.SetActive(false);// o inventario começa desativado
    }

    void Update()
    {
        if(Input.GetKeyDown(openInventory)) // quando se aperta o botão "Q" o inventário abre e o tempo para
        {
            inventoryPainel.SetActive(true);
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) // quando se aperta o botão "ESC" o inventário fecha e o tempo volta ao normal
        {
            inventoryPainel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void DescartItem(string name)// função para descartar o item
    {
        //Item item = itens.Find(x => x.name == name);
       
    }

    public void UseItem(Item item) // função para uzar o item
    {
        
    }

}
