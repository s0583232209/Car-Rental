using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;

namespace DAL.Interfaces;

public interface IRentalsRepository
{
    Task<IEnumerable<Rental>> GetAllAsync();
    Task<Rental?> GetByIdAsync(int id);
    Task<IEnumerable<Rental>> GetByCustomerAsync(int customerId);
    Task AddAsync(Rental rental);
    Task UpdateAsync(Rental rental);
    Task DeleteAsync(int id);
}
