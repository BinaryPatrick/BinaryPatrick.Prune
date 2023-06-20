﻿using BinaryPatrick.ArgumentHelper.Services;
using BinaryPatrick.Prune.Models;
using BinaryPatrick.Prune.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryPatrick.Prune
{
    internal class Startup
    {
        private static readonly Startup singleton = new Startup();

        public ServiceCollection Services { get; } = new ServiceCollection();

        private Startup() { }

        public static Startup GetInstance()
        {
            return singleton;
        }

        public Startup ConfigureOptions(string[] args)
        {
            PruneOptions options = new ArgumentParser<PruneOptions>().Parse(args);
            Services.AddTransient(sp => options);
            return this;
        }

        public Startup RegisterServices()
        {
            Services.AddTransient<IDirectoryService, DirectoryService>();
            return this;
        }

        public IServiceProvider BuildServiceProvider()
        {
            return Services.BuildServiceProvider();
        }
    }
}
