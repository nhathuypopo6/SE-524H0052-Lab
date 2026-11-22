using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class SupplierService
    {
        private readonly SupplierRepository _supplierRepository;

        public SupplierService()
        {
            _supplierRepository = new SupplierRepository();
        }

        public void AddSupplier(Supplier supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.Name))
            {
                throw new ArgumentException("Supplier name cannot be empty!");
            }
            _supplierRepository.AddSupplier(supplier);
        }

        public Supplier GetSupplier(int id)
        {
            return _supplierRepository.GetSupplierById(id);
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _supplierRepository.GetAllSuppliers();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.Name))
            {
                throw new ArgumentException("Supplier name cannot be empty!");
            }
            _supplierRepository.UpdateSupplier(supplier);
        }

        public void DeleteSupplier(int id)
        {
            _supplierRepository.DeleteSupplier(id);
        }
    }
}
