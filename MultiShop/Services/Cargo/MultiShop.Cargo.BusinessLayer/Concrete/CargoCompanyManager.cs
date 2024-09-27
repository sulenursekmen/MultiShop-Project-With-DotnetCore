using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _dal;

        public CargoCompanyManager(ICargoCompanyDal dal)
        {
            _dal = dal;
        }

        public void TDelete(int id)
        {
            _dal.Delete(id);
        }

        public List<CargoCompany> TGetAll()
        {
           return _dal.GetAll();
        }

        public CargoCompany TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public void TInsert(CargoCompany entity)
        {
            _dal.Insert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {
           _dal.Update(entity);
        }
    }
}
