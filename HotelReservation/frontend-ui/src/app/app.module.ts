import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

import { ReservationsService } from 'src/services/reservations.service';
import { ListReservationsComponent } from 'src/components/reservations/list-reservations.component';

import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDividerModule } from '@angular/material/divider';
import { MatSelectModule } from '@angular/material/select';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDialogModule } from '@angular/material/dialog';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';

const appRoutes: Routes = [
  // {
  //     path: '',
  //     redirectTo: '/dashboard',
  //     pathMatch: 'full',
  //     component: DashboardComponent
  // },  
  // {
  //     path: 'dashboard',
  //     component: DashboardComponent
  // },
  // {
  //   path: '',
  //   redirectTo: 'reservations/listreservations',
  //   component: ListReservationsComponent
  // },
  // { path: '/', redirectTo: 'reservations/listreservations' },
  {
    path : 'reservations/listreservations', component: ListReservationsComponent
  }
  ];

@NgModule({
  declarations: [
    AppComponent,
    ListReservationsComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatProgressBarModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatDividerModule,
    MatSelectModule,
    MatGridListModule,
    MatDialogModule,
    MatAutocompleteModule,
    MatPaginatorModule,
    MatSortModule,
    MatSnackBarModule,
    MatProgressBarModule,
    MatSidenavModule,
    MatListModule,
    MatToolbarModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    ReservationsService, 
    HttpClientModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
