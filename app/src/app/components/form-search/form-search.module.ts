import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormSearchComponent } from './form-search.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'src/app/single-components/button/button.module';
import { LabelModule } from 'src/app/single-components/label/label.module';
import { LoadingModule } from '../loading/loading.module';


@NgModule({
  declarations: [FormSearchComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonModule,
    LoadingModule,
    LabelModule
  ],
  exports: [FormSearchComponent]
})
export class FormSearchModule { }
