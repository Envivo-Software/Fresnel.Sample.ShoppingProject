// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.Bootstrap.WinForms;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Windows.Forms;

Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

ApplicationConfiguration.Initialize();

var serviceCollection = new ServiceCollection();
// Register your own dependencies here

var domainClassType = typeof(Acme.OnlineShopping.Web.WebUser);

var mainForm =
    new BlazorWinFormBuilder()
    .WithServices(serviceCollection)
    .WithModelAssembly(domainClassType.Assembly)
    .Build();

Application.Run(mainForm);
