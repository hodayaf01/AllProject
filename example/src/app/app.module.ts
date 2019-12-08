import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core'
import { FormsModule,ReactiveFormsModule } from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {UserService} from './Services/UserService';
import {RegistrationUserComponent} from './Components/RegistrationUser/RegistrationUser';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  {path: 'registration', component: RegistrationUserComponent},
];


@NgModule({
  declarations: [
    //כל קומפוננטה חייבת להיות כאן
    AppComponent, 
    RegistrationUserComponent
  ],
  
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes)
  ],

  //מכיל את כל הסרויסים
  providers: [
    UserService
  ],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
