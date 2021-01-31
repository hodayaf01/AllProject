import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core'
import { FormsModule,ReactiveFormsModule } from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {RegistrationService} from './Services/RegistrationService';
import {RegistrationUserComponent} from './Components/RegistrationUser/RegistrationUser';
import { RouterModule, Routes } from '@angular/router';
import { TimeOfAlertComponent } from './Components/TimeOfAlert/TimeOfAlert';
import { TimeOfAlertForUserService } from './Services/TimeOfAlert.service';
import { SettingsComponent } from './Components/Settings/Settings';
import { SettingsService } from './Services/SettingsService';
import { HomeComponent } from './Components/Home/Home';
import { AlertComponent } from './Components/Alert/Alert';
import { PortalComponent } from './Components/Portal/Portal';
import { AngularFireMessagingModule } from '@angular/fire/messaging';
import { AngularFireDatabaseModule } from '@angular/fire/database';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { AngularFireModule } from '@angular/fire';
import { MessagingService } from './Services/messaging.service';
import { AsyncPipe } from '../../node_modules/@angular/common';
import { environment } from 'src/environments/environment';

const appRoutes: Routes = [
  {path: '', component: RegistrationUserComponent},

  {path: 'Registration', component: RegistrationUserComponent},
  {path: 'TimeOfAlert', component: TimeOfAlertComponent},
  {path:'Settings',component:SettingsComponent},
  {path:'Home',component:HomeComponent},
  {path:'Alert',component:AlertComponent},
  {path:'Portal',component:PortalComponent}
];


@NgModule({
  declarations: [
    //כל קומפוננטה חייבת להיות כאן
    AppComponent, 
    RegistrationUserComponent,
    TimeOfAlertComponent,
    SettingsComponent,
    HomeComponent,
    AlertComponent,
    PortalComponent
  ],
  
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    AngularFireDatabaseModule,
    AngularFireAuthModule,
    AngularFireMessagingModule,
    AngularFireModule.initializeApp(environment.firebaseConfig),
  ],

  //מכיל את כל הסרויסים
  providers: [
    RegistrationService,
    TimeOfAlertForUserService,
    SettingsService,
    MessagingService,
    AsyncPipe,
  ],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
