import { fetchApi } from "./fetchApi";

import { Car } from "types";

const GetCars = (carBodyId?: number) => {
  return fetchApi<Car.Car[]>(`/cars?carBodyType=${carBodyId}`);
};

const GetCar = (id: number) => {
  return fetchApi<Car.Car>(`/cars/${id}`);
};

const CarService = {
  GetCars,
  GetCar,
};

export { CarService };
