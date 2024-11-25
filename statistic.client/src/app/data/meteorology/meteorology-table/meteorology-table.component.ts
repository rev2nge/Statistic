import { Component, OnInit } from '@angular/core';
import { Meteorology } from '../Meteorology.interface';
import { MeteorologyService } from '../../../services/meteorology.service';

@Component({
  selector: 'app-meteorology-table',
  templateUrl: './meteorology-table.component.html',
  styleUrls: ['./meteorology-table.component.css'],
})
export class MeteorologyTableComponent implements OnInit {
  meteorologyData: Meteorology[] = [];
  totalItems = 0;
  currentPage = 1;
  pageSize = 10;

  filters = {
    year: [] as number[],
    month: [] as string[],
  };
  constructor(private meteorologyService: MeteorologyService) {}

  ngOnInit(): void {
    this.loadMeteorologyData();
  }

  loadMeteorologyData(): void {
    this.meteorologyService
      .getMeteorologyData(this.filters, this.currentPage, this.pageSize)
      .subscribe((response) => {
        this.meteorologyData = response.data;
        this.totalItems = response.totalItems;
      });
  }

  onFilterChange(): void {
    this.currentPage = 1;
    this.loadMeteorologyData();
  }

  onPageChange(newPage: number): void {
    this.currentPage = newPage;
    this.loadMeteorologyData();
  }
}
