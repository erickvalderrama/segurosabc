import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { LoadingModule } from 'src/app/components/loading/loading.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { TitleModule } from 'src/app/single-components/title/title.module';
import { FormSearchModule } from 'src/app/components/form-search/form-search.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HomeRoutingModule,
    LoadingModule,
    TitleModule,
    FormSearchModule
  ],
  declarations: [HomeComponent]
})
export class HomeModule {}
