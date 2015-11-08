using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Task4_DbAccess;
using Task4_DbAccess.UnitOfWork;
using Task4_DbAccess.Utils;

namespace Task4_Models.Task4
{
    public class CarRepository : Repository<Car>
    {
        public CarRepository(AdoNetContext context)
            : base(context)
        {
        }

        public void Create(Car car)
        {
            using (var command = m_context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Car (Manufacturer, Name, Price) VALUES(@manufacturer, @name, @price)";
                command.CreateParameter();
                command.AddParameter("manufacturer", car.Manufacturer);
                command.AddParameter("name", car.Name);
                command.AddParameter("price", car.Price);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Car car)
        {
            using (var command = m_context.CreateCommand())
            {
                command.CommandText = @"UPDATE Car SET Manufacturer = @manufacturer, Name = @name, Price = @price WHERE ID = @id";
                command.AddParameter("manufacturer", car.Manufacturer);
                command.AddParameter("name", car.Name);
                command.AddParameter("price", car.Price);
                command.AddParameter("id", car.ID);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Car car)
        {
            using (var command = m_context.CreateCommand())
            {
                command.CommandText = @"DELETE FROM Car WHERE Id = @id";
                command.AddParameter("id", car.ID);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Car> GetCars()
        {
            return this.GetCars(null);

        }

        public IEnumerable<Car> GetCars(OnChangeEventHandler dataUpdateCallback)
        {
            using (var command = m_context.CreateCommand())
            {
                command.CommandText = @"SELECT Id, Manufacturer, Name, Price FROM dbo.Car";
                //Dirty SOLID violations as (NOT) intended
                if (command is SqlCommand)
                {
                    (command as SqlCommand).Notification = null;
                    SqlDependency dependency = new SqlDependency(command as SqlCommand);
                    dependency.OnChange += dataUpdateCallback;
                }
                return ToList(command);
            }
        }

        protected override void Map(IDataRecord record, Car entity)
        {
            entity.ID = (int)record["Id"];
            entity.Manufacturer = (string)record["Manufacturer"];
            entity.Name = (string)record["Name"];
            //High quality casting.
            entity.Price = Double.Parse(record["Price"].ToString());
        }
    }
}
