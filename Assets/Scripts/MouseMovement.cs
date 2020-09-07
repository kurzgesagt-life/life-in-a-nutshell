using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseMovement : MonoBehaviour    
{

    public Tilemap map;
    MouseInput mouseInput;
    private Vector3 destination;
    [SerializeField] private float movementSpeed;

    // Start is called before the first frame update
    private void Awake()
    {
        mouseInput = new MouseInput();
    }

    private void Start()
    {
        destination = transform.position;
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
    }

    private void OnEnable()
    {
        mouseInput.Enable();
    }

    private void OnDisable()
    {
        mouseInput.Disable();
    
    }

    private void MouseClick()
    {
        Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        if (map.HasTile(gridPosition))
        {
            destination = mousePosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) > 0.1f)
        transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
    }
}
