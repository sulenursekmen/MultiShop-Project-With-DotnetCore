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
    public class CargoDetailManager:ICargoDetailService
    {
        private readonly ICargoDetailDal _dal;

        public CargoDetailManager(ICargoDetailDal dal)
        {
            _dal = dal;
        }

        public void TDelete(int id)
        {
            _dal.Delete(id);
        }

        public List<CargoDetail> TGetAll()
        {
            return _dal.GetAll();
        }

        public CargoDetail TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public void TInsert(CargoDetail entity)
        {
            _dal.Insert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            _dal.Update(entity);
        }
    }
}
