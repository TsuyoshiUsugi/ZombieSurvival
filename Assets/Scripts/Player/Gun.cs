using Cysharp.Threading.Tasks;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _maxAmmo = 10;
    [SerializeField] private int _currentAmmo = 10;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private float _reloadTime = 1f;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private float _fireRate = 0.1f;
    private float _resetFireRate = 0;
    bool _isReloading = false;
    public int CurrentAmmo => _currentAmmo;
    public bool IsReloading => _isReloading;
    
    public void Shoot(Transform target)
    {
        if (_currentAmmo > 0 && _resetFireRate <= 0)
        {
            _resetFireRate = _fireRate;
            _currentAmmo--;
            _muzzleFlash.Play();
            var bullet = Instantiate(_bullet, _muzzle.position, transform.rotation);
            bullet.transform.LookAt(target);
            bullet.SetDamage(_damage);
            var dir = target.position - transform.position;
            bullet.GetComponent<Rigidbody>().AddForce(dir.normalized * 1000);
        }
    }
    
    public async UniTaskVoid Reload()
    {
        _isReloading = true;
        await UniTask.Delay(System.TimeSpan.FromSeconds(_reloadTime));
        _isReloading = false;
        _currentAmmo = _maxAmmo;
        // if (rest < _maxAmmo)
        // {
        //     _currentAmmo = rest;
        //     return 0;
        // }
        //
        // _currentAmmo = _maxAmmo;
        // return rest - _maxAmmo;
    }

    private void Update()
    {
        if (_resetFireRate > 0) _resetFireRate -= Time.deltaTime;
    }
}
