using System.Drawing;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _nextTeleport;
    [SerializeField] private Transform _player;

    private void OnTriggerEnter(Collider collision)
    {
        _player.transform.position = _nextTeleport.transform.position;
    }
}
