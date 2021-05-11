import { fetchApi } from "./fetchApi";

import { Car } from "types";

const GetCars = () => {
  return fetchApi<Car.Car[]>("/cars");
};

const GetCar = (id: number) => {
  return fetchApi<Car.Car>(`/cars/${id}`);
};

const CarService = {
  GetCars,
  GetCar,
};

export { CarService };
