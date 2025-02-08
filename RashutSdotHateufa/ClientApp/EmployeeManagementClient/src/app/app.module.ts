import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; // ✅ Import HttpClientModule

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// ✅ Import Angular Material Modules
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule, // ✅ Required for Angular Material
    MatTableModule, // ✅ Material Table
    MatCardModule, // ✅ Material Cards
    MatButtonModule // ✅ Material Buttons
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
