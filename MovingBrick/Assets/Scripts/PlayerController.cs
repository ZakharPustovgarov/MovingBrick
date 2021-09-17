using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent _agent;
    Camera _camera;
    [SerializeField]
    Joystick _joystick;

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
            Touch touch = Input.GetTouch(0);
            _ray = _camera.ScreenPointToRay(touch.position);

            if (Physics.Raycast(_ray, out _hit))
            {
                _agent.SetDestination(_hit.point);
            }
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

        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _agent.SetDestination(new Vector3(transform.position.x + _joystick.Horizontal * 2f, transform.position.y + 3f, transform.position.z + _joystick.Vertical * 2f));
        }
    }
}
