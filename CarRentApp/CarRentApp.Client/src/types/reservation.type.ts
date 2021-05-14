import { Car } from "./car.type";

export declare module Reservation {
  export type Reservation = {
    id: number;
    startDate: Date;
    endDate: Date;
    car: Car.CarPreview;
  };

  export type ReservedDayRanges = [string, string][];

  export type PostReservation = {
    startDate: string;
    endDate: string;
    carId: number;
  };

  export type ReservationForm = {
    startDate: Date;
    endDate: Date;
  };
}
