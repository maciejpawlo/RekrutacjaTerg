import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Configuration } from '../models/configuration';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  configurationPath: string = './assets/configuration.json'
  configuration!: Configuration;

  constructor(private http: HttpClient) { }

  loadConfiguration(): Promise<Configuration> {
    return lastValueFrom(this.http.get<Configuration>(this.configurationPath))
      .then(data => this.configuration = data);
  }
}
