using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item 
{
    [SerializeField] Sprite icon; // sprite dos coletáveis
    [SerializeField] int bateryQtd; // quantidade de baterias
   
    public Item(string name, Sprite icon, int bateryQtd)
    {
        this.icon = icon; //instancia atual da variavel
        this.bateryQtd = bateryQtd;//instancia atual da variavel
    }

    void Start()
    {
        bateryQtd = 1;
    }

    public void DescartItem()// função para descartar o item
    {

    }

    public void UseItem() // função para uzar o item
    {

    }



}

public abstract class InventoryController : MonoBehaviour
{
    
    [SerializeField] GameObject inventoryPainel = null; // O inventário tem um valor nulo
     
    

    int qtdOfItens;// quantidade dos itens a ser mostrada
    KeyCode openInventory = KeyCode.Q; // Botão que abre o inventário

    void Awake()
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

    

}
