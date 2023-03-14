
namespace Singleton;

public class Coin {

  private const int _ADD_MORE_COIN = 10;
  private static Coin? _Instance;
  private int coin;

  private Coin() {}

  public static Coin Instance() {
    if (_Instance == null) _Instance = new Coin();
    return _Instance;
  }

  public int GetCoin() => coin;

  public void AddMoreCoins() => coin += _ADD_MORE_COIN;

  public void DeductCoin() => coin--;

}
