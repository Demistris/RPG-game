using UnityEngine;

[System.Serializable]
public class Loot
{
    public PowerUp ThisLoot => _thisLoot;
    public int LootChance => _lootChance;

    [SerializeField] private PowerUp _thisLoot;
    [SerializeField] private int _lootChance;
}

[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    [SerializeField] private Loot[] _lootList;

    public PowerUp LootPowerUp()
    {
        int cumulativeProbability = 0;
        int currentProbability = Random.Range(0, 100);

        for (int i = 0; i < _lootList.Length; i++)
        {
            cumulativeProbability += _lootList[i].LootChance;

            if(currentProbability <= cumulativeProbability)
            {
                return _lootList[i].ThisLoot;
            }
        }

        return null;
    }
}
