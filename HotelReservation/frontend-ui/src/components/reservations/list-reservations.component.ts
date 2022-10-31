import { Component, OnInit } from "@angular/core";
import { MatTableDataSource } from '@angular/material/table';
import { ReservationsService } from "src/services/reservations.service";

@Component({
    selector: 'list-reservations',
    templateUrl: './list-reservations.component.html',
    styleUrls: ['./list-reservations.component.css']
})
export class ListReservationsComponent implements OnInit{
    reservations = new MatTableDataSource<any>();
    displayColumns: string[];
    
    constructor(private reservationsService: ReservationsService) { }

    ngOnInit(): void {
        console.warn("list-reservations OnInit...");
        this.reservationsService.GetAll().subscribe(resultOne => {
            this.reservations.data = resultOne,
            console.warn('resultOne ', resultOne)
            ;            
        })
        this.displayColumns = this.ShowColumns();
    }

    ShowColumns(): string[]{
        return [ 'Id', 'hotelId', 'roomId', 'customerName', 'reservedDays', 'beginDate', 'endDate' ]
    }
}