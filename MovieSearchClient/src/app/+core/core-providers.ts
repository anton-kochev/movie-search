import {
  APP_INITIALIZER,
  EnvironmentProviders,
  makeEnvironmentProviders,
} from '@angular/core';
import { MoviesApiServiceService } from './api/movies-api-service';
import { ConfigurationService } from './services/configuration.service';

export const provideAppCore = (): EnvironmentProviders =>
  makeEnvironmentProviders([
    // API services
    MoviesApiServiceService,
    // Configuration
    ConfigurationService,
    {
      provide: APP_INITIALIZER,
      useFactory: (config: ConfigurationService) => () => config.load(),
      deps: [ConfigurationService],
      multi: true,
    },
  ]);
