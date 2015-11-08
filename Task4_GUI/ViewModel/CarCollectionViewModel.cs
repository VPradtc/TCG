using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_DbAccess;
using Task4_DbAccess.UnitOfWork;
using Task4_GUI.Extensions;
using Task4_Models;
using Task4_Models.Task4;

namespace Task4_GUI.ViewModel
{
    public sealed class CarCollectionViewModel : INotifyPropertyChanged
    {
        #region Private Members

        private List<Car> m_cars;
        private readonly AdoNetContext m_context;
        private Car m_newCar;

        private void LoadCars()
        {
            using (var uow = m_context.CreateUnitOfWork())
            {
                var repo = new CarRepository(m_context);
                var carData = repo.GetCars(this.OnDbUpdate);
                Cars = new List<Car>(carData);
            }
        }

        private void OnDbUpdate(object sender, System.Data.SqlClient.SqlNotificationEventArgs e)
        {
            this.LoadCars();
        }

        private void AddCar(object obj)
        {
            using (var uow = m_context.CreateUnitOfWork())
            {
                var repo = new CarRepository(m_context);
                repo.Create(NewCar);
                NewCar = new Car();

                uow.SaveChanges();
            }

            LoadCars();
        }

        #endregion

        public CarCollectionViewModel()
        {
            var factory = new AppConfigConnectionFactory("Task4ConnectionString");
            m_context = new AdoNetContext(factory);
            AddCarCommand = new RelayCommand(AddCar);
            m_newCar = new Car();
        }

        public Car NewCar
        {
            get
            {
                return m_newCar;
            }
            private set
            {
                m_newCar = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("NewCar"));
            }
        }
        public List<Car> Cars
        {
            get
            {
                if (m_cars == null)
                {
                    LoadCars();
                }
                return m_cars;
            }
            private set
            {
                m_cars = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Cars"));
            }
        }

        public RelayCommand AddCarCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
