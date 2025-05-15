using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public abstract class InventoryController : MonoBehaviour
{
    
    [SerializeField] GameObject inventoryPainel = null; // O inventário tem um valor nulo
    
    
    public KeyCode openInventory = KeyCode.Q; // Botão que abre o inventário

    void Awake()
    {        
        inventoryPainel.SetActive(false);// o inventario começa desativado
        
    }

    void Update()
    {
        print("está na cena");
        if(Input.GetKeyDown(openInventory)) // quando se aperta o botão "Q" o inventário abre e o tempo para
        {
            print("foi");
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
