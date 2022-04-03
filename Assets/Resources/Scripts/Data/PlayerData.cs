[System.Serializable]
public class PlayerData
{
    public int bestScore;

    public PlayerData (Player player)
    {
        bestScore = player.bestPoint;
    }
}
