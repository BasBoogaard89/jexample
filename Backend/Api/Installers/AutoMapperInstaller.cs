﻿using Application.Interfaces;

namespace Api.Installers;

public class AutoMapperInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(cfg => { }, typeof(AutoMapperInstaller).Assembly);
    }
}
