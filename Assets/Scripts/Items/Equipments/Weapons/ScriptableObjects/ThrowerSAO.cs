
using System.Collections;
using RPG.Character;
using UnityEngine;

[CreateAssetMenu(fileName = "New Throw", menuName = "Weapons/Use Functions/Throw")]
public class ThrowerSAO : WeaponFunctionSAO
{
    [SerializeField]
    private Projectile projectile;
    [SerializeField]
    private int amountPerThrow = 1;
    [SerializeField]
    private float startAngle;
    [SerializeField]
    private float anglePerThrow;
    [SerializeField]
    private float delayPerThrow;

    private WaitForSeconds waitForSeconds = null;

    public override void OnUsed<T>(T owner, Transform throwPosition)
    {
        if (waitForSeconds == null)
        {
            waitForSeconds = new WaitForSeconds(delayPerThrow);
        }

        owner.StartCoroutine(ThrowProjectile(owner, throwPosition));
    }

    private IEnumerator ThrowProjectile<T>(T owner, Transform throwTransform) where T : MonoBehaviour, ICharacteristic
    {
        float angle = startAngle;
        for (int i = 0; i < amountPerThrow; i++)
        {
            SetupProjectile(owner, throwTransform, angle);
            angle += anglePerThrow;
            yield return waitForSeconds;
        }
    }

    private void SetupProjectile<T>(T owner, Transform throwTransform, float angle) where T : MonoBehaviour, ICharacteristic
    {
        Projectile p = Instantiate(projectile);
        p.ignoreTag = owner.gameObject.tag;
        p.damage = owner.CurrentStats.damage;
        p.transform.position = throwTransform.position;
        p.transform.forward = throwTransform.forward;
        p.transform.eulerAngles = p.transform.eulerAngles + new Vector3(0, angle, 0);
    }
}