using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public abstract class InventoryController : MonoBehaviour
{
    
    [SerializeField] GameObject inventoryPainel = null; // O invent�rio tem um valor nulo
    
    
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
