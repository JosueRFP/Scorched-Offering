using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum PlayStates
{
    INVENTORY, PLAYING
}
public abstract class InventoryController : MonoBehaviour
{
    
    [SerializeField] GameObject inventoryPainel = null; // O invent�rio tem um valor nulo
    [SerializeField]  PlayStates _playStates = PlayStates.PLAYING;

    public UnityEvent OnInventory, OnPlay;
    public PlayStates State { get => _playStates; set => _playStates = value; }

    
    void Awake()
    {        
        inventoryPainel.SetActive(false);// o inventario come�a desativado
        
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Q)) // quando se aperta o bot�o "Q" o invent�rio abre 
        {            
            inventoryPainel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) // quando se aperta o bot�o "ESC" o invent�rio fecha 
        {
            inventoryPainel.SetActive(false);
        }
    }

    public void States()
    {

        switch (_playStates)
        {
             case PlayStates.INVENTORY:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
                break;
                       
            case PlayStates.PLAYING:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
        }

    }
}
