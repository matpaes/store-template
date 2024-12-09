import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  public forecasts?: WeatherForecast[];

  constructor(http: HttpClient) {
    http.get<WeatherForecast[]>('/weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  title = 'store.front';
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}