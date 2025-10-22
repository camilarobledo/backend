using EmpresaAPI.Data;
using EmpresaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpresaAPI.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly EmpresaDbContext _db;
    public EmpresaRepository(EmpresaDbContext db) => _db = db;

    //Empleados
    public Task<List<Employee>> GetAllEmployeesAsync()
        => _db.Employees.AsNoTracking().ToListAsync();

    public Task<int> GetEmployeesCountAsync()
        => _db.Employees.CountAsync();

    public Task<Employee?> GetEmployeeByIdAsync(int empleadoId)
        => _db.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == empleadoId);

    public Task<Employee?> GetEmployeeByNameAsync(string nombreEmpleado)
        => _db.Employees.AsNoTracking()
            .FirstOrDefaultAsync(e =>
                (e.FirstName + " " + e.LastName).Trim().ToLower() == nombreEmpleado.Trim().ToLower());

    public Task<Employee?> GetEmployeeByTitleAsync(string titulo)
        => _db.Employees.AsNoTracking()
            .FirstOrDefaultAsync(e => e.Title.ToLower() == titulo.Trim().ToLower());

    public Task<Employee?> GetEmployeeByCountryAsync(string country)
        => _db.Employees.AsNoTracking()
            .FirstOrDefaultAsync(e => e.Country.ToLower() == country.Trim().ToLower());

    public Task<List<Employee>> GetEmployeesByCountryAsync(string country)
        => _db.Employees.AsNoTracking()
            .Where(e => e.Country.ToLower() == country.Trim().ToLower())
            .ToListAsync();

    public async Task<Employee?> GetOldestEmployeeAsync()
    {
        var oldestBirthDate = await _db.Employees.MinAsync(e => e.BirthDate);
        return await _db.Employees.AsNoTracking()
            .FirstOrDefaultAsync(e => e.BirthDate == oldestBirthDate);
    }

    public async Task<List<(string Title, int Count)>> GetEmployeeCountByTitleAsync()
    {
        var rows = await _db.Employees.AsNoTracking()
            .GroupBy(e => e.Title)
            .Select(g => new { Title = g.Key, Count = g.Count() })
            .ToListAsync();

        return rows.Select(x => (x.Title, x.Count)).ToList();
    }

    //Productos
    public Task<List<Product>> GetProductsContainingAsync(string palabra)
        => _db.Products.AsNoTracking()
            .Where(p => p.Name.ToLower().Contains(palabra.Trim().ToLower()))
            .ToListAsync();

    public Task<List<ProductWithCategoryDto>> GetProductsWithCategoryAsync()
        => _db.Products.AsNoTracking()
            .Include(p => p.Category)
            .Select(p => new ProductWithCategoryDto
            {
                ProductId = p.Id,
                ProductName = p.Name,
                CategoryId = p.CategoryId,
                CategoryName = p.Category != null ? p.Category.Name : ""
            })
            .ToListAsync();
}

