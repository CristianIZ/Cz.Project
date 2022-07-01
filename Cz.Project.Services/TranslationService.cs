using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Project.Services
{
    public interface IObserver
    {
        void Update(ITranslation translation);
    }

    public interface ITranslation
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class Subject : ITranslation
    {
        public int State { get; set; } = -0;
        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.State = new Random().Next(0, 10);


            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.Notify();
        }
    }

    class ConcreteObserverA : IObserver
    {
        public void Update(ITranslation translation)
        {
            // Get translation for my Word Code


        }
    }

    internal class TranslationService
    {
    }
}
