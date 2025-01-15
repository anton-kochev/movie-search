import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigurationService } from '../services/configuration.service';

type ContentType = 'json' | 'json-patch';

export abstract class BaseApiService {
  private readonly http: HttpClient;
  private readonly baseUrl: string;

  constructor() {
    this.http = inject(HttpClient);
    this.baseUrl = inject(ConfigurationService).getConfig().apiBaseUrl;
  }

  protected get<T>(path: string): Observable<T> {
    const opts = { headers: BaseApiService.headers() };

    return this.http.get<T>(`${this.baseUrl}/${path}`, opts);
  }

  protected patch(path: string, patch: unknown): Observable<unknown> {
    const opts = { headers: BaseApiService.headers('json-patch') };

    return this.http.patch(`${this.baseUrl}/${path}`, patch, opts);
  }

  protected post<T = unknown>(path: string, body: unknown): Observable<T> {
    const opts = { headers: BaseApiService.headers() };

    return this.http.post<T>(`${this.baseUrl}/${path}`, body, opts);
  }

  protected put<T = unknown>(path: string, body: unknown): Observable<T> {
    const opts = { headers: BaseApiService.headers() };

    return this.http.put<T>(`${this.baseUrl}/${path}`, body, opts);
  }

  /* eslint-disable @typescript-eslint/naming-convention */
  private static contentTypeHeader(contentType: ContentType): {
    'Content-Type': string;
  } {
    switch (contentType) {
      case 'json':
        return { 'Content-Type': 'application/json' };
      case 'json-patch':
        return { 'Content-Type': 'application/json-patch+json' };
      default:
        return { 'Content-Type': 'application/json' };
    }
  }

  private static headers(contentType: ContentType = 'json'): HttpHeaders {
    return new HttpHeaders({
      ...BaseApiService.contentTypeHeader(contentType),
    });
  }
}
