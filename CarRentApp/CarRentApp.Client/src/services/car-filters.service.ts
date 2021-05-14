import { fetchApi } from "./fetchApi";

import { Filters } from "../types";

const GetCarBodyFilters = (numberOfCarBodies: number) => {
  return fetchApi<Filters.CarBodyFilters[]>(
    `/filters/car-body?numberOfCarBodies=${numberOfCarBodies}`
  );
};

const CarFiltersService = {
  GetCarBodyFilters,
};

export { CarFiltersService };
