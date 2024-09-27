using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCustomerManager:ICargoCustomerService
    {
        private readonly ICargoCustomerDal _dal;

        public CargoCustomerManager(ICargoCustomerDal dal)
        {
            _dal = dal;
        }

        public void TDelete(int id)
        {
            _dal.Delete(id);
        }

        public List<CargoCustomer> TGetAll()
        {
            return _dal.GetAll();
        }

        public CargoCustomer TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public void TInsert(CargoCustomer entity)
        {
            _dal.Insert(entity);
        }

        public void TUpdate(CargoCustomer entity)
        {
            _dal.Update(entity);
        }
    }
}
