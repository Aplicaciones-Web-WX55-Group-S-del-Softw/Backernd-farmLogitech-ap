using System.Net.Mime;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Queries.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Services;
using Backend_farmlogitech.DashboardAnalytics.Interfaces.Resources.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Interfaces.Transform.Expenses;
using Microsoft.AspNetCore.Mvc;

namespace Backend_farmlogitech.DashboardAnalytics.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ExpenseController : ControllerBase
{
    private IExpenseQueryService _ExpenseQueryService;
    private IExpenseCommandService _ExpenseCommandService;

    public ExpenseController(IExpenseQueryService ExpenseQueryService, IExpenseCommandService ExpenseCommandService)
    {
        _ExpenseQueryService = ExpenseQueryService;
        _ExpenseCommandService = ExpenseCommandService;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateExpense([FromBody] CreateExpenseResource command)
    {
        var expense = CreateExpenseCommandFromResourceAssembler.ToCommandFromResource(command);
        var result = await _ExpenseCommandService.Handle(expense);
        return CreatedAtAction(nameof(GetExpenseById), new { id = result.Id },
            ExpenseResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetExpenseById(int id)
    {
        var query = new GetExpenseByIdQuery(id);
        var result = await _ExpenseQueryService.Handle(query);
        var resource = ExpenseResourceFromEntityAssembler.ToResourceFromEntity(result); 
        return Ok(resource);
    }
    
    [HttpGet("Expense/{category}/{date}")]
    public async Task<ActionResult> GetExpenseByCategoryAndPeriod(string category, string date)
    {
        var query = new GetExpenseByCategoryAndDateQuery(category, date);
        var result = await _ExpenseQueryService.Handle(query);
        var resource = ExpenseResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet("Expense/all")]
    public async Task<ActionResult> GetAllExpenseByFarmId(int Farmid)
    {
        var query = new GetAllByFarmIdQuery(Farmid);
        var result = await _ExpenseQueryService.Handle(query);
        var resource = result.Select(ExpenseResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resource);
    }
    
    

 
}