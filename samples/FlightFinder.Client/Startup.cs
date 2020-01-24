﻿// <copyright file="Startup.cs" company=".NET Foundation">
// Copyright (c) .NET Foundation. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// these files except in compliance with the License. You may obtain a copy of the
// License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
// </copyright>

namespace FlightFinder.Client
{
    using System.Threading.Tasks;
    using Cortex.Net;
    using FlightFinder.Client.Services;
    using Microsoft.AspNetCore.Components.Builder;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Startup class. Configures Services and the application itself.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures the services by adding them to the container.
        /// </summary>
        /// <param name="services">The collection of services to add to.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Blazor is single threaded for now but does not provide a Task Scheduler when FromCurrentSynchronizationContext();
            // is called. However TaskScheduler.Current is available and at least is able to Schedule tasks.
            SharedState.GlobalState.Configuration.TaskScheduler = TaskScheduler.Current;

            // Do not enforce actions. This is to allow observable properties to be bound using normal bind directives.
            SharedState.GlobalState.Configuration.EnforceActions = EnforceAction.Never;

            // Add the Shared state to the DI container.
            services.AddSingleton(x => SharedState.GlobalState);

            // Add application state to the DI container.
            services.AddSingleton<ShortListState>();
            services.AddSingleton<SearchState>();
        }

        /// <summary>
        /// Configures the application and the Http Request Pipeline.
        /// </summary>
        /// <param name="app">The applicationbuilder instance.</param>
        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<Main>("body");
        }
    }
}
