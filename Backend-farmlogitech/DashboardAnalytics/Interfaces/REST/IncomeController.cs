using System.Net.Mime;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Queries.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Queries.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Services;
using Backend_farmlogitech.DashboardAnalytics.Interfaces.Resources.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Interfaces.Transform.Incomes;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.DashboardAnalytics.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class IncomeController : ControllerBase
{
    private IIncomeQueryService _incomeQueryService;
    private IIncomeCommandService _incomeCommandService;

    public IncomeController(IIncomeQueryService incomeQueryService, IIncomeCommandService incomeCommandService)
    {
        _incomeQueryService = incomeQueryService;
        _incomeCommandService = incomeCommandService;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateIncome([FromBody] CreateIncomeResource command)
    {
        var income = CreateIncomeCommandFromResourceAssembler.ToCommand(command);
        var result = await _incomeCommandService.Handle(income);
        return CreatedAtAction(nameof(GetIncomeById), new { id = result.Id },
            IncomeResourceFromEntityAssembler.ToResource(result));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetIncomeById(int id)
    {
        var query = new GetIncomeByIdQuery(id);
        var result = await _incomeQueryService.Handle(query);
        var resource = IncomeResourceFromEntityAssembler.ToResource(result); 
        return Ok(resource);
    }
    
    [HttpGet("filter/{category}/{date}")]
    public async Task<ActionResult> GetIncomeByCategoryAndDate(string category, string date)
    {
        var query = new GetIncomeByCategoryAndDateQuery(category, date);
        var result = await _incomeQueryService.Handle(query);
        var resource = IncomeResourceFromEntityAssembler.ToResource(result);
        return Ok(resource);
    }
    
    [HttpGet("filter/all")]
    public async Task<ActionResult> GetAllExpenseByFarmId(int farmid)
    {
        var query = new GetAllIncomeByFarmIdQuery(farmid); 
        var result = await _incomeQueryService.Handle(query);
        var resource = result.Select(IncomeResourceFromEntityAssembler.ToResource);
        return Ok(resource);
    }

 
}