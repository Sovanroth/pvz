using UnityEngine;

[CreateAssetMenu(fileName = "ZombieType", menuName = "Zombie")]
public class ZombieType : ScriptableObject
{
    public int health;
    public int damage;
    public Sprite sprite;
    public Sprite death;
    public float speed;
    public float range = .5f;
    public float eatCD = 1f;

}
