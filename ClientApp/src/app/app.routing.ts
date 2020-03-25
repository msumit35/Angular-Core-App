import { Routes, Router, RouterModule } from "@angular/router";
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_helpers/auth.guard';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { MobileRechargeComponent } from './mobile-recharge/mobile-recharge.component';
import { ElectricityComponent } from './electricity/electricity.component';

const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'mobile-recharge', component: MobileRechargeComponent, canActivate: [AuthGuard] },
    { path: 'electricity', component: ElectricityComponent, canActivate: [AuthGuard] }
]

export const appRoutingModule = RouterModule.forRoot(routes);
