using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _xDirectionShoot;

    public void Attack()
    {
        float _xOffset = 3;

        Vector3 _targetVector3 = new Vector3(_xOffset, 0);
        Bullet newBullet = Instantiate(_bullet, transform.position + _targetVector3, transform.rotation);
        newBullet.MakeShoot(_xDirectionShoot);
    }
}
