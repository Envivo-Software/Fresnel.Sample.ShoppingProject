// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.CustomerAccounts.Dependencies;
using Acme.OnlineShopping.Model;
using Acme.OnlineShopping.Stock.Dependencies;
using Envivo.Fresnel.Bootstrap.WinForms;
using Envivo.Fresnel.Features;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Windows.Forms;

// WinForms needs STA:
Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

ApplicationConfiguration.Initialize();

var domainClassType = typeof(Acme.OnlineShopping.Web.WebUser);

var mainForm =
    new BlazorWinFormBuilder()
    .WithModelAssembly(domainClassType.Assembly)
    .WithFeature(Feature.UI_DoodleMode, FeatureState.On)
    .WithServices(sc =>
    {
        // Because we're using InMemoryRepositories, we must use the same instance throughout:
        sc.AddSingleton<CustomerRepository>();
        sc.AddSingleton<CategoryRepository>();
        sc.AddSingleton<ProductRepository>();
    })
    .WithFileLogging()
    .WithPreStartupSteps(async sp =>
    {
        // This lets us setup demo data before the application starts:
        var demoInitialiser = sp.GetService<DemoInitialiser>();
        if (demoInitialiser != null)
        {
            await demoInitialiser.SetupDemoDataAsync();
        }
    })
    .Build();

Application.Run(mainForm);
