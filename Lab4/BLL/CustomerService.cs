using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;
        public CustomerService()
        {
            _repository = new CustomerRepository();
        }

        public void AddCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name))
                throw new ArgumentException("Customer Name cannot be empty.");
            _repository.AddCustomer(customer);
        }

        public Customer GetCustomerById(int id)
        {
            return _repository.GetCustomerById(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _repository.GetAllCustomers();
        }

        public void UpdateCustomer(Customer customer)
        {
            _repository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            _repository.DeleteCustomer(id);
        }
    }
}
