export declare module Filters {
  export type CarBodyFilters = {
    id: number;
    type: CarBodyFiltersType;
    priority: number;
  };

  export type CarBodyFiltersType =
    | "Micro"
    | "Sedan"
    | "Cuv"
    | "Suv"
    | "Hatchback"
    | "Minivan"
    | "Cabriolet"
    | "Coupe"
    | "Roadster"
    | "PickUp"
    | "Van"
    | "Limousine"
    | "Camervan";
}
