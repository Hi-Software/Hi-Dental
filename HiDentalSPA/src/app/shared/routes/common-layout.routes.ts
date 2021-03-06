import { Routes } from '@angular/router';

export const CommonLayout_ROUTES: Routes = [
    {
        path: 'dashboard',
        loadChildren: () => import('../../dashboard/dashboard.module').then(m => m.DashboardModule)
    } ,
    {
        path: 'usuarios',
        loadChildren: () => import('../../layouts/usuarios/usuarios.module').then(m => m.UsuariosModule)
    } 
];