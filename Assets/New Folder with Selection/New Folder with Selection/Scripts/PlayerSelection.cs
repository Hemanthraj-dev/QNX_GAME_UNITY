using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private PlayerCinematicCamera cinematicCamera;
    [Header("Player Selection")]
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [Header("Network Manager")]
    [SerializeField] private NetworkManager networkManager;

    private void Start()
    {
        if (player1 != null)
            player1.SetActive(false);

        if (player2 != null)
            player2.SetActive(false);
    }

    public void SelectPlayer1()
    {
        SelectPlayer(1);
    }

    public void SelectPlayer2()
    {
        SelectPlayer(2);
    }

    private void SelectPlayer(int selectedPlayer)
    {
        Debug.Log($"[PlayerSelection] Player {selectedPlayer} selected.");

        if (player1 != null)
            player1.SetActive(selectedPlayer == 1);

        if (player2 != null)
            player2.SetActive(selectedPlayer == 2);

        if (selectedPlayer == 1)
        {
            PlayerController controller =
                player1.GetComponent<PlayerController>();

            if (controller != null)
                controller.enabled = true;

            UnityEngine.InputSystem.PlayerInput input =
                player1.GetComponent<UnityEngine.InputSystem.PlayerInput>();

            if (input != null)
                input.enabled = true;
            if (cinematicCamera != null)
                cinematicCamera.SetTarget(player1);
        }
        else if (selectedPlayer == 2)
        {
            PlayerController controller =
                player2.GetComponent<PlayerController>();

            if (controller != null)
                controller.enabled = true;

            UnityEngine.InputSystem.PlayerInput input =
                player2.GetComponent<UnityEngine.InputSystem.PlayerInput>();

            if (input != null)
                input.enabled = true;
            if (cinematicCamera != null)
                cinematicCamera.SetTarget(player2);
        }

        if (networkManager != null)
        {
            networkManager.StartNetwork(selectedPlayer);
        }
        else
        {
            Debug.LogError(
                "[PlayerSelection] NetworkManager reference is missing."
            );
        }

        gameObject.SetActive(false);
    }
}