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
    public class CargoOperationManager:ICargoOperationService
    {
        private readonly ICargoOperationDal _dal;

        public CargoOperationManager(ICargoOperationDal dal)
        {
            _dal = dal;
        }

        public void TDelete(int id)
        {
            _dal.Delete(id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _dal.GetAll();
        }

        public CargoOperation TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public void TInsert(CargoOperation entity)
        {
            _dal.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            _dal.Update(entity);
        }
    }
}
