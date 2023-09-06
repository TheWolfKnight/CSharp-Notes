using System.Collections.Generic;

namespace ObserverPattern.Observer;

using ObserverCallback = Action;

public interface IObserver {

  void Subscribe(ObserverCallback callback);
  void Notify();

}

public class Observer : IObserver {

  private List<ObserverCallback> _listiners = null!;

  public Observer() {
    _listiners = new List<ObserverCallback>();
  }

  public void Subscribe(ObserverCallback callback) => _listiners.Add(callback);
  public void Notify() {
    _listiners
      .AsParallel()
      .ForAll(callback => callback());
  }

}
