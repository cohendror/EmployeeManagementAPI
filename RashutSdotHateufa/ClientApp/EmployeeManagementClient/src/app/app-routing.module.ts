import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'employees', pathMatch: 'full' }, // Default route
  { path: 'employees', component: EmployeeListComponent }, // Employees list page
  { path: '**', redirectTo: 'employees' } // Redirect unknown paths
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
