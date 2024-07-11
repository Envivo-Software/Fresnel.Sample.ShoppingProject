// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.CustomerAccounts.Dependencies;
using Acme.OnlineShopping.Model;
using Acme.OnlineShopping.Stock.Dependencies;
using Envivo.Fresnel.Bootstrap.WinForms;
using Envivo.Fresnel.Features;
using Envivo.Fresnel.UI.Core.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Windows.Forms;

// WinForms needs STA:
Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

ApplicationConfiguration.Initialize();

var builder = new HostApplicationBuilder(args);

builder.AddFresnel(opt =>
{
    opt
    .WithModelAssemblyFrom<Acme.OnlineShopping.Web.WebUser>()
    .WithFeature(Feature.UI_DoodleMode, FeatureState.On)
    .WithFeature(Feature.UI_UserFeedback, FeatureState.On)
    .WithDefaultFileLogging()
    ;

    // Because we're using InMemoryRepositories, we must use the same instance throughout:
    builder.Services.AddSingleton<CustomerRepository>();
    builder.Services.AddSingleton<CategoryRepository>();
    builder.Services.AddSingleton<ProductRepository>();
});

var host = builder.Build();

host.UseFresnel();

// Setup demo data before the application starts:
var demoInitialiser = host.Services.GetService<DemoInitialiser>();
if (demoInitialiser != null)
{
    await demoInitialiser.SetupDemoDataAsync();
}

var mainForm = host.Services.GetService<BlazorWinForm>() ?? throw new NullReferenceException();
Application.Run(mainForm);
