import { fetchApi } from "./fetchApi";

import { Car } from "types";

const GetCars = () => {
  return fetchApi<Car.Car[]>("/cars");
};

const CarService = {
  GetCars,
};

export { CarService };
