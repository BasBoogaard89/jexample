﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Interfaces;

public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}
