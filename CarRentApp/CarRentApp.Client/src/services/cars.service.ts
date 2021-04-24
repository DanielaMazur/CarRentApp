import { API } from "./api";

import { Car } from "types";

const GetCars = () => {
  return API.get<Car.Car[]>("/cars");
};

const CarService = {
  GetCars,
};

export { CarService };
