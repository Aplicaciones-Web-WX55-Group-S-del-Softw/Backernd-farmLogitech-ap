﻿namespace Backend_farmlogitech.DashboardAnalytics.Interfaces.Resources.Incomes;

public record IncomeResource(int Id, string Category, string Period, string Description, double Amount, string Date);