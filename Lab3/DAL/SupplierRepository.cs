using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class SupplierRepository
    {
        private readonly Exer1DbContext _context;

        public SupplierRepository()
        {
            _context = new Exer1DbContext();
        }

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public Supplier GetSupplierById(int id)
        {
            return _context.Suppliers.FirstOrDefault(s => s.Id == id);
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            var existing = _context.Suppliers.FirstOrDefault(s => s.Id == supplier.Id);
            if (existing != null)
            {
                existing.Name = supplier.Name;
                existing.Address = supplier.Address;
                existing.Phone = supplier.Phone;
                _context.SaveChanges();
            }
        }

        public void DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }
    }
}
