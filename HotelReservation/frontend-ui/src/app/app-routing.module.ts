import { NgModule } from "@angular/core";
import { Routes, RouterModule} from "@angular/router";
import { ListReservationsComponent } from "src/components/reservations/list-reservations.component";

const routes: Routes = [
    {
        path : 'reservations/listreservations', component: ListReservationsComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule{}