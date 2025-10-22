using EmpresaAPI.Models;

namespace EmpresaAPI.Repositories;

public interface IEmpresaRepository
{
    // Empleados
    Task<List<Employee>> GetAllEmployeesAsync();
    Task<int> GetEmployeesCountAsync();
    Task<Employee?> GetEmployeeByIdAsync(int empleadoId);
    Task<Employee?> GetEmployeeByNameAsync(string nombreEmpleado);
    Task<Employee?> GetEmployeeByTitleAsync(string titulo);
    Task<Employee?> GetEmployeeByCountryAsync(string country);
    Task<List<Employee>> GetEmployeesByCountryAsync(string country);
    Task<Employee?> GetOldestEmployeeAsync();
    Task<List<(string Title, int Count)>> GetEmployeeCountByTitleAsync();

    // Productos
    Task<List<Product>> GetProductsContainingAsync(string palabra);
    Task<List<ProductWithCategoryDto>> GetProductsWithCategoryAsync();
}

