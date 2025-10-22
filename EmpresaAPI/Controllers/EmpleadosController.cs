using EmpresaAPI.Models;
using EmpresaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaAPI.Controllers;

[ApiController]
[Route("api")]
public class EmpleadosController : ControllerBase
{
    private readonly IEmpresaRepository _repository;
    public EmpleadosController(IEmpresaRepository repository) => _repository = repository;

    //Empleados 

    // GET api/TodosLosEmpleados
    [HttpGet("TodosLosEmpleados")]
    public async Task<ActionResult<List<Employee>>> GetAll()
        => Ok(await _repository.GetAllEmployeesAsync());

    // GET api/CantidadEmpleados
    [HttpGet("CantidadEmpleados")]
    public async Task<ActionResult<int>> GetCount()
        => Ok(await _repository.GetEmployeesCountAsync());

    // GET api/EmpleadoPorID?empleadoID=5
    [HttpGet("EmpleadoPorID")]
    public async Task<ActionResult<Employee>> GetById([FromQuery] int empleadoID)
    {
        var emp = await _repository.GetEmployeeByIdAsync(empleadoID);
        return emp is null ? NotFound() : Ok(emp);
    }

    // GET api/EmpleadosPorNombre?nombreEmpleado=""
    [HttpGet("EmpleadosPorNombre")]
    public async Task<ActionResult<Employee>> GetByName([FromQuery] string nombreEmpleado)
    {
        var emp = await _repository.GetEmployeeByNameAsync(nombreEmpleado);
        return emp is null ? NotFound() : Ok(emp);
    }

    // GET api/IDempleadoPorTitulo?titulo=Manager
    [HttpGet("IDempleadoPorTitulo")]
    public async Task<ActionResult<Employee>> GetByTitle([FromQuery] string titulo)
    {
        var emp = await _repository.GetEmployeeByTitleAsync(titulo);
        return emp is null ? NotFound() : Ok(emp);
    }

    // GET api/EmpleadoPorPais?country=""
    [HttpGet("EmpleadoPorPais")]
    public async Task<ActionResult<Employee>> GetByCountry([FromQuery] string country)
    {
        var emp = await _repository.GetEmployeeByCountryAsync(country);
        return emp is null ? NotFound() : Ok(emp);
    }

    // GET api/TodosLosEmpleadosPorPais?country=""
    [HttpGet("TodosLosEmpleadosPorPais")]
    public async Task<ActionResult<List<Employee>>> GetAllByCountry([FromQuery] string country)
        => Ok(await _repository.GetEmployeesByCountryAsync(country));

    // GET api/ElEmpleadoMasGrande
    [HttpGet("ElEmpleadoMasGrande")]
    public async Task<ActionResult<Employee>> GetOldest()
    {
        var emp = await _repository.GetOldestEmployeeAsync();
        return emp is null ? NotFound() : Ok(emp);
    }

    // GET api/CantidadEmpleadosPorTitulos
    [HttpGet("CantidadEmpleadosPorTitulos")]
    public async Task<ActionResult<List<object>>> GetCountByTitles()
    {
        var data = await _repository.GetEmployeeCountByTitleAsync();
        var result = data.Select(d => new { Title = d.Title, Count = d.Count }).ToList();
        return Ok(result);
    }

    // Productos

    // GET api/ObtenerProductosConCategoria
    [HttpGet("ObtenerProductosConCategoria")]
    public async Task<ActionResult<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        => Ok(await _repository.GetProductsWithCategoryAsync());

    // GET api/ObtenerProductosQueContienen?palabra=""
    [HttpGet("ObtenerProductosQueContienen")]
    public async Task<ActionResult<List<Product>>> GetProductsContaining([FromQuery] string palabra)
        => Ok(await _repository.GetProductsContainingAsync(palabra));
}

