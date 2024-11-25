import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { CategoryService } from './services/category.service';
import { RouterModule, Routes } from '@angular/router';
import { CategoryCardComponent } from './category/category-card/category-card.component';
import { CategoryItemComponent } from './category/category-item/category-item.component';
import { AirTemperatureComponent } from './data/meteorology/air-temperature/air-temperature.component';
import { MeteorologyTableComponent } from './data/meteorology/meteorology-table/meteorology-table.component';
import { MeteorologyService } from './services/meteorology.service';
import { FormsModule } from '@angular/forms';
import { AppHeaderComponent } from './block/app-header/app-header.component';

const appRoutes: Routes = [
  { path: '', component: CategoryListComponent },
  { path: 'category-card', component: CategoryCardComponent },
  { path: 'category-item', component: CategoryItemComponent },

  { path: 'air-temperature', component: AirTemperatureComponent },
  { path: 'meteorology-table', component: MeteorologyTableComponent },
];

@NgModule({
  declarations: [
    AppComponent,

    AppHeaderComponent,

    CategoryListComponent,
    CategoryCardComponent,
    CategoryItemComponent,

    AirTemperatureComponent,
    MeteorologyTableComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [CategoryService, MeteorologyService],
  bootstrap: [AppComponent],
})
export class AppModule {}
