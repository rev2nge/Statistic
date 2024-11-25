import { Category } from '../../category/Category.interface';
import { Contact } from '../Contact.interface';
import { Source } from '../Source.interface';

export interface Meteorology {
  id: number;
  airTemperature: string;
  precipitationQuantity: string;
  averageMonthlyWindSpeed: string;
  month: string;
  year: number;
  category: Category;
  source: Source;
  contact: Contact;
}

export interface MeteorologyResponse {
  totalItems: number;
  data: Meteorology[];
}
