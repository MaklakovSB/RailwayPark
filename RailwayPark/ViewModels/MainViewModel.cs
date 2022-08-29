using RailwayPark.Interfaces;
using System;

namespace RailwayPark.ViewModels
{
    public class MainViewModel : IViewModel
    {

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainViewModel()
        {

        }

        #region Имплементация IViewModel

        public event Action Close;

        public virtual void OnClose()
        {
            Close?.Invoke();
        }

        #endregion
    }
}
