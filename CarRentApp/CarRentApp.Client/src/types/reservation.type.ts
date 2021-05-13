export declare module Reservation {
  export type Reservation = {
    id: number;
    startDate: Date;
    endDate: Date;
    carId: number;
  };
  export type PostReservation = Omit<Reservation, "id">;
  export type ReservationForm = {
    startDate: Date;
    endDate: Date;
  };
}
