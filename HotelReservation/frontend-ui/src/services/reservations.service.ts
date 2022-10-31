import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry } from 'rxjs';
import { Reservation } from 'src/models/Reservation';

const httpOptions = {
  headers: new HttpHeaders ({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ReservationsService {
  // url:string = "api/Reservation/v1";
  url:string = 'http://localhost:5007/api/Reservation/v1';

  constructor(private http: HttpClient) { 
    //debugger;
  }

  GetAll() : Observable<Reservation[]>{
    console.warn('GetAll ' + this.url+'/allreservations');
    return this.http.get<Reservation[]>(this.url+'/allreservations');
  }

  GetById(reservationId: number) : Observable<Reservation>{
    const theUrl = `${this.url}/${reservationId}`;
    return this.http.get<Reservation>(theUrl);
  }

  NewReservation(reservation: Reservation) : Observable<any>{
    return this.http.post<Reservation>(this.url, reservation, httpOptions);
  }

  UpdateReservation(reservation: Reservation) : Observable<any>{
    return this.http.put<Reservation>(this.url, reservation, httpOptions);
  }

  DeleteReservation(reservationId: number) : Observable<any>{
    const theUrl = `${this.url}/${reservationId}`;
    return this.http.delete<Reservation>(theUrl);
  }
}
