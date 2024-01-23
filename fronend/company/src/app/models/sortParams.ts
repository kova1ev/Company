export class SortParams {
  constructor(column: Column, sort: Sort) {
    this.column = column;
    this.sort = sort;
  }

  column: Column;
  sort: Sort;
}

export enum Sort {
  Asc,
  Desc
}

export enum Column {
  FullName,
  Department,
  Salary,
  DateOfBirth,
  EmploymentDate
}

