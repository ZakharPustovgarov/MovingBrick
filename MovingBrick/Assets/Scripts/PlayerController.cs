using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent _agent;
    Camera _camera;
    [SerializeField]
    Joystick joystick;

    Ray _ray;
    RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchSupported)
        {
            UnityEngine.Debug.Log("You just need a little touch!");


        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _ray = _camera.ScreenPointToRay(Input.mousePosition); 

                if (Physics.Raycast(_ray, out _hit))
                {
                    _agent.SetDestination(_hit.point);
                }
            }
        }

        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            _agent.SetDestination(new Vector3(transform.position.x + joystick.Horizontal, transform.position.y, transform.position.z + joystick.Vertical));
        }
    }
}
