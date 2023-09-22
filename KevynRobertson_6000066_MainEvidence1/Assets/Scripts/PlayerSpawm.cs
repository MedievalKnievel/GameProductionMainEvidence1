using UnityEngine.InputSystem;
using UnityEngine;



public class PlayerSpawm : MonoBehaviour
{
    public GameObject playerOnePrefab; 
    public GameObject playerTwoPrefab; 

 public void SpawnPlayerOne()
 {
    PlayerInput.Instantiate(prefab: playerOnePrefab, playerIndex: 0 , controlScheme: "Player1", pairWithDevice: Keyboard.current, splitScreenIndex: 0);
 }
 public void SpawnPlayerTwo()
 {
    PlayerInput.Instantiate(prefab: playerTwoPrefab, playerIndex: 1 , controlScheme: "Player2", pairWithDevice: Gamepad.current, splitScreenIndex: 1);
 }

    void Start()
    {
        SpawnPlayerOne();
        SpawnPlayerTwo();
    }

    // Update is called once per frame
    
}