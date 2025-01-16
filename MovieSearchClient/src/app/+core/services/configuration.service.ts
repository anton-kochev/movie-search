import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { firstValueFrom, map, tap } from 'rxjs';

interface Configuration {
  apiBaseUrl: string;
}

@Injectable()
export class ConfigurationService {
  private config: Configuration;
  private readonly httpClient: HttpClient;

  constructor(handler: HttpBackend) {
    this.config = { apiBaseUrl: '' };
    this.httpClient = new HttpClient(handler);
  }

  public getConfig(): Configuration {
    return this.config;
  }

  public load(): Promise<boolean> {
    return firstValueFrom(
      this.httpClient.get<Configuration>(environment.pathToConfig).pipe(
        tap(config => this.setConfig(config)),
        map(() => true),
      ),
    );
  }

  private validateConfiguration(config: unknown): void {
    // There is no type-safe between json and interface describes its structure,
    // so we have to check it manually for typos and mistakes

    const { apiBaseUrl } = config as Configuration;

    if (apiBaseUrl == null) {
      throw new Error('Configuration is missing "apiBaseUrl" field');
    }
  }

  private setConfig(config: unknown): void {
    // Check and throw an error if config.json lacks the required keys.
    // There is no type-safe between json and interface describes its structure,
    // so we have to check it manually for typos and mistakes
    this.validateConfiguration(config);

    const { apiBaseUrl } = config as Configuration;

    this.config = {
      apiBaseUrl,
    };
  }
}
