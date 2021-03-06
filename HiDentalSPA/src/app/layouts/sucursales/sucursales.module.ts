import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SucursalesComponent } from './sucursales.component';
import { SucursalesRoutingModule } from './sucursales.routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgZorroAntdModule, NZ_I18N, en_US } from 'ng-zorro-antd';
import { ReactiveFormsModule } from '@angular/forms';
import { SucursalListadoComponent } from './sucursal-listado/sucursal-listado.component';
import { SucursalFormularioComponent } from './sucursal-formulario/sucursal-formulario.component';
import { TableService } from 'src/app/shared/services/table.service';
import { ThemeConstantService } from 'src/app/shared/services/theme-constant.service';
@NgModule({
  imports: [
  
    CommonModule,
    SucursalesRoutingModule,
    SharedModule,
    NgZorroAntdModule,
    
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),

 
  ],

  declarations: [SucursalesComponent, SucursalListadoComponent, SucursalFormularioComponent],
  providers: [
    { 
        provide: NZ_I18N,
        useValue: en_US, 
    },
    TableService,
    ThemeConstantService
],
})
export class SucursalesModule { }
