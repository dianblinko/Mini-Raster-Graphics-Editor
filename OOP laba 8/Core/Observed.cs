using System.Collections.Generic;

namespace OOP_laba_8.Core
{
    public class Observed
    {
        private List<Observer> observers;

        public Observed()
        {
            observers = new List<Observer>();
        }

        public void AddObserver(Observer o)
        {
            observers.Add(o);
        }

        public void Notify()
        {
            foreach (Observer observer in observers) observer.SubjectChanged();
        }
    }
}
