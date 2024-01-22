using Company.Api.Contracts;
using Company.Core.Abstractions;
using Company.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Company.Api.Controllers;

//[ApiController]
[Route("api/employee")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeeController(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var employees = await _employeesRepository.Get();

        return Ok(employees);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _employeesRepository.GetById(id);
        if (result.result == false)
            return NotFound();

        return Ok(result.value);
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EmployeeRequest employeeRequest)
    {

        //ModelState.AddModelError("test", "some error validation");
        //ModelState.AddModelError("test", "some error validation22");
        //ModelState.AddModelError("ID", "Wrong Id");
        //return ValidationProblem(ModelState);
        //return BadRequest(ModelState);
        var newGuid = Guid.NewGuid();
        var employee = CreteEmployeeFromRequest(newGuid, employeeRequest);
        var result = await _employeesRepository.Create(employee);
        if (result.result == false)

            return BadRequest();

        return Ok(result.value);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeRequest employeeRequest)
    {
        var employee = CreteEmployeeFromRequest(id, employeeRequest);
        var result = await _employeesRepository.Update(employee);
        if (result.result == false)

            return BadRequest();

        return Ok(result.value);
    }

    [HttpDelete("{id:guid}")]

    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _employeesRepository.Delete(id);
        if (result.result == false)
            return BadRequest();

        return NoContent();
    }


    #region private
    private Employee CreteEmployeeFromRequest(Guid id, EmployeeRequest employeeRequest)
    {
        return new Employee(
            id,
            employeeRequest.Department,
            employeeRequest.FullName,
            employeeRequest.Salary,
            employeeRequest.DateOfBirth,
            employeeRequest.EmploymentDate);
    }
    #endregion
}
