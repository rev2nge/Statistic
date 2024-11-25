import { Component, OnInit } from '@angular/core';
import { Meteorology } from '../Meteorology.interface';
import { MeteorologyService } from '../../../services/meteorology.service';
import { HttpParams } from '@angular/common/http';
import { Contact } from '../../Contact.interface';
import { Source } from '../../Source.interface';

@Component({
  selector: 'app-air-temperature',
  templateUrl: './air-temperature.component.html',
  styleUrls: ['./air-temperature.component.css'],
})
export class AirTemperatureComponent implements OnInit {
  meteorologyData: Meteorology[] = [];
  totalItems = 0;
  currentPage = 1;
  pageSize = 10;
  showTable: boolean = false;
  meteorology?: Meteorology;

  filters = {
    year: [] as number[],
    month: [] as string[],
  };

  contact?: Contact;
  source?: Source;

  months: string[] = [];
  years: number[] = [];

  selectedMonths: string[] = [];
  monthSearch: string = '';

  selectedYears: number[] = [];
  yearsSearch: string = '';

  constructor(private meteorologyService: MeteorologyService) {}

  ngOnInit(): void {
    this.loadMeteorologyData();
    this.loadDistinctMonths();
    this.loadDistinctYears();
  }

  loadMeteorologyData(): void {
    this.meteorologyService
      .getMeteorologyData(this.filters, this.currentPage, this.pageSize)
      .subscribe((response) => {
        this.meteorologyData = response.data;
        this.totalItems = response.totalItems;
      });
  }

  loadDistinctMonths(): void {
    this.meteorologyService.getDistinctMonths().subscribe((months) => {
      this.months = months;
    });
  }

  loadDistinctYears(): void {
    this.meteorologyService.getDistinctYears().subscribe((years) => {
      this.years = years;
    });
  }

  loadContact(contactId: number): void {
    this.meteorologyService.getContact(contactId).subscribe({
      next: (contact) => {
        console.log('Contact loaded:', contact);
        this.contact = contact;
      },
      error: (err) => console.error('Ошибка при загрузке контакта:', err),
    });
  }

  loadSource(sourceId: number): void {
    this.meteorologyService.getSource(sourceId).subscribe({
      next: (source) => (this.source = source),
      error: (err) => console.error('Ошибка при загрузке источника:', err),
    });
  }

  onFilterChange(): void {
    this.currentPage = 1;
    this.loadMeteorologyData();
    this.showTable = true;
  }

  filteredMonths(): string[] {
    return this.months.filter((month) =>
      month.toLowerCase().includes(this.monthSearch)
    );
  }

  filteredYears(): number[] {
    return this.years.filter((year) =>
      year.toString().includes(this.yearsSearch)
    );
  }

  selectAllMonths() {
    this.filters.month = [...this.months];
  }

  deselectAllMonths() {
    this.filters.month = [];
  }

  selectAllYears() {
    this.filters.year = [...this.years];
  }

  deselectAllYears() {
    this.filters.year = [];
  }

  isSelected(year: number): boolean {
    return this.filters.year?.includes(year) ?? false;
  }

  isSelectedSec(month: string): boolean {
    return this.filters.month?.includes(month) ?? false;
  }

  exportToExcel(): void {
    const filter = {
      year: this.filters.year,
      month: this.filters.month ? [this.filters.month] : [],
    };

    const params = new HttpParams()
      .set('year', filter.year.join(','))
      .set('month', filter.month.join(','));

    this.meteorologyService.exportToExcel(params).subscribe((response) => {
      const blob = response;
      const link = document.createElement('a');
      link.href = URL.createObjectURL(blob);
      link.download = 'MeteorologyData.xlsx';
      link.click();
    });
  }
}
