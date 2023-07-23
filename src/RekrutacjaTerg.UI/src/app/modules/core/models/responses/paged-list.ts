export interface PagedList<T> {
  items: Array<T>;
  pageNumber: number;
  totalPages: number;
  totalCount: number;
}
