using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    //Shoot if Game state is positive
    void Update()
    {
        if (Input.GetButton("Fire1") && Game.Instance.State == Game.eState.Game)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            weapon.Fire(ray.origin, ray.direction);
        }
    }
}
