import { PageSettings } from "./page-settings";

export interface GetProductsQuery {
  pageSettings: PageSettings;
  name?: string;
  code?: string;
  maxPrice?: number;
  minPrice?: number;
}
