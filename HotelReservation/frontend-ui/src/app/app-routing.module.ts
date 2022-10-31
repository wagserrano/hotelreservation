import { NgModule } from "@angular/core";
import { Routes, RouterModule} from "@angular/router";
import { ListReservationsComponent } from "src/components/reservations/list-reservations.component";

const appRoutes: Routes = [
    {
        path : 'reservations/listreservations', 
        component: ListReservationsComponent,
        children: [
            {
              path: 'categorias/listagemcategorias',
              component: ListReservationsComponent,
            },
        ],
    }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule{}