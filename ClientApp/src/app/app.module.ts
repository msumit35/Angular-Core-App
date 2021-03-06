import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ToastrModule } from 'ngx-toastr';
import { MatTableModule } from '@angular/material/table';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatPaginatorModule } from '@angular/material/paginator';

import { AppComponent } from './app.component';
import { AuthenticateService } from './services/authenticate.service';
import { LoginComponent } from './login/login.component';
import { appRoutingModule } from './app.routing';
import { JwtInterceptor } from './_helpers/jwt.interceptor';
import { ErrorEnterceptor } from './_helpers/error.interceptor';
import { HomeComponent } from './home/home.component';
import { UserService } from './services/user.service';
import { RegisterComponent } from './register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { DialogComponent } from './dialog/dialog.component';
import { SpinnerService } from './services/spinner.service';
import { SpinnerComponent } from './spinner/spinner.component';
import { PaymentService } from './services/payment.service';
import { MobileService } from './services/mobile-recharge.service';
import { MobileRechargeComponent } from './mobile-recharge/mobile-recharge.component';
import { RechargeDialog } from './mobile-recharge/recharge.dialog';
import { SidenavService } from './services/sidenav.service';
import { ElectricityComponent } from './electricity/electricity.component';
import { ElectricityRechargeDialog } from './electricity/recharge.dialog';
import { ElectricityService } from './services/electricity.service';
import { EditUserDialog } from './home/edit-user.dialog';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    RegisterComponent,
    ToolbarComponent,
    DialogComponent,
    SpinnerComponent,
    MobileRechargeComponent,
    ElectricityComponent,
    RechargeDialog,
    ElectricityRechargeDialog,
    EditUserDialog
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    appRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatExpansionModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatTableModule,
    MatRadioModule,
    MatSelectModule,
    MatPaginatorModule,
    ToastrModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorEnterceptor, multi: true },
    AuthenticateService,
    UserService,
    SpinnerService,
    MobileService,
    PaymentService,
    SidenavService,
    ElectricityService
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    DialogComponent,
    RechargeDialog,
    ElectricityRechargeDialog,
    EditUserDialog
  ]
  
})
export class AppModule { }
