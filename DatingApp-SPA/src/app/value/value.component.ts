import { Component, OnInit, ErrorHandler } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  values:any;

  constructor(private http:HttpClient) { }

  ngOnInit() {
    this.getValues();
  }

 /*  getValues(): Observable<any>{
    
    return this.http.get<any>('http://localhost:5000/weatherforecast').pipe(
      catchError(this.handleError<any>('getWeather', []))
    );
  } */
  
  // metoda ktora sa pripoji na api a stiahne udaje a ulozi ich do atributu
  getValues(){
    return this.http.get('http://localhost:5000/WeatherForecast/').subscribe(response =>{
      this.values = response;
    }, error =>{
      console.log(error);
    });
  }
  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
;

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}


