import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public employees: Employee[];
  public punches: Punch[];
  
  public selectedEmployeeId: string;

  private _baseUrl: string;
  private _httpClient : HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
    this._httpClient = http;
    this.selectedEmployeeId = "";

    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast')
      .subscribe(result => {
        this.forecasts = result;
      }, error => console.error(error));

    http.get<Employee[]>(baseUrl+'employee')
        .subscribe(result => {
          this.employees = result;
        }, error => console.error(error));
  }

  fetchPunches(employeeId: string){
    this._httpClient.get<Punch[]>(this._baseUrl+`punch/${employeeId}`)
      .subscribe(result => {
        this.punches = result;
      }, error => console.error(error));    
  }

  registerPunch(){
    alert(this.selectedEmployeeId);
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface Employee {
  id: string;
  name: string;
}

interface Punch {
  employeeId: string;
  employeeName: string;
  datetime: Date;
  punchType: string;
}