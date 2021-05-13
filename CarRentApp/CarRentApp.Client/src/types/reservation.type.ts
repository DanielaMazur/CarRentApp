import { Car } from "./car.type";

export declare module Reservation {
  export type Reservation = {
    id: number;
    startDate: Date;
    endDate: Date;
    car: Car.CarPreview;
  };

  export type PostReservation = {
    startDate: Date;
    endDate: Date;
    carId: number;
  };

  export type ReservationForm = {
    startDate: Date;
    endDate: Date;
  };
}
