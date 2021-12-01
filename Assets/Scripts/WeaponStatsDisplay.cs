using TMPro;
using UnityEngine;

public class WeaponStatsDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text bulletCountText;

    private int bulletCount;

    private void Update() => bulletCountText.text = bulletCount.ToString();

    public void IncreaseBulletCount() => bulletCount++;
}
